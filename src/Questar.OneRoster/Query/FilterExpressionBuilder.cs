namespace Questar.OneRoster.Query
{
    using System;
    using System.Linq.Expressions;

    public class FilterExpressionBuilder<T>
    {

        public static Expression<Func<T, bool>> FromString(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter)) return null;
            var filters = FilterParser.FromString(filter);

            return null;
        }
    }
}