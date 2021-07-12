using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cnty.Core.Controllers.Basic;
using Cnty.Core.Enums;
using Cnty.Core.Extensions;
using Cnty.Core.Filters;
using Cnty.Core.ManageUser;
using Cnty.Core.UserManager;
using Cnty.Core.Utilities;
using Cnty.Entity.AttributeManager;
using Cnty.Entity.DomainModels;
using Cnty.System.IServices;
using Cnty.System.Repositories;
using Cnty.System.Services;

namespace Cnty.System.Controllers
{
    [Route("api/role")]
    public partial class Sys_RoleController
    {
        [HttpPost, Route("getCurrentTreePermission")]
        [ApiActionPermission(ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetCurrentTreePermission()
        {
            return Json(await Service.GetCurrentTreePermission());
        }

        [HttpPost, Route("getUserTreePermission")]
        [ApiActionPermission(ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetUserTreePermission(string roleId)
        {
            return Json(await Service.GetUserTreePermission(new Guid(roleId)));
        }

        [HttpPost, Route("savePermission")]
        [ApiActionPermission(ActionPermissionOptions.Update)]
        public async Task<IActionResult> SavePermission([FromBody] List<UserPermissions> userPermissions, Guid roleId)
        {
            return Json(await Service.SavePermission(userPermissions, roleId));
        }

        /// <summary>
        /// 获取当前角色下的所有角色 
        /// </summary>
        /// <returns></returns>

        [HttpPost, Route("getUserChildRoles")]
        [ApiActionPermission(ActionPermissionOptions.Search)]
        public IActionResult GetUserChildRoles()
        {
            Guid roleId = UserContext.Current.RoleId;
            var data = RoleContext.GetAllChildren(UserContext.Current.RoleId);

            if (UserContext.Current.IsSuperAdmin)
            {
                return Json(WebResponseContent.Instance.OK(null, data));
            }
            //不是超级管理，将自己的角色查出来，在树形菜单上作为根节点
            var self = Sys_RoleRepository.Instance.FindAsIQueryable(x => x.Id == roleId)
                 .Select(s => new Cnty.Core.UserManager.RoleNodes()
                 {
                     Id = s.Id,
                     ParentId = roleId,//将自己的角色作为root节点
                     RoleName = s.RoleName
                 }).ToList();
            data.AddRange(self);
            return Json(WebResponseContent.Instance.OK(null, data));
        }



        /// <summary>
        /// treetable 获取子节点数据(2021.05.02)
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        [ApiActionPermission(ActionPermissionOptions.Search)]
        [HttpPost, Route("GetPageData")]
        public override ActionResult GetPageData([FromBody] PageDataOptions loadData)
        {
            //获取根节点数据
            if (loadData.Value.GetInt() == 1)
            {
                return GetTreeTableRootData(loadData).Result;
            }
            return base.GetPageData(loadData);
        }

        /// <summary>
        /// treetable 获取子节点数据(2021.05.02)
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("getTreeTableRootData")]
        [ApiActionPermission(ActionPermissionOptions.Search)]
        public async Task<ActionResult> GetTreeTableRootData([FromBody] PageDataOptions options)
        {
            var query = Sys_RoleRepository.Instance.FindAsIQueryable(x => x.ParentId.ToString() == "11111111-1111-1111-1111-111111111111");
            var rows = await query.TakeOrderByPage(options.Page, options.Rows)
                .OrderBy(x => x.Role_Id).Select(s => new
                {
                    s.Role_Id,
                    s.ParentId,
                    s.RoleName,
                    s.DeptName,
                    s.Dept_Id,
                    s.Enable,
                    s.CreateDate,
                    s.Creater,
                    s.Modifier,
                    s.ModifyDate,
                    s.OrderNo,
                    hasChildren = true
                }).ToListAsync();
            return JsonNormal(new { total = await query.CountAsync(), rows });
        }

        /// <summary>
        ///treetable 获取子节点数据(2021.05.02)
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("getTreeTableChildrenData")]
        [ApiActionPermission(ActionPermissionOptions.Search)]
        public async Task<ActionResult> GetTreeTableChildrenData(Guid roleId)
        {
            var roleRepository = Sys_RoleRepository.Instance.FindAsIQueryable(x => true);
            var rows = await roleRepository.Where(x => x.ParentId == roleId)
                .Select(s => new
                {
                    s.Role_Id,
                    s.ParentId,
                    s.RoleName,
                    s.DeptName,
                    s.Dept_Id,
                    s.Enable,
                    s.CreateDate,
                    s.Creater,
                    s.Modifier,
                    s.ModifyDate,
                    s.OrderNo,
                    hasChildren = roleRepository.Any(x => x.ParentId == s.Id)
                }).ToListAsync();
            return JsonNormal(new { rows });
        }

    }
}


