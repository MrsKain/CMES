using Cnty.System.IRepositories;
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Core.EFDbContext;
using Cnty.Entity.DomainModels;

namespace Cnty.System.Repositories
{
    public partial class Sys_MenuRepository : RepositoryBase<Sys_Menu>, ISys_MenuRepository
    {
        public Sys_MenuRepository(VOLContext dbContext)
        : base(dbContext)
        {

        }
        public static ISys_MenuRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_MenuRepository>(); }
        }
    }
}

