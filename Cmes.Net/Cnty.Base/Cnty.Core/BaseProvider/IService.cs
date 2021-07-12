
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Cnty.Core.CacheManager;
using Cnty.Core.Model;
using Cnty.Core.Utilities;
using Cnty.Entity.DomainModels;
using Cnty.Entity.SystemModels;

namespace Cnty.Core.BaseProvider
{
    public interface IService<T> where T : BaseEntity,new()
    {
      
        ICacheService CacheContext { get; }
        Microsoft.AspNetCore.Http.HttpContext Context { get; }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pageData"></param>
        /// <returns></returns>
        PageGridData<T> GetPageData(PageDataOptions pageData);

        object GetDetailPage(PageDataOptions pageData);

        WebResponseContent Upload(List<IFormFile> files);

        WebResponseContent DownLoadTemplate();

        WebResponseContent Import(List<IFormFile> files);
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="pageData"></param>
        /// <returns></returns>
        WebResponseContent Export(PageDataOptions pageData);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="saveDataModel">主表与子表的数据</param>
        /// <returns></returns>
        WebResponseContent Add(SaveModel saveDataModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">保存的实体</param>
        /// <param name="validationEntity">是否对实体进行校验</param>
        /// <returns></returns>
        WebResponseContent AddEntity(T entity, bool validationEntity = true);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDetail"></typeparam>
        /// <param name="entity">保存的实体</param>
        /// <param name="list">保存的明细</param>
        /// <param name="validationEntity">是否对实体进行校验</param>
        /// <returns></returns>
        WebResponseContent Add<TDetail>(T entity, List<TDetail> list = null, bool validationEntity = true) where TDetail : class;
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="saveDataModel">主表与子表的数据</param>
        /// <returns></returns>
        WebResponseContent Update(SaveModel saveDataModel);


        /// <summary>
        /// 删除数据 物理删除慎用
        /// </summary>
        /// <param name="keys">删除的主键</param>
        /// <param name="delList">是否删除对应明细(默认会删除明细)</param>
        /// <returns></returns>
        WebResponseContent Del(object[] keys, bool delList = true);

        WebResponseContent Audit(object[] id, int? auditStatus, string auditReason);


        (string, T, bool) ApiValidate(string bizContent, Expression<Func<T, object>> expression = null);


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="bizContent"></param>
        /// <param name="expression">对指属性验证格式如：x=>new { x.UserName,x.Value }</param>
        /// <returns>(string,TInput, bool) string:返回验证消息,TInput：bizContent序列化后的对象,bool:验证是否通过</returns>
        (string, TInput, bool) ApiValidateInput<TInput>(string bizContent, Expression<Func<TInput, object>> expression);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="bizContent"></param>
        /// <param name="expression">对指属性验证格式如：x=>new { x.UserName,x.Value }</param>
        /// <param name="validateExpression">对指定的字段只做合法性判断比如长度是是否超长</param>
        /// <returns>(string,TInput, bool) string:返回验证消息,TInput：bizContent序列化后的对象,bool:验证是否通过</returns>
        (string, TInput, bool) ApiValidateInput<TInput>(string bizContent, Expression<Func<TInput, object>> expression, Expression<Func<TInput, object>> validateExpression);


        /// <summary>
        /// 将数据源映射到新的数据中,List<TSource>映射到List<TResult>或TSource映射到TResult
        /// 目前只支持Dictionary或实体类型
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="resultExpression">只映射返回对象的指定字段</param>
        /// <param name="sourceExpression">只映射数据源对象的指定字段</param>
        /// 过滤条件表达式调用方式：List表达式x => new { x[0].MenuName, x[0].Menu_Id}，表示指定映射MenuName,Menu_Id字段
        ///  List<Sys_Menu> list = new List<Sys_Menu>();
        ///  list.MapToObject<List<Sys_Menu>, List<Sys_Menu>>(x => new { x[0].MenuName, x[0].Menu_Id}, null);
        ///  
        ///过滤条件表达式调用方式：实体表达式x => new { x.MenuName, x.Menu_Id}，表示指定映射MenuName,Menu_Id字段
        ///  Sys_Menu sysMenu = new Sys_Menu();
        ///  sysMenu.MapToObject<Sys_Menu, Sys_Menu>(x => new { x.MenuName, x.Menu_Id}, null);
        /// <returns></returns>
        TResult MapToEntity<TSource, TResult>(TSource source, Expression<Func<TResult, object>> resultExpression,
           Expression<Func<TSource, object>> sourceExpression = null) where TResult : class;

        /// <summary>
        /// 将一个实体的赋到另一个实体上,应用场景：
        /// 两个实体，a a1= new a();b b1= new b();  a1.P=b1.P; a1.Name=b1.Name;
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="result"></param>
        /// <param name="expression">指定对需要的字段赋值,格式x=>new {x.Name,x.P},返回的结果只会对Name与P赋值</param>
        void MapValueToEntity<TSource, TResult>(TSource source, TResult result, Expression<Func<TResult, object>> expression = null) where TResult : class;

        #region Entity 操作

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keys">删除的主键</param>
        /// <param name="delList">是否删除对应明细(默认会删除明细)</param>
        /// <returns></returns>
        WebResponseContent DelEntity(object[] keys);

         T GetEntity(Expression<Func<T, bool>> where, Expression<Func<OrderExpression<T>, object>> order = null);
        #endregion
        #region 增删改
        /// <summary>
        /// 插入实体记录
        /// </summary>
        /// <param name="model"> 实体对象 </param>
        /// <returns> 操作影响的行数 </returns>
        void Insert(T model);
        /// <summary>
        /// 插入实体记录
        /// </summary>
        /// <param name="models"> 实体对象 </param>
        /// <returns> 操作影响的行数 </returns>
        void Insert(IList<T> models);
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="dt"></param>
        void BatchInsert(DataTable dt);   
        #endregion
        #region 查询
        /// <summary>
        /// 查找指定主键的实体记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isDelete"></param>
        /// <returns></returns>
        T GetById(Guid id, bool? isDelete = false);
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="conditions">查询条件</param>
        /// <param name="sorts">排序条件</param>
        /// <param name="isDelete">是否删除</param>
        /// <returns></returns>
        IList<T> GetDatas(IList<ConditionInfo> conditions = null, IList<SortInfo> sorts = null, bool? isDelete = false);
        /// <summary>
        /// 获取前面的几条数据
        /// </summary>
        /// <param name="top">第几条数据</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="sorts">排序条件</param>
        /// <param name="isDelete">是否删除</param>
        /// <returns></returns>
        IList<T> GetTopDatas(int top = 10, IList<ConditionInfo> conditions = null, IList<SortInfo> sorts = null, bool? isDelete = false);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="conditions">查询条件</param>
        /// <param name="sorts">排序条件</param>
        /// <param name="page">分页信息</param>
        /// <param name="isDelete">是否删除</param>
        void GetPageDatas(IList<ConditionInfo> conditions, IList<SortInfo> sorts, PageInfo<T> page, bool? isDelete = false);

        /// <summary>
        /// sql语句分页查询
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="sorts"></param>
        /// <param name="page"></param>
        /// <param name="isDelete"></param>
        void GetPageDatasBySql(IList<ConditionInfo> conditions, IList<SortInfo> sorts, PageInfo<dynamic> page, bool? isDelete = false);

        /// <summary>
        /// 获取条数
        /// </summary>
        /// <param name="conditions">查询条件</param>
        /// <param name="isDelete">是否删除</param>
        /// <returns></returns>
        int GetCount(IList<ConditionInfo> conditions = null, bool? isDelete = false);

        /// <summary>
        /// 执行SQL语句获取数据
        /// </summary>
        /// <param name="SQL">获取数据SQL</param>
        /// <param name="param">参数对象</param>
        /// <returns></returns>
        IList<dynamic> GetDataExecSQL(string SQL, object param);

 

        #endregion
        #region 新开接口
        /// <summary>
        /// 获取 T 单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        IEnumerable<T> GetEntityList(Expression<Func<T, bool>> where = null, Expression<Func<OrderExpression<T>, object>> order = null, int? top = null);
        /// <summary>
        /// 获取 数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        int GetEntityCount(Expression<Func<T, bool>> where = null);
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="where"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        int UpdateEntity(Expression<Func<T>> expression, Expression<Func<T, bool>> where);
 

        /// <summary>
        /// 判断记录存在
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        bool CheckIsExists(Expression<Func<T, bool>> where = null);
         void SaveChange();



         void ClearSaveChange();
       

        #endregion
    }
}
