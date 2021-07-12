using Cnty.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cnty.Core.Extensions
{
    public static class ServiceProviderManagerExtension
    {
        public static object GetService(this Type serviceType)
        {
           // HttpContext.Current.RequestServices.GetRequiredService<T>(serviceType);
            return Utilities.HttpContext.Current.RequestServices.GetService(serviceType);
        }

    }
}
