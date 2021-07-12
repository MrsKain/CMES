using System;
using Cnty.Core.Enums;

namespace Cnty.Core.Filters
{
    public class ApiActionPermissionAttribute : ActionPermissionAttribute
    {
        public ApiActionPermissionAttribute()
            : base(true)
        {
        }
        /// <summary>
        /// 限定角色访问
        /// </summary>
        /// <param name="roles"></param>
        public ApiActionPermissionAttribute(string roleId)
       : base(roleId, true)
        {
        }
        /// <summary>
        /// 限定角色访问
        /// </summary>
        /// <param name="roles"></param>
        public ApiActionPermissionAttribute(ActionRolePermission actionRolePermission)
         : base(actionRolePermission, true)
        {
           
        }

        public ApiActionPermissionAttribute(string tableName, ActionPermissionOptions tableAction, bool sysController = false)
            : base(tableName, tableAction, sysController, true)
        {
            
        }
        public ApiActionPermissionAttribute(string tableName, string roleIds, ActionPermissionOptions tableAction, bool sysController = false)
           : base(tableName, roleIds, tableAction, sysController, true)
        {
        }
        public ApiActionPermissionAttribute(ActionPermissionOptions tableAction)
        : base(tableAction, true)
        {

        }

    }

    public struct    ActionRolePermission
    {
        public const   string SuperAdmin = "00000000-0000-0000-0000-000000000000";
        public const   string Admin = "46ECE442-7E7F-4E52-8D2F-FEED9D6062B2";
        /// <summary>
        /// 角色ID为00000000-0000-0000-0000-000000000000
        /// </summary>
        //SuperAdmin = 1,
        //Admin = 2 
    }
}
