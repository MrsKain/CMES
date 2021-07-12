/*
 *Author：
 *Contact：
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Rgm_In_DataService与IRgm_In_DataService中编写
 */
using Cnty.Rgm.IRepositories;
using Cnty.Rgm.IServices;
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.Rgm.Services
{
    public partial class Rgm_In_DataService : ServiceBase<Rgm_In_Data, IRgm_In_DataRepository>
    , IRgm_In_DataService, IDependency
    {
    public Rgm_In_DataService(IRgm_In_DataRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IRgm_In_DataService Instance
    {
      get { return AutofacContainerModule.GetService<IRgm_In_DataService>(); } }
    }
 }
