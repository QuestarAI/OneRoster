namespace Questar.OneRoster.Query
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class FilterQueryStringBuilder<T>
    {
        internal static Type Type => ReflectionCache<T>.Type;
        internal static Dictionary<string, Type> PropertyTypesByName => ReflectionCache<T>.PropertyTypesByName;
        internal static IList<string> PropertyNames => ReflectionCache<T>.PropertyNames;

        public static string FromExpression(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException("TODO: Implement visitor pattern.");
        }
    }
}