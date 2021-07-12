using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Cnty.Core.Enums;
using Cnty.Core.Extensions;

namespace Cnty.Core.Filters
{
    public class ActionPermissionAttribute : TypeFilterAttribute
    {
        public ActionPermissionAttribute(bool isApi = false)
            : base(typeof(ActionPermissionFilter))
        {
            Arguments = new object[] { new ActionPermissionRequirement() { IsApi = isApi } };
        }
        /// <summary>
        /// 限定角色访问
        /// </summary>
        /// <param name="roles"></param>
        public ActionPermissionAttribute(string roleId, bool isApi = false)
       : base(typeof(ActionPermissionFilter))
        {
            Arguments = new object[] { new ActionPermissionRequirement() { RoleIds = new string[] { roleId.ToString() }, IsApi = isApi } };
        }
        public ActionPermissionAttribute(ActionRolePermission actionRolePermission, bool isApi = false)
        : base(typeof(ActionPermissionFilter))
        {
            Array array = Enum.GetValues(typeof(ActionRolePermission));
            List<string> roles = new List<string>();
            foreach (ActionRolePermission item in array)
            {
                //if (actionRolePermission.HasFlag(item))
                //{
                    roles.Add(item.ToString());
                //}
            }
            Arguments = new object[] { new ActionPermissionRequirement() { RoleIds = roles.ToArray(), IsApi = isApi } };
        }
        /// <summary>
        /// 限定角色访问
        /// </summary>
        /// <param name="roles"></param>
        public ActionPermissionAttribute(string[] roleIds, bool isApi = false)
       : base(typeof(ActionPermissionFilter))
        {
            Arguments = new object[] { new ActionPermissionRequirement() { RoleIds = roleIds, IsApi = isApi } };
        }

        public ActionPermissionAttribute(string tableName, ActionPermissionOptions tableAction, bool sysController = false, bool isApi = false)
            : base(typeof(ActionPermissionFilter))
        {
            this.SetActionPermissionRequirement(tableName, tableAction, sysController, isApi);
        }

        public ActionPermissionAttribute(string tableName, string roleIds, ActionPermissionOptions tableAction, bool sysController = false, bool isApi = false)
           : base(typeof(ActionPermissionFilter))
        {
            this.SetActionPermissionRequirement(tableName, tableAction, (roleIds ?? "").Split(",").Select(x => x.ToString()).ToArray(), sysController, isApi);
        }

        public ActionPermissionAttribute(ActionPermissionOptions tableAction, bool isApi = false)
        : base(typeof(ActionPermissionFilter))
        {
            this.SetActionPermissionRequirement("", tableAction, true, isApi);
        }
        private void SetActionPermissionRequirement(string tableName, ActionPermissionOptions tableAction,
            string[] roleId, bool sysController = false, bool isApi = false)
        {
            Arguments = new object[] { new ActionPermissionRequirement() {
                 SysController=sysController,
                 TableAction=tableAction.ToString(),
                 TableName=tableName,
                 IsApi = isApi,
                 RoleIds=roleId
            } };
        }

        private void SetActionPermissionRequirement(string tableName, ActionPermissionOptions tableAction, bool sysController = false, bool isApi = false, Guid? roleId = null)
        {
            SetActionPermissionRequirement(tableName, tableAction, roleId == null ? null : new string[] { roleId.ToString() }, sysController, isApi);
        }
    }
}
