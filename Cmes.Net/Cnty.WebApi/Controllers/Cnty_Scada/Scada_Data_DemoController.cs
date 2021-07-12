/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Scada_Data_DemoController编写
 */
using Microsoft.AspNetCore.Mvc;
using Cnty.Core.Controllers.Basic;
using Cnty.Entity.AttributeManager;
using Cnty.Scada.IServices;
namespace Cnty.Scada.Controllers
{
    [Route("api/Scada_Data_Demo")]
    [PermissionTable(Name = "Scada_Data_Demo")]
    public partial class Scada_Data_DemoController : ApiBaseController<IScada_Data_DemoService>
    {
        public Scada_Data_DemoController(IScada_Data_DemoService service)
        : base(service)
        {
        }
    }
}

