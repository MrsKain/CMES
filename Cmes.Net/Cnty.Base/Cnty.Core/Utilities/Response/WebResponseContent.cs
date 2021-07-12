using Cnty.Core.Enums;
using Cnty.Core.Extensions;

namespace Cnty.Core.Utilities
{
    public class WebResponseContent
    {
        public WebResponseContent()
        {
        }
        public WebResponseContent(bool status)
        {
            this.Status = status;
        }
        public bool Status { get; set; }
        public string Code { get; set; } = "0";
        public string Message { get; set; } = "操作成功";
        public object Data { get; set; }

        public WebResponseContent OK()
        {
            this.Status = true;
            return this;
        }

        public static WebResponseContent Instance
        {
            get { return new WebResponseContent(); }
        }
        public WebResponseContent OK(string message = null,object data=null)
        {
            this.Status = true;
            this.Message = message;
            this.Data = data;
            this.Code = "0";
            return this;
        }
        public WebResponseContent OK(ResponseType responseType)
        {
            return Set(responseType, true);
        }
        public WebResponseContent Error(string message = null)
        {
            this.Status = false;
            this.Message = message;
            this.Code = "-1";
            return this;
        }
        public WebResponseContent Error(ResponseType responseType)
        {
            return Set(responseType, false);
        }
        public WebResponseContent Set(ResponseType responseType)
        {
            bool? b = null;
            return this.Set(responseType, b);
        }
        public WebResponseContent Set(ResponseType responseType, bool? status)
        {
            return this.Set(responseType, null, status);
        }
        public WebResponseContent Set(ResponseType responseType, string msg)
        {
            bool? b = null;
            return this.Set(responseType, msg, b);
        }
        public WebResponseContent Set(ResponseType responseType, string msg, bool? status)
        {
            if (status != null)
            {
                this.Status = (bool)status;
            }
            this.Code = ((int)responseType).ToString();
            if (!string.IsNullOrEmpty(msg))
            {
                Message = msg;
                return this;
            }
            Message = responseType.GetMsg();
            return this;
        }

    }
}
