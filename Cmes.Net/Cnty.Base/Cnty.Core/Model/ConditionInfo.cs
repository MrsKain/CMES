using System;
using System.Collections.Generic;
using System.Text;
using Cnty.Core.Enums;

namespace Cnty.Core.Model
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class ConditionInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ConditionInfo()
        {
            this.Operator = ConditionOper.Equal;
            this.Relation = ConditionRelation.And;
            this.GroupRelation = ConditionRelation.And;
            this.IsQuery = true;
        }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public ConditionOper Operator { get; set; }
        /// <summary>
        /// 操作关系
        /// </summary>
        public ConditionRelation Relation { get; set; }
        /// <summary>
        /// 字段的类型
        /// </summary>
        public DataType DataType { get; set; }
        /// <summary>
        /// 分组
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// 分组间的关系
        /// </summary>
        public ConditionRelation GroupRelation { get; set; }
        /// <summary>
        /// 表别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 比较值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 索引号
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 是否查询
        /// </summary>
        public bool IsQuery { get; set; }

    }
}
