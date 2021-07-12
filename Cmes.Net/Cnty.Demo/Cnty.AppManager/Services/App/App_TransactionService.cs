/*
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下App_TransactionService与IApp_TransactionService中编写
 */
using Cnty.AppManager.IRepositories;
using Cnty.AppManager.IServices;
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.AppManager.Services
{
    public partial class App_TransactionService : ServiceBase<App_Transaction, IApp_TransactionRepository>, IApp_TransactionService, IDependency
    {
        public App_TransactionService(IApp_TransactionRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IApp_TransactionService Instance
        {
           get { return AutofacContainerModule.GetService<IApp_TransactionService>(); }
        }
    }
}
