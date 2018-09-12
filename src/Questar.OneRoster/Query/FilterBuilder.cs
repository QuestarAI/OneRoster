namespace Questar.OneRoster.Query
{
    using System;
    using System.Collections.Generic;

    internal static class FilterBuilder
    {
        internal static readonly IEnumerable<BinaryOperator> NumericOnlyOperators = new List<BinaryOperator>
        {
            BinaryOperator.GreaterThan,
            BinaryOperator.GreaterThanOrEqual,
            BinaryOperator.LessThan,
            BinaryOperator.LessThanOrEqual
        }.AsReadOnly();

        internal static readonly IEnumerable<Type> NumericTypes = new List<Type>
        {
            typeof(int),
            typeof(double),
            typeof(DateTime)
        }.AsReadOnly();
    }
}