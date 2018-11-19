namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Linq.Expressions;

    public class FilterExpressionFactory<T>
    {
        public FilterExpression<T> Create(Filter filter)
        {
            var builder = new FilterExpressionBuilder<T>();
            var visitor = new FilterExpressionFilterVisitor<T>(builder, this);
            filter.Visit(visitor);
            return builder.ToFilterExpression();
        }

        // TODO FilterPropertyExpression<T>
        internal ConstantExpression CreateValue(FilterValue value)
        {
            switch (value.Type)
            {
                case FilterValueType.Scalar:
                    throw new NotImplementedException();
                case FilterValueType.Vector:
                    //var type = property.PropertyType.GetItemType();
                    //var converter = type.GetConverter();
                    //if (converter == null)
                    //    throw new InvalidOperationException($"Couldn't find type converter for property '{property.Name}' on type '{property.DeclaringType}'.");
                    //var values = value.Value.Split(',');
                    //var vector = Array.CreateInstance(type, values.Length);
                    //for (var index = 0; index < values.Length; index++) vector.SetValue(converter.ConvertFromString(values[index]), index);
                    //return Expression.Constant(vector);
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(value.Type));
            }
        }

        // TODO FilterValueExpression<T>
        internal Expression CreateProperty(FilterProperty property)
        {
            throw new NotImplementedException();
        }
    }
}