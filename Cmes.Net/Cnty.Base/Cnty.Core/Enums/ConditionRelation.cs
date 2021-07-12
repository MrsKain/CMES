using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cnty.Core.Enums
{
    /// <summary>
    /// 查询关系
    /// </summary>
    public enum ConditionRelation
    {
        /// <summary>
        /// 和
        /// </summary>
        [Description("与")]
        And = 1,
        /// <summary>
        /// 或
        /// </summary>
        [Description("或")]
        Or = 2
    }
}
