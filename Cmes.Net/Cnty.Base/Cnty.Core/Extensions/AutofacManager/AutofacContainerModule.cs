using Cnty.Core.Extensions;
using System;
using Cnty.Core.Configuration;

namespace Cnty.Core.Extensions.AutofacManager
{
    public class AutofacContainerModule
    {
        public static TService GetService<TService>() where TService:class
        {
            return typeof(TService).GetService() as TService;
        }
    }
}
