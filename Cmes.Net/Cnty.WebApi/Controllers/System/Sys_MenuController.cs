using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cnty.Core.Controllers.Basic;
using Cnty.Core.Enums;
using Cnty.Core.Filters;
using Cnty.Entity.DomainModels;
using Cnty.System.IServices;

namespace Cnty.System.Controllers
{
    [Route("api/menu")]
    [ApiController, JWTAuthorize()]
    public partial class Sys_MenuController : ApiBaseController<ISys_MenuService>
    {
        private ISys_MenuService _service { get; set; }
        public Sys_MenuController(ISys_MenuService service) :
            base("System", "System", "Sys_Menu", service)
        {
            _service = service;
        } 
    }
}
