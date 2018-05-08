namespace Questar.OneRoster.Test
{
    using System;
    using System.Linq.Expressions;

    public class UnhandledExpressionTypeException : Exception
    {
        public ExpressionType ExpressionType { get; }

        public UnhandledExpressionTypeException(ExpressionType expressionType)
            : base($"Unhandled expression type {expressionType}.")
        {
            ExpressionType = expressionType;
        }
    }
}