using System;
using System.Collections.Generic;
using System.Text;

namespace Cnty.Core.Model
{
    /// <summary>
    /// 基础业务模型
    /// </summary>
    public class BaseInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseInfo()
        {
            CreateDt = DateTime.Now;
            UpdateDt = DateTime.Now;
        }
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string Creater { get; set; } = string.Empty;
        /// <summary>
        /// 创建用户
        /// </summary>
        public Guid CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDt { get; set; }
        /// <summary>
        /// 更新用户
        /// </summary>
        public string Updater { get; set; } = string.Empty;
        /// <summary>
        /// 更新用户
        /// </summary>
        public Guid UpdateUserId { get; set; }
        /// <summary>
        /// 更新时间 
        /// </summary>
        public DateTime UpdateDt { get; set; }
    }
}
