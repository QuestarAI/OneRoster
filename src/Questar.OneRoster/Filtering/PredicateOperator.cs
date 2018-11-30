namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public struct PredicateOperator
    {
        public static readonly PredicateOperator Contains = new PredicateOperator(PredicateOperatorString.Contains);

        public static readonly PredicateOperator Equal = new PredicateOperator(PredicateOperatorString.Equal);

        public static readonly PredicateOperator GreaterThan = new PredicateOperator(PredicateOperatorString.GreaterThan);

        public static readonly PredicateOperator GreaterThanOrEqual = new PredicateOperator(PredicateOperatorString.GreaterThanOrEqual);

        public static readonly PredicateOperator LessThan = new PredicateOperator(PredicateOperatorString.LessThan);

        public static readonly PredicateOperator LessThanOrEqual = new PredicateOperator(PredicateOperatorString.LessThanOrEqual);

        public static readonly PredicateOperator NotEqual = new PredicateOperator(PredicateOperatorString.NotEqual);

        private PredicateOperator(string symbol)
            => Symbol = symbol;

        public string Symbol { get; }

        public static implicit operator string(PredicateOperator @operator)
            => @operator.Symbol;

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

        public static bool TryParse(string symbol, out PredicateOperator @operator)
            => (@operator = Values.SingleOrDefault(value => value.Symbol == symbol)) != default(PredicateOperator);

        public override string ToString()
            => Symbol;
    }
}