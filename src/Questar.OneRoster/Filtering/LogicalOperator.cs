namespace Questar.OneRoster.Filtering
{
    using System.Collections.Generic;
    using System.Linq;

    public struct LogicalOperator
    {
        public static readonly LogicalOperator And = new LogicalOperator("AND");

        public static readonly LogicalOperator Or = new LogicalOperator("OR");

        private LogicalOperator(string symbol)
            => Symbol = symbol;

        public string Symbol { get; }

        public static implicit operator string(LogicalOperator logical)
            => logical.Symbol;

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

        public static bool TryParse(string symbol, out LogicalOperator logical)
            => (logical = Values.SingleOrDefault(value => value.Symbol == symbol)) != default(LogicalOperator);
        
        public override bool Equals(object obj)
            => Symbol.Equals(obj);

        public override int GetHashCode()
            => Symbol.GetHashCode();

        public override string ToString()
            => Symbol;
    }
}