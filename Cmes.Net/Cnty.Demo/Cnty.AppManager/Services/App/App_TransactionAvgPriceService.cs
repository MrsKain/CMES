/*
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下App_TransactionAvgPriceService与IApp_TransactionAvgPriceService中编写
 */
using Cnty.AppManager.IRepositories;
using Cnty.AppManager.IServices;
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.AppManager.Services
{
    public partial class App_TransactionAvgPriceService : ServiceBase<App_TransactionAvgPrice, IApp_TransactionAvgPriceRepository>, IApp_TransactionAvgPriceService, IDependency
    {
        public App_TransactionAvgPriceService(IApp_TransactionAvgPriceRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IApp_TransactionAvgPriceService Instance
        {
           get { return AutofacContainerModule.GetService<IApp_TransactionAvgPriceService>(); }
        }
    }
}
