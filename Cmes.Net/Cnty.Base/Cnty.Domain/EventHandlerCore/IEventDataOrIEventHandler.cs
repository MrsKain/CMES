using System;
using System.Collections.Generic;
using System.Text;

namespace Siemens.SimaticIT.SystemData.Domain.EventHandlerCore
{
    /// <summary>
    /// 泛型事件处理器接口
    /// </summary>
    public interface IEventHandler<TEventData> : IEventHandler where TEventData:IEventData
    {
        void HandleEvent(TEventData eventData);
    }
}
