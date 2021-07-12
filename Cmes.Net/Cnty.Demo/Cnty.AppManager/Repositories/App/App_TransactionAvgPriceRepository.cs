/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹App_TransactionAvgPriceRepository编写代码
 */
using Cnty.AppManager.IRepositories;
using Cnty.Core.BaseProvider;
using Cnty.Core.EFDbContext;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.AppManager.Repositories
{
    public partial class App_TransactionAvgPriceRepository : RepositoryBase<App_TransactionAvgPrice> , IApp_TransactionAvgPriceRepository
    {
    public App_TransactionAvgPriceRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IApp_TransactionAvgPriceRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IApp_TransactionAvgPriceRepository>(); } }
    }
}
