using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Cnty.Core.Extensions;
using Cnty.Core.Filters;

namespace Cnty.Core.ObjectActionValidator
{
    public class NullObjectModelValidator : IObjectModelValidator
    {

        public void Validate(
           ActionContext actionContext,
           ValidationStateDictionary validationState,
           string prefix,
           object model)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                actionContext.ModelValidator(prefix, model);
                return;
            }
        }
    }
}
