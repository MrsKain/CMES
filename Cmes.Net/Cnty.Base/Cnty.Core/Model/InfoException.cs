using System;
using System.Collections.Generic;
using System.Text;

namespace Cnty.Core.Model
{
    /// <summary>
    /// 提示信息异常
    /// </summary>
    public class InfoException : System.Exception
    {
        public int ErrorCode { get; set; } = -1;
        public InfoException(string msg, int errorCode = -1) : base(msg)
        {
            ErrorCode = errorCode;
        }
        public InfoException(string msg, Exception innerException, int errorCode = -1) : base(msg, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
