namespace Questar.OneRoster.Filtering.Expressions
{
    using System;
    using System.Linq.Expressions;

    public class FilterExpressionBuilder<T>
    {
        public void AndAlso(FilterExpression<T> left, FilterExpression<T> right)
        {
            throw new NotImplementedException();
        }

        public void All(FilterProperty property, ConstantExpression value)
        {
            throw new NotImplementedException();
        }

        public void Any(Expression property, ConstantExpression value)
        {
            throw new NotImplementedException();
        }

        public void Equal(Expression left, ConstantExpression value)
        {
            throw new NotImplementedException();
        }

        public void GreaterThan(Expression property, ConstantExpression value)
        {
            throw new NotImplementedException();
        }

        public void GreaterThanOrEqual(Expression property, ConstantExpression value)
        {
            throw new NotImplementedException();
        }

        public void LessThan(Expression property, ConstantExpression value)
        {
            throw new NotImplementedException();
        }

        public void LessThanOrEqual(Expression property, ConstantExpression value)
        {
            throw new NotImplementedException();
        }

        public void NotEqual(Expression property, ConstantExpression value)
        {
            throw new NotImplementedException();
        }

        public void OrElse(FilterExpression<T> left, FilterExpression<T> right)
        {
            throw new NotImplementedException();
        }

        public FilterExpression<T> ToFilterExpression()
        {
            throw new NotImplementedException();
        }
    }
}