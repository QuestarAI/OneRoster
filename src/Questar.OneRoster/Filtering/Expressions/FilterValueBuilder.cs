namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Linq.Expressions;

    public class FilterValueBuilder
    {
        public FilterValue Value { get; private set; }

        public void Constant(ConstantExpression node)
        {
            var convert = Expression.Convert(node, typeof(object));
            var lambda = Expression.Lambda<Func<object>>(convert);
            var getter = lambda.Compile();
            var value = getter();

            // TODO collections

            Value = new FilterValue(FilterValueType.Scalar, value.ToString());
        }

        public void NewArray(NewArrayExpression node)
        {
            throw new NotImplementedException();
        }
    }
}