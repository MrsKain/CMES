/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹App_TransactionController编写
 */
using Microsoft.AspNetCore.Mvc;
using Cnty.AppManager.IServices;
using Cnty.Core.Controllers.Basic;
using Cnty.Entity.AttributeManager;

namespace Cnty.AppManager.Controllers
{
    [Route("api/App_Transaction")]
    [PermissionTable(Name = "App_Transaction")]
    public partial class App_TransactionController : ApiBaseController<IApp_TransactionService>
    {
        public App_TransactionController(IApp_TransactionService service)
        : base("AppManager","App","App_Transaction", service)
        {
        }
    }
}

