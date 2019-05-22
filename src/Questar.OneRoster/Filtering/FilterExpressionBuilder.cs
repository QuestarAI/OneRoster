namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public sealed class FilterExpressionBuilder<T> : FilterVisitor
    {
        private readonly Stack<Expression> _expressions = new Stack<Expression>();

        public ParameterExpression Parameter { get; } = Expression.Parameter(typeof(T));

        public Type Type => Parameter.Type;

        private static ConstantExpression GetScalarValue(FilterValue value, Type type)
        {
            var converter = TypeDescriptor.GetConverter(type);
            if (converter == null)
                throw new InvalidOperationException($"Couldn't find type converter for type '{type.Name}'.");
            return Expression.Constant(converter.ConvertFromString(value.Value));
        }

        private static ConstantExpression GetVectorValue(FilterValue value, Type type)
        {
            var converter = TypeDescriptor.GetConverter(type);
            if (converter == null)
                throw new InvalidOperationException($"Couldn't find type converter for type '{type.Name}'.");
            var values = value.Value.Split(',');
            var vector = Array.CreateInstance(type, values.Length);
            for (var index = 0; index < values.Length; index++)
                vector.SetValue(converter.ConvertFromString(values[index]), index);
            return Expression.Constant(vector);
        }

        public FilterExpression<T> ToFilterExpression() =>
            (Expression<Func<T, bool>>) Expression.Lambda(_expressions.Single(), false, Parameter);

        public override void Visit(LogicalFilter filter)
            => LogicalBuilder(filter)(filter.Left, filter.Right);

        public override void Visit(PredicateFilter filter)
            => PredicateBuilder(filter)(filter.Property, filter.Value);

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
            foreach (var name in property.GetProperties().Select(info => info.Name))
            {
                var info = type.GetTypeInfo().GetProperty(name);
                if (info == null)
                    throw new InvalidOperationException($"Couldn't determine path '{name}' from type '${type.Name}'.");
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
                : member.Type.GetTypeInfo().GetInterface(typeof(ICollection<>).Name);
            if (collection == null)
                throw new InvalidOperationException($"Property '{property}' does not implement '{typeof(ICollection<>)}'.");
            var type = collection.GetTypeInfo().GetGenericArguments().Single();
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

        private Func<Filter, Filter, FilterExpressionBuilder<T>> LogicalBuilder(LogicalFilter filter)
        {
            switch (filter.Logical)
            {
                case LogicalOperatorString.And:
                    return AndAlso;
                case LogicalOperatorString.Or:
                    return OrElse;
                default:
                    throw new NotSupportedException($"Logical operator not supported: {filter.Logical}.");
            }
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

        private Func<FilterProperty, FilterValue, FilterExpressionBuilder<T>> PredicateBuilder(PredicateFilter filter)
        {
            switch (filter.Value.Type)
            {
                case FilterValueType.Scalar:
                    switch (filter.Predicate)
                    {
                        case PredicateOperatorString.Equal: return Equal;
                        case PredicateOperatorString.GreaterThan: return GreaterThan;
                        case PredicateOperatorString.GreaterThanOrEqual: return GreaterThanOrEqual;
                        case PredicateOperatorString.LessThan: return LessThan;
                        case PredicateOperatorString.LessThanOrEqual: return LessThanOrEqual;
                        case PredicateOperatorString.NotEqual: return NotEqual;
                        default:
                            throw new NotSupportedException($"Predicate operator not supported for scalar value: {filter.Predicate}.");
                    }

                case FilterValueType.Vector:
                    switch (filter.Predicate)
                    {
                        case PredicateOperatorString.Contains: return Any;
                        case PredicateOperatorString.Equal: return All;
                        default:
                            throw new NotSupportedException($"Predicate operator not supported for vector value: {filter.Predicate}.");
                    }

                default:
                    throw new NotSupportedException($"Filter value type not supported '{filter.Value.Type}'.");
            }
        }
    }
}