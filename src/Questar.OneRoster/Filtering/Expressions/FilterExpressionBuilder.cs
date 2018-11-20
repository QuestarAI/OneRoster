namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Reflection;

    public sealed class FilterExpressionBuilder : FilterVisitor
    {
        private readonly Stack<Expression> _expressions = new Stack<Expression>();

        public FilterExpressionBuilder(Type type)
            => Parameter = Expression.Parameter(type);

        public ParameterExpression Parameter { get; }

        public Type Type => Parameter.Type;

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

        public LambdaExpression ToExpression() =>
            Expression.Lambda(_expressions.Single(), Parameter);

        public override void Visit(LogicalFilter filter)
        {
            Func<Filter, Filter, FilterExpressionBuilder> build;

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
            Func<FilterProperty, FilterValue, FilterExpressionBuilder> build;

            switch (filter.Predicate)
            {
                case "~" when filter.Value.IsVector():
                    build = Any;
                    break;
                case "=" when filter.Value.IsVector():
                    build = All;
                    break;
                case "=":
                    build = Equal;
                    break;
                case ">":
                    build = LessThan;
                    break;
                case ">=":
                    build = LessThanOrEqual;
                    break;
                case "<":
                    build = GreaterThan;
                    break;
                case "<=":
                    build = GreaterThanOrEqual;
                    break;
                case "!=":
                    build = NotEqual;
                    break;
                default:
                    throw new NotSupportedException($"Predicate operator not supported: {filter.Predicate}.");
            }

            build(filter.Property, filter.Value);
        }

        public FilterExpressionBuilder AndAlso(Filter left, Filter right)
            => PushLogical(Expression.AndAlso, left, right);

        public FilterExpressionBuilder All(FilterProperty property, FilterValue value)
            => PushContains(FilterInfo.All, property, value);

        public FilterExpressionBuilder Any(FilterProperty property, FilterValue value)
            => PushContains(FilterInfo.Any, property, value);

        public FilterExpressionBuilder Equal(FilterProperty property, FilterValue value)
            => PushPredicate(Expression.Equal, property, value);

        public FilterExpressionBuilder GreaterThan(FilterProperty property, FilterValue value)
            => PushPredicate(Expression.GreaterThan, property, value);

        public FilterExpressionBuilder GreaterThanOrEqual(FilterProperty property, FilterValue value)
            => PushPredicate(Expression.GreaterThanOrEqual, property, value);

        public FilterExpressionBuilder LessThan(FilterProperty property, FilterValue value)
            => PushPredicate(Expression.LessThan, property, value);

        public FilterExpressionBuilder LessThanOrEqual(FilterProperty property, FilterValue value)
            => PushPredicate(Expression.LessThanOrEqual, property, value);

        public FilterExpressionBuilder NotEqual(FilterProperty property, FilterValue value)
            => PushPredicate(Expression.NotEqual, property, value);

        public FilterExpressionBuilder OrElse(Filter left, Filter right)
            => PushLogical(Expression.OrElse, left, right);

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

        private FilterExpressionBuilder PushContains(MethodInfo method, FilterProperty property, FilterValue value)
        {
            var info = GetProperty(property);
            var collection = info.Type.Name != typeof(ICollection<>).Name
                ? info.Type.GetInterface(typeof(ICollection<>).Name)
                : info.Type;
            if (collection == null) throw new InvalidOperationException($"Property '{property}' is not of type '{typeof(ICollection<>)}'.");
            var type = collection.GetGenericArguments().Single();
            var item = Expression.Parameter(type);
            var contains = Expression.Lambda(Expression.Call(null, FilterInfo.Contains.MakeGenericMethod(type), info, item), item);
            var call = Expression.Call(null, method.MakeGenericMethod(type), GetVectorValue(value, type), contains);
            _expressions.Push(call);
            return this;
        }

        private FilterExpressionBuilder PushLogical(Func<Expression, Expression, Expression> factory, Filter left, Filter right)
        {
            right.Accept(this);
            left.Accept(this);
            _expressions.Push(factory(_expressions.Pop(), _expressions.Pop()));
            return this;
        }

        private FilterExpressionBuilder PushPredicate(Func<Expression, Expression, Expression> factory, FilterProperty property, FilterValue value)
            => PushPredicate(factory, GetProperty(property), value);

        private FilterExpressionBuilder PushPredicate(Func<Expression, Expression, Expression> factory, Expression property, FilterValue value)
        {
            _expressions.Push(factory(property, GetScalarValue(value, property.Type)));
            return this;
        }
    }
}