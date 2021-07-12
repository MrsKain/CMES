/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹App_NewsController编写
 */
using Microsoft.AspNetCore.Mvc;
using Cnty.Core.Controllers.Basic;
using Cnty.Entity.AttributeManager;
using Cnty.AppManager.IServices;
namespace Cnty.AppManager.Controllers
{
    [Route("api/App_News")]
    [PermissionTable(Name = "App_News")]
    public partial class App_NewsController : ApiBaseController<IApp_NewsService>
    {
        public App_NewsController(IApp_NewsService service)
        : base(service)
        {
        }
    }
}

