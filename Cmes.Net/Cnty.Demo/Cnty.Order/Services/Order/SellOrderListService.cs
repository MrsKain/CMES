/*
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下SellOrderListService与ISellOrderListService中编写
 */
using Cnty.Order.IRepositories;
using Cnty.Order.IServices;
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.Order.Services
{
    public partial class SellOrderListService : ServiceBase<SellOrderList, ISellOrderListRepository>, ISellOrderListService, IDependency
    {
        public SellOrderListService(ISellOrderListRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISellOrderListService Instance
        {
           get { return AutofacContainerModule.GetService<ISellOrderListService>(); }
        }
    }
}
