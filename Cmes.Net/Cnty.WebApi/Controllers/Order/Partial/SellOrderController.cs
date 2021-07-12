/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("SellOrder",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Cnty.Core.Filters;
using Cnty.Core.Utilities;
using Cnty.Entity.DomainModels;
using Cnty.Order.Repositories;
using Cnty.WebApi.Controllers.BaseApi;

namespace Cnty.Order.Controllers
{
    public partial class SellOrderController
    {
        [HttpPost]
        [ApiActionPermission("SellOrder", Core.Enums.ActionPermissionOptions.Search)]
        [Route("getServiceDate"), AllowAnonymous]//FixedToken请求此接口只要token合法就能能过//AllowAnonymous 
        public IActionResult GetServiceDate()
        {
            return Ok(_service.GetServiceDate());
        }
        /// <summary>
        /// 异步接口
        /// </summary>
        /// <param name="sellOrder"></param>
        /// <returns></returns>
        [HttpPost]
        //[ApiActionPermission("SellOrder", Core.Enums.ActionPermissionOptions.Search)]
        [Route("InsertDemoData_1"), AllowAnonymous]
        public async Task<IActionResult> InsertDemoData_1(SellOrder sellOrder)
        {
               var result = new WebResponseContent();
             result = await Task.Run(() => _service.InsertDemo_1(sellOrder));
            return Ok(result);
        }
       
        /// <summary>
        /// 同步接口
        /// </summary>
        /// <param name="sellOrder"></param>
        /// <returns></returns>
        [HttpPost]
       // [ApiActionPermission("SellOrder", Core.Enums.ActionPermissionOptions.Search)]
        [Route("InsertDemoData_2"), AllowAnonymous]
        public  IActionResult InsertDemoData_2([FromBody] SellOrder sellOrder)
        {
            var result = new WebResponseContent();
            result =  _service.InsertDemo_1(sellOrder);
            _service.SaveChange();
            return Json(result);
        }
        /// <summary>
        /// 异步接口（Model写入）
        /// </summary>
        /// <param name="sellOrder"></param>
        /// <returns></returns>
        [HttpPost]
        //[ApiActionPermission("SellOrder", Core.Enums.ActionPermissionOptions.Search)]
        [Route("InsertDemoData_3"), AllowAnonymous]
        public async Task<ActionResult> InsertDemoData_3([FromBody] SellOrder sellOrder)
        {
            var result = new WebResponseContent();

           await Task.Run(() => _service.InsertDemo_1(sellOrder));       
           return Json(result.OK("写入成功"));
        }
        /// <summary>
        /// 删除 逻辑删除
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpPost]
       // [ApiActionPermission("SellOrder", Core.Enums.ActionPermissionOptions.Search)]
        [Route("DeleteDemoData"), AllowAnonymous]
        public async Task<ActionResult> DeleteDemoData(Guid id)
        {
            var result = new Core.Utilities.WebResponseContent();
            result = await Task.Run(() => _service.DeleteDemo_1(id));
            result.Message = "删除成功";
            return Json(result);
        }
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        //[ApiActionPermission("SellOrder", Core.Enums.ActionPermissionOptions.Search)]
        [Route("GetDemoData"), AllowAnonymous]
        public async Task<IActionResult> GetDemoData(Guid id)
        {
            var result = new Core.Utilities.WebResponseContent();
            var repository = Repositories.SellOrderRepository.Instance;
            result.Data = await Task.Run(() => repository.Find(k => k.Id == id));                
            return Json(result);
        }
        /// <summary>
        /// 获取多条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        //[ApiActionPermission("SellOrder", Core.Enums.ActionPermissionOptions.Search)]
        [Route("GetDemoDataList"), AllowAnonymous]
        public async Task<IActionResult> GetDemoDataList()
        {
            var result = new Core.Utilities.WebResponseContent();
            var repository = Repositories.SellOrderRepository.Instance;      
            result.Data = await Task.Run(() => repository.Find(k => k.IsDelete == 0));
            return Json(result);
        }
    }
}
