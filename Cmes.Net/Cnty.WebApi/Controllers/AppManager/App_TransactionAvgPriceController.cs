/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹App_TransactionAvgPriceController编写
 */
using Microsoft.AspNetCore.Mvc;
using Cnty.AppManager.IServices;
using Cnty.Core.Controllers.Basic;
using Cnty.Entity.AttributeManager;

namespace Cnty.AppManager.Controllers
{
    [Route("api/App_TransactionAvgPrice")]
    [PermissionTable(Name = "App_TransactionAvgPrice")]
    public partial class App_TransactionAvgPriceController : ApiBaseController<IApp_TransactionAvgPriceService>
    {
        public App_TransactionAvgPriceController(IApp_TransactionAvgPriceService service)
        : base("AppManager","App","App_TransactionAvgPrice", service)
        {
        }
    }
}

