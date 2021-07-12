using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Cnty.Core.BaseProvider
{
    public class OrderExpression<T> where T : new()
    {
        public OrderExpression() { }

        public OrderExpression<T> OrderBy(Expression<Func<T, object>> expression)
        {
            var result = new OrderExpression<T>();
            return result;
        }
        public OrderExpression<T> OrderByDesc(Expression<Func<T, object>> expression)
        {
            var result = new OrderExpression<T>();
            return result;
        }
    }
}
