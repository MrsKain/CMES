using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cnty.Core.Controllers.Basic;
using Cnty.Core.Extensions;
using Cnty.Core.Filters;
using Cnty.System.IServices;

namespace Cnty.System.Controllers
{
    [Route("api/Sys_Dictionary")]
    public partial class Sys_DictionaryController : ApiBaseController<ISys_DictionaryService>
    {
        public Sys_DictionaryController(ISys_DictionaryService service)
        : base("System", "System", "Sys_Dictionary", service)
        {
        }
    }
}
