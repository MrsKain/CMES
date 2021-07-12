using System;

namespace Cnty.Core.ModelBinder
{
    public class BinderObject<T> where T : class
    {
        public Type ModelType { get; set; }
        public Action<Func<T, object>> Filter { get; set; }
    }
}
