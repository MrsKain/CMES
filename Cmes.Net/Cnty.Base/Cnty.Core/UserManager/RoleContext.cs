using System;
using System.Collections.Generic;
using System.Linq;
using Cnty.Core.CacheManager;
using Cnty.Core.DBManager;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Core.ManageUser;
using Cnty.Core.Services;
using Cnty.Entity.DomainModels;

namespace Cnty.Core.UserManager
{
    public static class RoleContext
    {

        private static object _RoleObj = new object();
        private static string _RoleVersionn = "";
        public const string Key = "inernalRole";

        private static List<RoleNodes> _roles { get; set; }
        public static List<RoleNodes> GetAllRoleId()
        {
            ICacheService cacheService = AutofacContainerModule.GetService<ICacheService>();
            //每次比较缓存是否更新过，如果更新则重新获取数据
            if (_roles != null && _RoleVersionn == cacheService.Get(Key))
            {
                return _roles;
            }
            lock (_RoleObj)
            {
                if (_RoleVersionn != "" && _roles != null && _RoleVersionn == cacheService.Get(Key)) return _roles;
                _roles = DBServerProvider.DbContext
                  .Set<Sys_Role>()
                   .Where(x => x.Enable == 1 && x.IsDelete==0)
                   .Select(s => new RoleNodes() { Id = s.Id, ParentId = s.ParentId, RoleName = s.RoleName })
             .ToList();

                string cacheVersion = cacheService.Get(Key);
                if (string.IsNullOrEmpty(cacheVersion))
                {
                    cacheVersion = DateTime.Now.ToString("yyyyMMddHHMMssfff");
                    cacheService.Add(Key, cacheVersion);
                }
                else
                {
                    _RoleVersionn = cacheVersion;
                }
            }
            return _roles;
        }

        public static void Refresh()
        {
            AutofacContainerModule.GetService<ICacheService>().Remove(Key);
        }
        /// <summary>
        /// 获取当前角色下的所有角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static List<RoleNodes> GetAllChildren(Guid roleId)
        {
            var roles = GetAllRoleId();
            if (UserContext.IsRoleIdSuperAdmin(roleId)) return roles;
            Dictionary<Guid, bool> completedRoles = new Dictionary<Guid, bool>();
            List<RoleNodes> rolesChildren = new List<RoleNodes>();
            return GetChildren(roles, rolesChildren, roleId, completedRoles);
        }
        public static List<Guid> GetAllChildrenIds(Guid roleId)
        {
            return GetAllChildren(roleId)?.Select(x => x.Id)?.ToList();
        }
        /// <summary>
        /// 递归获取所有子节点权限
        /// </summary>
        /// <param name="roleId"></param>
        private static List<RoleNodes> GetChildren(List<RoleNodes> roles, List<RoleNodes> rolesChildren, Guid roleId, Dictionary<Guid, bool> completedRoles)
        {
            roles.ForEach(x =>
            {
                if (x.ParentId == roleId)
                {
                    if (completedRoles.TryGetValue(roleId, out bool isWrite))
                    {
                        if (!isWrite)
                        {
                            Logger.Error($"获取子角色异常RoleContext,角色id:{roleId}");
                            completedRoles[roleId] = true;
                        }
                        return;
                    }
                    rolesChildren.Add(x);
                    completedRoles.Add(x.Id, false);
                    GetChildren(roles, rolesChildren, x.Id, completedRoles);
                }
            });
            return rolesChildren;
        }
        /// <summary>
        /// 获取当前角色下的所有用户
        /// </summary>
        /// <returns></returns>
        public static IQueryable<int> GetCurrentAllChildUser()
        {
            var roles = GetAllChildrenIds(UserContext.Current.RoleId);
            if (roles == null)
            {
                throw new Exception("未获取到当前角色");
            }
            return DBServerProvider.DbContext
                  .Set<Sys_User>()
                  .Where(u => roles.Contains(u.Role_Id)).Select(s => s.User_Id);

        }
    }
    public class RoleNodes
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string RoleName { get; set; }
    }
}
