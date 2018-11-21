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

        private readonly Dictionary<LogicalOperator, Func<Filter, Filter, FilterExpressionBuilder<T>>> _logical;

        private readonly Dictionary<PredicateOperator, Func<FilterProperty, FilterValue, FilterExpressionBuilder<T>>> _scalar;

        private readonly Dictionary<PredicateOperator, Func<FilterProperty, FilterValue, FilterExpressionBuilder<T>>> _vector;

        public FilterExpressionBuilder()
        {
            _logical = new Dictionary<LogicalOperator, Func<Filter, Filter, FilterExpressionBuilder<T>>>
            {
                { LogicalOperator.And, AndAlso },
                { LogicalOperator.Or, OrElse }
            };
            _scalar = new Dictionary<PredicateOperator, Func<FilterProperty, FilterValue, FilterExpressionBuilder<T>>>
            {
                { PredicateOperator.Equal, Equal },
                { PredicateOperator.GreaterThan, GreaterThan },
                { PredicateOperator.GreaterThanOrEqual, GreaterThanOrEqual },
                { PredicateOperator.LessThan, LessThan },
                { PredicateOperator.LessThanOrEqual, LessThanOrEqual },
                { PredicateOperator.NotEqual, NotEqual }
            };
            _vector = new Dictionary<PredicateOperator, Func<FilterProperty, FilterValue, FilterExpressionBuilder<T>>>
            {
                { PredicateOperator.Equal, All },
                { PredicateOperator.Contains, Any }
            };
        }

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
            (Expression<Func<T, bool>>) Expression.Lambda(_expressions.Single(), false, Parameter);

        public override void Visit(LogicalFilter filter)
        {
            if (!_logical.TryGetValue(filter.Logical, out var logical))
                throw new InvalidOperationException($"Invalid logical filter '{filter}'.");
            logical(filter.Left, filter.Right);
        }

        public override void Visit(PredicateFilter filter)
        {
            switch (filter.Value.Type)
            {
                case FilterValueType.Scalar:
                    if (!_scalar.TryGetValue(filter.Predicate, out var scalar))
                        throw new InvalidOperationException($"Invalid scalar-based predicate filter '{filter}'.");
                    scalar(filter.Property, filter.Value);
                    break;
                case FilterValueType.Vector:
                    if (!_vector.TryGetValue(filter.Predicate, out var vector))
                        throw new InvalidOperationException($"Invalid vector-based predicate filter '{filter}'.");
                    vector(filter.Property, filter.Value);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid predicate filter '{filter}'.");
            }
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