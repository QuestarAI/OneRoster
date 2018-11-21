namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public struct PredicateOperator
    {
        public static readonly PredicateOperator Contains = new PredicateOperator("~");

        public static readonly PredicateOperator Equal = new PredicateOperator("=");

        public static readonly PredicateOperator GreaterThan = new PredicateOperator(">");

        public static readonly PredicateOperator GreaterThanOrEqual = new PredicateOperator(">=");

        public static readonly PredicateOperator LessThan = new PredicateOperator("<");

        public static readonly PredicateOperator LessThanOrEqual = new PredicateOperator("<=");

        public static readonly PredicateOperator NotEqual = new PredicateOperator("!=");

        private PredicateOperator(string symbol)
            => Symbol = symbol;

        public string Symbol { get; }

        public static implicit operator string(PredicateOperator logical)
            => logical.Symbol;

        public static IEnumerable<PredicateOperator> Values
        {
            get
            {
                yield return Contains;
                yield return Equal;
                yield return GreaterThan;
                yield return GreaterThanOrEqual;
                yield return LessThan;
                yield return LessThanOrEqual;
                yield return NotEqual;
            }
        }

        public static PredicateOperator Parse(string symbol)
            => Values.Single(value => value.Symbol == symbol);

        public static bool TryParse(string symbol, out PredicateOperator predicate)
            => (predicate = Values.SingleOrDefault(value => value.Symbol == symbol)) != default(PredicateOperator);

        public override string ToString()
            => Symbol;
    }
}