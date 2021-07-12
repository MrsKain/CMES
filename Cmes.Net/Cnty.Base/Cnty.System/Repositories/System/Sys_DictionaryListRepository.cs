/*
 *Date：2018-07-01
 * 此代码由框架生成，请勿随意更改
 */
using Cnty.System.IRepositories;
using Cnty.Core.BaseProvider;
using Cnty.Core.EFDbContext;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.System.Repositories
{
    public partial class Sys_DictionaryListRepository : RepositoryBase<Sys_DictionaryList>, ISys_DictionaryListRepository
    {
        public Sys_DictionaryListRepository(VOLContext dbContext)
        : base(dbContext)
        {

        }
        public static ISys_DictionaryListRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISys_DictionaryListRepository>(); }
        }
    }
}

