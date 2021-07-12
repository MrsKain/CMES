using Cnty.System.IRepositories;
using Cnty.System.IServices;
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.System.Services
{
    public partial class Sys_MenuService : ServiceBase<Sys_Menu, ISys_MenuRepository>, ISys_MenuService, IDependency
    {
        public Sys_MenuService(ISys_MenuRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISys_MenuService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_MenuService>(); }
        }
    }
}

