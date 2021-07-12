/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹SellOrderController编写
 */
using Microsoft.AspNetCore.Mvc;
using Cnty.Core.Controllers.Basic;
using Cnty.Entity.AttributeManager;
using Cnty.Order.IServices;
namespace Cnty.Order.Controllers
{
    [Route("api/SellOrder")]
    [PermissionTable(Name = "SellOrder")]
    public partial class SellOrderController : ApiBaseController<ISellOrderService>
    {
        private ISellOrderService _service { get; set; }
        public SellOrderController(ISellOrderService service)
        : base(service)
        {
            _service = service;
        }
    }
}

