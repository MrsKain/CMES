using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cnty.Core.Enums
{
    /// <summary>
    /// 排序方向
    /// </summary>
    public enum ConditionDirection
    {
        /// <summary>
        /// 正序
        /// </summary>
        [Description("正序")]
        ASC = 1,
        /// <summary>
        /// 倒序
        /// </summary>
        [Description("倒叙")]
        DESC
    }
}
