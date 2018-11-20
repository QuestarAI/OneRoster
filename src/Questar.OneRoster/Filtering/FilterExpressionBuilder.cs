namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Reflection;

    public sealed class FilterExpressionBuilder<T> : FilterVisitor
    {
        private readonly Stack<Expression> _expressions = new Stack<Expression>();

        public ParameterExpression Parameter { get; } = Expression.Parameter(typeof(T));

        public Type Type => Parameter.Type;

        private static ConstantExpression GetScalarValue(FilterValue value, Type type)
        {
            var converter = type.GetConverter();
            if (converter == null)
                throw new InvalidOperationException($"Couldn't find type converter for type '{type}'");
            return Expression.Constant(converter.ConvertFromString(value.Value));
        }

        private static ConstantExpression GetVectorValue(FilterValue value, Type type)
        {
            var converter = type.GetConverter();
            if (converter == null)
                throw new InvalidOperationException($"Couldn't find type converter for type '{type}'");
            var values = value.Value.Split(',');
            var vector = Array.CreateInstance(type, values.Length);
            for (var index = 0; index < values.Length; index++) vector.SetValue(converter.ConvertFromString(values[index]), index);
            return Expression.Constant(vector);
        }

        public FilterExpression<T> ToExpression() =>
            (Expression<Func<T, bool>>) Expression.Lambda(_expressions.Single(), Parameter);

        public override void Visit(LogicalFilter filter)
        {
            Func<Filter, Filter, FilterExpressionBuilder<T>> build;

            switch (filter.Logical)
            {
                case "AND":
                    build = AndAlso;
                    break;
                case "OR":
                    build = OrElse;
                    break;
                default:
                    throw new NotSupportedException($"Logical operator not supported: {filter.Logical}.");
            }

            build(filter.Left, filter.Right);
        }

        public override void Visit(PredicateFilter filter)
        {
            Func<FilterProperty, FilterValue, FilterExpressionBuilder<T>> build;

            switch (filter.Predicate)
            {
                case "~" when filter.Value.IsVector():
                    build = Any;
                    break;
                case "=" when filter.Value.IsVector():
                    build = All;
                    break;
                case "=" when filter.Value.IsScalar():
                    build = Equal;
                    break;
                case ">" when filter.Value.IsScalar():
                    build = GreaterThan;
                    break;
                case ">=" when filter.Value.IsScalar():
                    build = GreaterThanOrEqual;
                    break;
                case "<" when filter.Value.IsScalar():
                    build = LessThan;
                    break;
                case "<=" when filter.Value.IsScalar():
                    build = LessThanOrEqual;
                    break;
                case "!=" when filter.Value.IsScalar():
                    build = NotEqual;
                    break;
                default:
                    throw new NotSupportedException($"Predicate operator not supported: {filter.Predicate}.");
            }

            build(filter.Property, filter.Value);
        }

        public FilterExpressionBuilder<T> AndAlso(Filter left, Filter right)
            => Logical(Expression.AndAlso, left, right);

        public FilterExpressionBuilder<T> All(FilterProperty property, FilterValue value)
            => Contains(FilterInfo.All, property, value);

        public FilterExpressionBuilder<T> Any(FilterProperty property, FilterValue value)
            => Contains(FilterInfo.Any, property, value);

        public FilterExpressionBuilder<T> Equal(FilterProperty property, FilterValue value)
            => Predicate(Expression.Equal, property, value);

        public FilterExpressionBuilder<T> GreaterThan(FilterProperty property, FilterValue value)
            => Predicate(Expression.GreaterThan, property, value);

        public FilterExpressionBuilder<T> GreaterThanOrEqual(FilterProperty property, FilterValue value)
            => Predicate(Expression.GreaterThanOrEqual, property, value);

        public FilterExpressionBuilder<T> LessThan(FilterProperty property, FilterValue value)
            => Predicate(Expression.LessThan, property, value);

        public FilterExpressionBuilder<T> LessThanOrEqual(FilterProperty property, FilterValue value)
            => Predicate(Expression.LessThanOrEqual, property, value);

        public FilterExpressionBuilder<T> NotEqual(FilterProperty property, FilterValue value)
            => Predicate(Expression.NotEqual, property, value);

        public FilterExpressionBuilder<T> OrElse(Filter left, Filter right)
            => Logical(Expression.OrElse, left, right);

        private MemberExpression GetProperty(FilterProperty property)
        {
            var properties = new Queue<PropertyInfo>();
            var type = Type;
            foreach (var filter in property.GetProperties())
            {
                var info = type.GetProperty(filter.Name);
                if (info == null)
                    throw new InvalidOperationException($"Couldn't determine path '{properties}' from type '${type}'.");
                type = info.PropertyType;
                properties.Enqueue(info);
            }

            Expression expression = Parameter;
            while (properties.TryDequeue(out var info))
                expression = Expression.Property(expression, info);
            return expression as MemberExpression;
        }

        private FilterExpressionBuilder<T> Contains(MethodInfo method, FilterProperty property, FilterValue value)
        {
            var info = GetProperty(property);
            var collection = info.Type.Name != typeof(ICollection<>).Name
                ? info.Type.GetInterface(typeof(ICollection<>).Name)
                : info.Type;
            if (collection == null)
                throw new InvalidOperationException($"Property '{property}' is not of type '{typeof(ICollection<>)}'.");
            var type = collection.GetGenericArguments().Single();
            var item = Expression.Parameter(type);
            var contains = Expression.Lambda(Expression.Call(null, FilterInfo.Contains.MakeGenericMethod(type), info, item), item);
            var call = Expression.Call(null, method.MakeGenericMethod(type), GetVectorValue(value, type), contains);
            _expressions.Push(call);
            return this;
        }

        private FilterExpressionBuilder<T> Logical(Func<Expression, Expression, Expression> factory, Filter left, Filter right)
        {
            right.Accept(this);
            left.Accept(this);
            _expressions.Push(factory(_expressions.Pop(), _expressions.Pop()));
            return this;
        }

        private FilterExpressionBuilder<T> Predicate(Func<Expression, Expression, Expression> factory, FilterProperty property, FilterValue value)
            => Predicate(factory, GetProperty(property), value);

        private FilterExpressionBuilder<T> Predicate(Func<Expression, Expression, Expression> factory, Expression property, FilterValue value)
        {
            _expressions.Push(factory(property, GetScalarValue(value, property.Type)));
            return this;
        }
    }
}