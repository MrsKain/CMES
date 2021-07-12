using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cnty.Core.Controllers.Basic;
using Cnty.Core.Enums;
using Cnty.Core.Filters;
using Cnty.Entity.AttributeManager;
using Cnty.Entity.DomainModels;
using Cnty.System.IServices;

namespace Cnty.System.Controllers
{
    [Route("api/Sys_Role")]
    [PermissionTable(Name = "Sys_Role")]
    public partial class Sys_RoleController : ApiBaseController<ISys_RoleService>
    {
        public Sys_RoleController(ISys_RoleService service)
        : base("System", "System", "Sys_Role", service)
        {

        }
    }
}


