using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cnty.Core.BaseProvider;
using Cnty.Entity.DomainModels;
using Cnty.Core.Extensions.AutofacManager;
namespace Cnty.System.IRepositories
{
    public partial interface ISys_LogRepository : IDependency,IRepository<Sys_Log>
    {
    }
}

