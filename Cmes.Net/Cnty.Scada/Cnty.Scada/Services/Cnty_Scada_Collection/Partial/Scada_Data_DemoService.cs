/*
 *所有关于Scada_Data_Demo类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Scada_Data_DemoService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;
using System.Linq;
using Cnty.Core.Utilities;
using System.Linq.Expressions;
using Cnty.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Cnty.Scada.IRepositories;

namespace Cnty.Scada.Services
{
    public partial class Scada_Data_DemoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IScada_Data_DemoRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Scada_Data_DemoService(
            IScada_Data_DemoRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
  }
}
