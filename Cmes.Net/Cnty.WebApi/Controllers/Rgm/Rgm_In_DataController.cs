/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Rgm_In_DataController编写
 */
using Microsoft.AspNetCore.Mvc;
using Cnty.Core.Controllers.Basic;
using Cnty.Entity.AttributeManager;
using Cnty.Rgm.IServices;
namespace Cnty.Rgm.Controllers
{
    [Route("api/Rgm_In_Data")]
    [PermissionTable(Name = "Rgm_In_Data")]
    public partial class Rgm_In_DataController : ApiBaseController<IRgm_In_DataService>
    {
    public Rgm_In_DataController(IRgm_In_DataService service)
    : base(service)
    {
    }
    }
    }

