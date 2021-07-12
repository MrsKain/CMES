/*
 *所有关于SellOrderList类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*SellOrderListService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using Cnty.Core.BaseProvider;
using Cnty.Core.Extensions.AutofacManager;
using Cnty.Entity.DomainModels;
using System.Linq;
using Cnty.Core.Extensions;
using System;

namespace Cnty.Order.Services
{
    public partial class SellOrderListService
    {
    }
}
