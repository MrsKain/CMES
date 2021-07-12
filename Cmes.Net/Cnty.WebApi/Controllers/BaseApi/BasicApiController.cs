using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cnty.WebApi.Controllers.BaseApi
{
    [ApiController]
    public class BasicApiController : Controller
    {   /// <summary>
        /// 构造函数
        /// </summary>
        public BasicApiController() : base() { }

        public override OkResult Ok()
        {
            return base.Ok();
        }
        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            return base.Ok(value);
        }
        
    }
}
