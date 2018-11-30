namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public struct LogicalOperator
    {
        public static readonly LogicalOperator And = new LogicalOperator(LogicalOperatorString.And);

        public static readonly LogicalOperator Or = new LogicalOperator(LogicalOperatorString.Or);

        private LogicalOperator(string symbol)
            => Symbol = symbol;

        public string Symbol { get; }

        public static implicit operator string(LogicalOperator @operator)
            => @operator.Symbol;

        public static IEnumerable<LogicalOperator> Values
        {
            get
            {
                yield return And;
                yield return Or;
            }
        }

        public static LogicalOperator Parse(string symbol)
            => Values.Single(value => value.Symbol == symbol);

        public static bool TryParse(string symbol, out LogicalOperator @operator)
            => (@operator = Values.SingleOrDefault(value => value.Symbol == symbol)) != default(LogicalOperator);

        public override string ToString()
            => Symbol;
    }
}