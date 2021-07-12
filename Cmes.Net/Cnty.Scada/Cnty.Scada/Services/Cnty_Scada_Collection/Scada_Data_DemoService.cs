/*
 *Author：
 *Contact：
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Scada_Data_DemoService与IScada_Data_DemoService中编写
 */
using Cnty.Scada.IRepositories;
using Cnty.Scada.IServices;
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.Scada.Services
{
    public partial class Scada_Data_DemoService : ServiceBase<Scada_Data_Demo, IScada_Data_DemoRepository>
    , IScada_Data_DemoService, IDependency
    {
    public Scada_Data_DemoService(IScada_Data_DemoRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IScada_Data_DemoService Instance
    {
      get { return AutofacContainerModule.GetService<IScada_Data_DemoService>(); } }
    }
 }
