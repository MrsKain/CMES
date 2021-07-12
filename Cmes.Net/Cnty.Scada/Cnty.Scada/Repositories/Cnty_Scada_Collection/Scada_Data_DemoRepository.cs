/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Scada_Data_DemoRepository编写代码
 */
using Cnty.Scada.IRepositories;
using Cnty.Core.BaseProvider;
using Cnty.Core.EFDbContext;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.Scada.Repositories
{
    public partial class Scada_Data_DemoRepository : RepositoryBase<Scada_Data_Demo> , IScada_Data_DemoRepository
    {
    public Scada_Data_DemoRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IScada_Data_DemoRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IScada_Data_DemoRepository>(); } }
    }
}
