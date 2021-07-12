using System;
using System.Collections.Generic;
using System.Text;

namespace Cnty.Core.Model
{
    /// <summary>
    /// 分页条件
    /// </summary>
    public class PageInfo<T>
    {
        public PageInfo()
        {
            Datas = new List<T>();
        }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 当前页数据
        /// </summary>
        public IList<T> Datas { get; set; }
    }
}
