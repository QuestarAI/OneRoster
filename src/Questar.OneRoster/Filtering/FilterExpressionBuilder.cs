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
                throw new InvalidOperationException($"Couldn't find type converter for type '{type.Name}'.");
            return Expression.Constant(converter.ConvertFromString(value.Value));
        }

        private static ConstantExpression GetVectorValue(FilterValue value, Type type)
        {
            var converter = type.GetConverter();
            if (converter == null)
                throw new InvalidOperationException($"Couldn't find type converter for type '{type.Name}'.");
            var values = value.Value.Split(',');
            var vector = Array.CreateInstance(type, values.Length);
            for (var index = 0; index < values.Length; index++) vector.SetValue(converter.ConvertFromString(values[index]), index);
            return Expression.Constant(vector);
        }

        public FilterExpression<T> ToExpression() =>
            (Expression<Func<T, bool>>) Expression.Lambda(_expressions.Single(), false, Parameter);

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
            switch (filter.Value.Type)
            {
                case FilterValueType.Scalar:
                    switch (filter.Predicate)
                    {
                        case "=":
                            build = Equal;
                            break;
                        case ">":
                            build = GreaterThan;
                            break;
                        case ">=":
                            build = GreaterThanOrEqual;
                            break;
                        case "<":
                            build = LessThan;
                            break;
                        case "<=":
                            build = LessThanOrEqual;
                            break;
                        case "!=":
                            build = NotEqual;
                            break;
                        default:
                            throw new NotSupportedException($"Predicate operator not supported for scalar value: {filter.Predicate}.");
                    }
                    break;
                case FilterValueType.Vector:
                    switch (filter.Predicate)
                    {
                        case "~":
                            build = Any;
                            break;
                        case "=":
                            build = All;
                            break;
                        default:
                            throw new NotSupportedException($"Predicate operator not supported for vector value: {filter.Predicate}.");
                    }
                    break;
                default:
                    throw new NotSupportedException($"Filter value type not supported '{filter.Value.Type}'.");
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
            => Predicate(Expression.Equal, property, value, () => Expression.Constant(false));

        public FilterExpressionBuilder<T> GreaterThan(FilterProperty property, FilterValue value)
            => Predicate(Expression.GreaterThan, property, value);

        public FilterExpressionBuilder<T> GreaterThanOrEqual(FilterProperty property, FilterValue value)
            => Predicate(Expression.GreaterThanOrEqual, property, value);

        public FilterExpressionBuilder<T> LessThan(FilterProperty property, FilterValue value)
            => Predicate(Expression.LessThan, property, value);

        public FilterExpressionBuilder<T> LessThanOrEqual(FilterProperty property, FilterValue value)
            => Predicate(Expression.LessThanOrEqual, property, value);

        public FilterExpressionBuilder<T> NotEqual(FilterProperty property, FilterValue value)
            => Predicate(Expression.NotEqual, property, value, () => Expression.Constant(true));

        public FilterExpressionBuilder<T> OrElse(Filter left, Filter right)
            => Logical(Expression.OrElse, left, right);

        private MemberExpression GetProperty(FilterProperty property)
        {
            Expression expression = Parameter;
            var type = Type;
            foreach (var filter in property.GetProperties())
            {
                var info = type.GetProperty(filter.Name);
                if (info == null)
                    throw new InvalidOperationException($"Couldn't determine path '{filter}' from type '${type.Name}'.");
                expression = Expression.Property(expression, info);
                type = info.PropertyType;
            }
            return expression as MemberExpression;
        }

        private FilterExpressionBuilder<T> Contains(MethodInfo method, FilterProperty property, FilterValue value)
        {
            var member = GetProperty(property);
            var collection = member.Type.Name == typeof(ICollection<>).Name
                ? member.Type
                : member.Type.GetInterface(typeof(ICollection<>).Name);
            if (collection == null)
                throw new InvalidOperationException($"Property '{property}' does not implement '{typeof(ICollection<>)}'.");
            var type = collection.GetGenericArguments().Single();
            var item = Expression.Parameter(type);
            var contains = Expression.Lambda(Expression.Call(null, FilterInfo.Contains.MakeGenericMethod(type), member, item), item);
            var call = Expression.Call(null, method.MakeGenericMethod(type), GetVectorValue(value, type), contains);
            _expressions.Push(call);
            return this;
        }

        private FilterExpressionBuilder<T> Logical(Func<Expression, Expression, Expression> factory, Filter left, Filter right)
        {
            left.Accept(this);
            var leftFilter = _expressions.Pop();
            right.Accept(this);
            var rightFilter = _expressions.Pop();
            _expressions.Push(factory(leftFilter, rightFilter));
            return this;
        }

        private FilterExpressionBuilder<T> Predicate(Func<Expression, Expression, Expression> factory, FilterProperty property, FilterValue value, Func<Expression> fallback = null)
            => Predicate(factory, GetProperty(property), value, fallback);

        private FilterExpressionBuilder<T> Predicate(Func<Expression, Expression, Expression> factory, Expression property, FilterValue value, Func<Expression> fallback)
        {
            // TODO add stronger exception handling and conditional support for fallback
            Expression expression;
            try
            {
                expression = factory(property, GetScalarValue(value, property.Type));
            }
            catch (FormatException e)
            {
                expression = fallback?.Invoke() ?? throw e;
            }
            _expressions.Push(expression);
            return this;
        }
    }
}