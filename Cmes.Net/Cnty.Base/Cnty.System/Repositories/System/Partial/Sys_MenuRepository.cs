using Cnty.System.IRepositories;
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Core.EFDbContext;
using Cnty.Entity.DomainModels;

namespace Cnty.System.Repositories
{
    public partial class Sys_MenuRepository
    {
        public override VOLContext DbContext => base.DbContext;
    }
}

