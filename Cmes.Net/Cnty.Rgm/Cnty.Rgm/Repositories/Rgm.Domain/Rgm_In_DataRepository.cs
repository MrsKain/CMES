/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Rgm_In_DataRepository编写代码
 */
using Cnty.Rgm.IRepositories;
using Cnty.Core.BaseProvider;
using Cnty.Core.EFDbContext;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;

namespace Cnty.Rgm.Repositories
{
    public partial class Rgm_In_DataRepository : RepositoryBase<Rgm_In_Data> , IRgm_In_DataRepository
    {
    public Rgm_In_DataRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IRgm_In_DataRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IRgm_In_DataRepository>(); } }
    }
}
