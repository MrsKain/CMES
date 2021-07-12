using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Cnty.Core.Enums;
using Cnty.Core.Extensions;
using Cnty.Core.ObjectActionValidator;
using Cnty.Core.Services;
using Cnty.Core.Utilities;

namespace Cnty.Core.Filters
{
    public class ActionExecuteFilter : IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //验证方法参数
            context.ActionParamsValidator();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}