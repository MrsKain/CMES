﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cnty.Core.Extensions;
using Cnty.Core.ManageUser;
using Cnty.Core.Services;
using Cnty.Core.UserManager;
using Cnty.Core.Utilities;
using Cnty.Entity;
using Cnty.Entity.DomainModels;

namespace Cnty.System.Services
{
    public partial class Sys_RoleService
    {

        public override PageGridData<Sys_Role> GetPageData(PageDataOptions pageData)
        {
            //角色Id=1默认为超级管理员角色，界面上不显示此角色
            QueryRelativeExpression = (IQueryable<Sys_Role> queryable) =>
            {
                if (UserContext.Current.IsSuperAdmin)
                {
                    return queryable;
                }
                List<Guid> roleIds = GetAllChildrenRoleIdAndSelf();
                return queryable.Where(x => roleIds.Contains(x.Id));
            };
            return base.GetPageData(pageData);
        }
        /// <summary>
        /// 编辑权限时，获取当前用户的所有菜单权限
        /// </summary>
        /// <returns></returns>
        public async Task<WebResponseContent> GetCurrentUserTreePermission()
        {
            return await GetUserTreePermission(UserContext.Current.RoleId);
        }

        /// <summary>
        /// 编辑权限时，获取指定角色的所有菜单权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<WebResponseContent> GetUserTreePermission(Guid roleId)
        { 
            WebResponseContent webResponse = new WebResponseContent();
            if (!UserContext.IsRoleIdSuperAdmin(roleId) && UserContext.Current.RoleId != roleId)
            {
                if (!(await GetAllChildrenAsync(UserContext.Current.RoleId)).Exists(x => x.Id == roleId))
                {
                    return webResponse.Error("没有权限获取此角色的权限信息");
                }
            }
            //获取用户权限
            List<Permissions> permissions = UserContext.Current.GetPermissions(roleId);
            //权限用户权限查询所有的菜单信息
            List<Sys_Menu> menus = await Task.Run(() => Sys_MenuService.Instance.GetUserMenuList(roleId));
            //获取当前用户权限如:(Add,Search)对应的显示文本信息如:Add：添加，Search:查询
            var data = menus.Select(x => new UserPermissions
            {
                Id = x.Menu_Id,
                Pid = x.ParentId,
                Text = x.MenuName,
                Actions = GetActions(x.Menu_Id, x.Actions, permissions, roleId)
            });
            return webResponse.OK(null, data);
        }

        private List<Sys_Actions> GetActions(int menuId, List<Sys_Actions> menuActions, List<Permissions> permissions, Guid roleId)
        {
            if (UserContext.IsRoleIdSuperAdmin(roleId))
            {
                return menuActions;
            }

            return menuActions.Where(p => permissions
                 .Exists(w => menuId == w.Menu_Id
                 && w.UserAuthArr.Contains(p.Value)))
                  .ToList();
        }

        private List<RoleNodes> rolesChildren = new List<RoleNodes>();

        /// <summary>
        /// 编辑权限时获取当前用户下的所有角色与当前用户的菜单权限
        /// </summary>
        /// <returns></returns>
        public async Task<WebResponseContent> GetCurrentTreePermission()
        {
            WebResponseContent webResponse = await GetCurrentUserTreePermission();
            Guid roleId = UserContext.Current.RoleId;
            return new WebResponseContent().OK(null, new
            {
                tree = webResponse.Data,
                roles = await GetAllChildrenAsync(roleId)
            });
        }

        private List<RoleNodes> roles = null;

        /// <summary>
        /// 获取当前角色下的所有角色包括自己的角色Id
        /// </summary>
        /// <returns></returns>
        public List<Guid> GetAllChildrenRoleIdAndSelf()
        {
            Guid roleId = UserContext.Current.RoleId;
            List<Guid> roleIds = GetAllChildren(roleId).Select(x => x.Id).ToList();
            roleIds.Add(roleId);
            return roleIds;
        }


        /// <summary>
        /// 获取当前角色下的所有角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleNodes> GetAllChildren(Guid roleId)
        {
            roles = GetAllRoleQueryable(roleId).ToList();
            return GetAllChildrenNodes(roleId);
        }

        public async Task<List<RoleNodes>> GetAllChildrenAsync(Guid roleId)
        {
            roles = await GetAllRoleQueryable(roleId).ToListAsync();
            return GetAllChildrenNodes(roleId);
        }
        private IQueryable<RoleNodes> GetAllRoleQueryable(Guid roleId)
        {
            return repository
                   .FindAsIQueryable(
                   x => x.Enable == 1 && x.Id !=Guid.Empty)
                   .Select(
                   s => new RoleNodes()
                   {
                       Id = s.Id,
                       ParentId = s.ParentId,
                       RoleName = s.RoleName
                   });
        }

        public async Task<List<string>> GetAllChildrenRoleIdAsync(Guid roleId)
        {
            return (await GetAllChildrenAsync(roleId)).Select(x => x.Id.ToString()).ToList();
        }


        public List<string> GetAllChildrenRoleId(Guid roleId)
        {
            return GetAllChildren(roleId).Select(x => x.Id.ToString()).ToList();
        }

        private List<RoleNodes> GetAllChildrenNodes(Guid roleId)
        {
            if (UserContext.IsRoleIdSuperAdmin(roleId)) return roles;
            Dictionary<Guid, bool> completedRoles = new Dictionary<Guid, bool>();
            rolesChildren = GetChildren(roleId, completedRoles);
            return rolesChildren;
        }
        /// <summary>
        /// 递归获取所有子节点权限
        /// </summary>
        /// <param name="roleId"></param>
        private List<RoleNodes> GetChildren(Guid roleId,Dictionary<Guid, bool> completedRoles)
        {
            roles.ForEach(x =>
            {
                if (x.ParentId == roleId)
                {
                    if (completedRoles.TryGetValue(roleId, out bool isWrite))
                    {
                        if (!isWrite)
                        {
                            completedRoles[roleId] = true;
                            Logger.Error($"获取子角色异常Sys_RoleService,角色id:{roleId}");
                        }
                        return;
                    }
                    rolesChildren.Add(x);

                    completedRoles[x.Id] = false;


                    if (x.Id != x.ParentId)
                    {
                        GetChildren(x.Id, completedRoles);
                    }
                }
            });
            return rolesChildren;
        }

        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <param name="userPermissions"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<WebResponseContent> SavePermission(List<UserPermissions> userPermissions, Guid Id)
        {
            WebResponseContent webResponse = new WebResponseContent();
            string message = "";
            try
            {
                UserInfo user = UserContext.Current.UserInfo;
                if (!(await GetAllChildrenAsync(user.Role_Id)).Exists(x => x.Id == Id))
                    return webResponse.Error("没有权限修改此角色的权限信息");
                //当前用户的权限
                List<Permissions> permissions = UserContext.Current.Permissions;

                List<int> originalMeunIds = new List<int>();
                //被分配角色的权限
                List<Sys_RoleAuth> roleAuths = await repository.FindAsync<Sys_RoleAuth>(x => x.Role_Id == Id);             
                List<Sys_RoleAuth> updateAuths = new List<Sys_RoleAuth>();
                foreach (UserPermissions x in userPermissions)
                {
                    Permissions per = permissions.Where(p => p.Menu_Id == x.Id).FirstOrDefault();
                    //不能分配超过当前用户的权限
                    if (per == null) continue;
                    //per.UserAuthArr.Contains(a.Value)校验权限范围
                    string[] arr = x.Actions == null || x.Actions.Count == 0
                      ? new string[0]
                      : x.Actions.Where(a => per.UserAuthArr.Contains(a.Value))
                      .Select(s => s.Value).ToArray();

                    //如果当前权限没有分配过，设置Auth_Id默认为0，表示新增的权限
                    var auth = roleAuths.Where(r => r.Menu_Id == x.Id).Select(s => new { s.Auth_Id, s.AuthValue, s.Menu_Id }).FirstOrDefault();
                    string newAuthValue = string.Join(",", arr);
                    //权限没有发生变化则不处理
                    if (auth == null || auth.AuthValue != newAuthValue)
                    {
                        updateAuths.Add(new Sys_RoleAuth()
                        {
                            Role_Id = Id,
                            Menu_Id = x.Id,
                            AuthValue = string.Join(",", arr),
                            Auth_Id = auth == null ? 0 : auth.Auth_Id,
                            ModifyDate = DateTime.Now,
                            Modifier = user.UserTrueName,
                            CreateDate = DateTime.Now,
                            Creater = user.UserTrueName
                        });
                    }
                    else
                    {
                        originalMeunIds.Add(auth.Menu_Id);
                    }

                }
                //更新权限
                repository.UpdateRange(updateAuths.Where(x => x.Auth_Id > 0), x => new
                {
                    x.Menu_Id,
                    x.AuthValue,
                    x.Modifier,
                    x.ModifyDate
                });
                //新增的权限
                repository.AddRange(updateAuths.Where(x => x.Auth_Id <= 0));

                //获取权限取消的权限
                int[] authIds = roleAuths.Where(x => userPermissions.Select(u => u.Id)
                 .ToList().Contains(x.Menu_Id) || originalMeunIds.Contains(x.Menu_Id))
                .Select(s => s.Auth_Id)
                .ToArray();
                List<Sys_RoleAuth> delAuths = roleAuths.Where(x => x.AuthValue != "" && !authIds.Contains(x.Auth_Id)).ToList();
                delAuths.ForEach(x =>
                {
                    x.AuthValue = "";
                });
                //将取消的权限设置为""
                repository.UpdateRange(delAuths, x => new
                {
                    x.Menu_Id,
                    x.AuthValue,
                    x.Modifier,
                    x.ModifyDate
                });

                int addCount = updateAuths.Where(x => x.Auth_Id <= 0).Count();
                int updateCount = updateAuths.Where(x => x.Auth_Id > 0).Count();
                await repository.SaveChangesAsync();

                string _version = DateTime.Now.ToString("yyyyMMddHHMMssfff");
                //标识缓存已更新
                base.CacheContext.Add(Id.GetRoleIdKey(), _version);

                webResponse.OK($"保存成功：新增加配菜单权限{addCount}条,更新菜单{updateCount}条,删除权限{delAuths.Count()}条");
            }
            catch (Exception ex)
            {
                message = "异常信息：" + ex.Message + ex.StackTrace + ",";
            }
            finally
            {
                Logger.Info($"权限分配置:{message}{webResponse.Message}");
            }

            return webResponse;
        }


        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            AddOnExecuting = (Sys_Role role, object obj) =>
            {
                return ValidateRoleName(role, x => x.RoleName == role.RoleName);
            };
            return RemoveCache(base.Add(saveDataModel));
        }

        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            return RemoveCache(base.Del(keys, delList));
        }

        private WebResponseContent ValidateRoleName(Sys_Role role, Expression<Func<Sys_Role, bool>> predicate)
        {
            WebResponseContent responseContent = new WebResponseContent(true);
            if (repository.Exists(predicate))
            {
                return responseContent.Error($"角色名【{role.RoleName}】已存在,请设置其他角色名");
            }
            return responseContent;
        }

        public override WebResponseContent Update(SaveModel saveModel)
        {
            UpdateOnExecuting = (Sys_Role role, object obj1, object obj2, List<object> obj3) =>
            {
                //2020.05.07新增禁止选择上级角色为自己
                if (role.Id == role.ParentId)
                {
                    return WebResponseContent.Instance.Error($"上级角色不能选择自己");
                }
                if (role.Id==UserContext.Current.RoleId)
                {
                    return WebResponseContent.Instance.Error($"不能修改自己的角色");
                }

                if (GetAllChildren(role.ParentId).Any(x => x.ParentId == role.Id)
                ||repository.Exists(x=>x.ParentId== role.Id))
                {
                    return WebResponseContent.Instance.Error($"不能选择此上级角色，选择的上级角色与当前角色形成依赖关系");
                }
                return ValidateRoleName(role, x => x.RoleName == role.RoleName && x.Role_Id != role.Role_Id);
            };
            return RemoveCache(base.Update(saveModel));
        }
        private WebResponseContent RemoveCache(WebResponseContent webResponse)
        {
            if (webResponse.Status)
            {
                RoleContext.Refresh();
            }
            return webResponse;
        }
    }

    public class RoleNodes
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string RoleName { get; set; }
    }
    public class UserPermissions
    {
        public int Id { get; set; }
        public int Pid { get; set; }
        public string Text { get; set; }
        public List<Sys_Actions> Actions { get; set; }
    }
}
