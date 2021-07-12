using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnty.Core.Utilities;
using Cnty.Entity.DomainModels;

namespace Cnty.System.IServices
{
    public partial interface ISys_MenuService
    {
        Task<object> GetMenu();
        List<Sys_Menu> GetCurrentMenuList();

        List<Sys_Menu> GetUserMenuList(Guid roleId);

        Task<object> GetCurrentMenuActionList();

        Task<object> GetMenuActionList(Guid roleId);
        Task<WebResponseContent> Save(Sys_Menu menu);

        Task<object> GetTreeItem(int menuId);
    }
}

