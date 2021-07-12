using System;
using System.Collections.Generic;
using System.Text;

namespace Siemens.SimaticIT.SystemData.Domain.EventHandlerCore
{
    /// <summary>
    ///定义事件源接口，所有的事件源都要实现该接口
    /// </summary>
    public interface IEventData
    {
        DateTime EventTime { get; set; }

        object EventSource { get; set; }
    }
}
