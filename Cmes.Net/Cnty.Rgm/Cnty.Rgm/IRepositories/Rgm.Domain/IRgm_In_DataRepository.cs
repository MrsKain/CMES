/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹IRgm_In_DataRepository编写接口
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cnty.Core.BaseProvider;
using Cnty.Entity.DomainModels;
using Cnty.Core.Extensions.AutofacManager;
namespace Cnty.Rgm.IRepositories
{
    public partial interface IRgm_In_DataRepository : IDependency,IRepository<Rgm_In_Data>
    {
    }
}