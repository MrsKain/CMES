using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cnty.Builder.IServices;
using Cnty.Core.Controllers.Basic;
using Microsoft.AspNetCore.Mvc;

namespace Cnty.Builder.Controllers
{
    public partial class Sys_TableInfoController : WebBaseController<ISys_TableInfoService>
    {
        public Sys_TableInfoController(ISys_TableInfoService service)
        : base("Builder","Core","Sys_TableInfo", service)
        {
        }
    }
}

