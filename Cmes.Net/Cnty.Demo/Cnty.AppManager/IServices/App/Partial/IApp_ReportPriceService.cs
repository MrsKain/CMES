/*
*所有关于App_ReportPrice类的业务代码接口应在此处编写
*/
using System.Threading.Tasks;
using Cnty.Core.BaseProvider;
using Cnty.Core.Utilities;
using Cnty.Entity.DomainModels;
namespace Cnty.AppManager.IServices
{
    public partial interface IApp_ReportPriceService
    {
        /// <summary>
        /// 获取table1的数据
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        Task<object> GetTable1Data(PageDataOptions loadData);


        /// <summary>
        /// 获取table2的数据
        /// </summary>
        /// <param name="loadData"></param>
        /// <returns></returns>
        Task<object> GetTable2Data(PageDataOptions loadData);
    }
 }
