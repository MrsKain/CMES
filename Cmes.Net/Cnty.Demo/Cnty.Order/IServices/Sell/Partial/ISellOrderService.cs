/*
*所有关于SellOrder类的业务代码接口应在此处编写
*/
using System;
using Cnty.Core.BaseProvider;
using Cnty.Core.Utilities;
using Cnty.Entity.DomainModels;
namespace Cnty.Order.IServices
{
    public partial interface ISellOrderService
    {
        string GetServiceDate();

        WebResponseContent InsertDemo_1(SellOrder sellOrder);

         WebResponseContent DeleteDemo_1(Guid id);
    }
 }
