using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cnty.Core.Enums
{
    /// <summary>
    /// 查询操作
    /// </summary>
    public enum ConditionOper
    {
        /// <summary>
        /// 等于
        /// </summary>
        [Description("等于")]
        Equal = 1,
        /// <summary>
        /// 不等于
        /// </summary>
        [Description("不等于")]
        Unequal,
        /// <summary>
        /// 大于
        /// </summary>
        [Description("大于")]
        GreaterThan,
        /// <summary>
        /// 大于等于
        /// </summary>
        [Description("大于等于")]
        GreaterThanEqual,
        /// <summary>
        /// 小于等于
        /// </summary>
        [Description("小于等于")]
        LessThanEqual,
        /// <summary>
        /// 小于
        /// </summary>
        [Description("小于")]
        LessThan,
        /// <summary>
        /// 左模糊
        /// </summary>
        [Description("左模糊")]
        LeftLike,
        /// <summary>
        /// 右模糊
        /// </summary>
        [Description("右模糊")]
        RightLike,
        /// <summary>
        /// 全模糊
        /// </summary>
        [Description("全模糊")]
        AllLike,
        /// <summary>
        /// 不包含
        /// </summary>
        [Description("不包含")]
        Exclusive,
        /// <summary>
        /// 在范围中
        /// </summary>
        [Description("在范围中")]
        In,
        /// <summary>
        /// 不在范围中
        /// </summary>
        [Description("不在范围中")]
        NotIn,

        /// <summary>
        /// 存在
        /// </summary>
        [Description("存在")]
        Exists,
        /// <summary>
        /// 不存在
        /// </summary>
        [Description("存在")]
        NotExists
    }
}
