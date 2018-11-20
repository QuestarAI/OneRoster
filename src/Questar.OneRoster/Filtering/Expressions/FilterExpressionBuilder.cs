namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Reflection;

    public class FilterExpressionBuilder
    {
        private readonly Stack<Expression> _expressions = new Stack<Expression>();

        public FilterExpressionBuilder(Type type, FilterExpressionFactory factory)
            : this(Expression.Parameter(type), factory)
        {
        }

        public FilterExpressionBuilder(ParameterExpression parameter, FilterExpressionFactory factory)
        {
            Parameter = parameter;
            Factory = factory;
        }

        public FilterExpressionFactory Factory { get; }

        public ParameterExpression Parameter { get; }

        public Type Type => Parameter.Type;

        public void AndAlso(Filter left, Filter right)
            => _expressions.Push(Expression.AndAlso(Factory.Create(left, Type), Factory.Create(right, Type)));

        public void All(FilterProperty property, FilterValue value)
            => _expressions.Push(GetContains(FilterInfo.All, property, value));

        public void Any(FilterProperty property, FilterValue value)
            => _expressions.Push(GetContains(FilterInfo.Any, property, value));

        public void Equal(FilterProperty property, FilterValue value)
            => _expressions.Push(GetPredicate(Expression.Equal, property, value));

        public void GreaterThan(FilterProperty property, FilterValue value)
            => _expressions.Push(GetPredicate(Expression.GreaterThan, property, value));

        public void GreaterThanOrEqual(FilterProperty property, FilterValue value)
            => _expressions.Push(GetPredicate(Expression.GreaterThanOrEqual, property, value));

        public void LessThan(FilterProperty property, FilterValue value)
            => _expressions.Push(GetPredicate(Expression.LessThan, property, value));

        public void LessThanOrEqual(FilterProperty property, FilterValue value)
            => _expressions.Push(GetPredicate(Expression.LessThanOrEqual, property, value));

        public void NotEqual(FilterProperty property, FilterValue value)
            => _expressions.Push(GetPredicate(Expression.NotEqual, property, value));

        public void OrElse(Filter left, Filter right)
            => _expressions.Push(Expression.OrElse(Factory.Create(left, Type), Factory.Create(right, Type)));

        public Expression Peek()
            => _expressions.Peek();

        public Expression Pop()
            => _expressions.Pop();

        public LambdaExpression ToFilterExpression() =>
            Expression.Lambda(_expressions.Single(), Parameter);

        private MemberExpression GetProperty(FilterProperty property)
        {
            var properties = new Queue<PropertyInfo>();
            var type = Type;
            foreach (var filter in property.GetProperties())
            {
                var info = type.GetProperty(filter.Name);
                if (info == null) throw new InvalidOperationException($"Couldn't determine path '{properties}' from type '${type}'.");
                type = info.PropertyType;
                properties.Enqueue(info);
            }

            Expression expression = Parameter;
            while (properties.TryDequeue(out var info))
                expression = Expression.Property(expression, info);
            return expression as MemberExpression;
        }

        private static ConstantExpression GetScalarValue(FilterValue value, Type type)
        {
            var converter = type.GetConverter();
            if (converter == null) throw new InvalidOperationException($"Couldn't find type converter for type '{type}'");
            return Expression.Constant(converter.ConvertFromString(value.Value));
        }

        private static ConstantExpression GetVectorValue(FilterValue value, Type type)
        {
            var converter = type.GetConverter();
            if (converter == null) throw new InvalidOperationException($"Couldn't find type converter for type '{type}'");
            var values = value.Value.Split(',');
            var vector = Array.CreateInstance(type, values.Length);
            for (var index = 0; index < values.Length; index++) vector.SetValue(converter.ConvertFromString(values[index]), index);
            return Expression.Constant(vector);
        }

        private MethodCallExpression GetContains(MethodInfo method, FilterProperty property, FilterValue value)
        {
            var info = GetProperty(property);
            var collection = info.Type.Name != typeof(ICollection<>).Name
                ? info.Type.GetInterface(typeof(ICollection<>).Name)
                : info.Type;
            if (collection == null) throw new InvalidOperationException($"Property is not of type '{typeof(ICollection<>)}'.");
            var type = collection.GetGenericArguments().Single();
            var item = Expression.Parameter(type);
            var contains = Expression.Lambda(Expression.Call(null, FilterInfo.Contains.MakeGenericMethod(type), info, item), item);
            return Expression.Call(null, method.MakeGenericMethod(type), GetVectorValue(value, type), contains);
        }

        private Expression GetPredicate(Func<Expression, Expression, Expression> factory, FilterProperty property, FilterValue value)
            => GetPredicate(factory, GetProperty(property), value);

        private Expression GetPredicate(Func<Expression, Expression, Expression> factory, MemberExpression property, FilterValue value)
            => factory(property, GetScalarValue(value, property.Type));
    }
}