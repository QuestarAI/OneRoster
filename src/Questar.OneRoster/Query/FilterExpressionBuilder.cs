namespace Questar.OneRoster.Query
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class FilterExpressionBuilder<T>
    {

        public static Expression<Func<T, bool>> FromString(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter)) return null;
            var filters = FilterParser.FromString(filter);
            var first = filters.First();
            var param = Expression.Parameter(typeof(T), "p0");
            var prop = Expression.Property(param, first.FieldName);
            var constant = Expression.Constant(first.Value);
            var equal = Expression.Equal(prop, constant);
            var func = Expression.Lambda<Func<T, bool>>(equal, false, param);
            return func;
        }
    }
}