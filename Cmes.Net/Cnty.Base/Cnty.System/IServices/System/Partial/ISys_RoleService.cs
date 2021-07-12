﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnty.Core.Utilities;
using Cnty.Entity.DomainModels;
using Cnty.System.Services;

namespace Cnty.System.IServices
{
    public partial interface ISys_RoleService
    {

        Task<WebResponseContent> GetUserTreePermission(Guid role_Id);

        Task<WebResponseContent> GetCurrentUserTreePermission();

        Task<WebResponseContent> GetCurrentTreePermission();

        Task<WebResponseContent> SavePermission(List<UserPermissions> userPermissions, Guid roleId);
        /// <summary>
        /// 获取角色下所有的角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<RoleNodes>> GetAllChildrenAsync(Guid roleId);

        /// <summary>
        /// 获取角色下所有的角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<RoleNodes> GetAllChildren(Guid roleId);

        /// <summary>
        /// 获取角色下所有的角色Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<string>> GetAllChildrenRoleIdAsync(Guid roleId);

        List<string> GetAllChildrenRoleId(Guid roleId);
        /// <summary>
        /// 获取当前角色下的所有角色包括自己的角色Id
        /// </summary>
        /// <returns></returns>
        List<Guid> GetAllChildrenRoleIdAndSelf();

    }
}

