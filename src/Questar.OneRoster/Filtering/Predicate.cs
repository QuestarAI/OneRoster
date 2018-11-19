namespace Questar.OneRoster.Filtering
{
    using System.Collections.Generic;
    using System.Linq;

    public struct Predicate
    {
        public static readonly Predicate Contains = new Predicate("~");

        public static readonly Predicate Equal = new Predicate("=");

        public static readonly Predicate GreaterThan = new Predicate(">");

        public static readonly Predicate GreaterThanOrEqual = new Predicate(">=");

        public static readonly Predicate LessThan = new Predicate("<");

        public static readonly Predicate LessThanOrEqual = new Predicate("<=");

        public static readonly Predicate NotEqual = new Predicate("!=");

        private Predicate(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }

        public static implicit operator string(Predicate logical)
        {
            return logical.Symbol;
        }

        public static IEnumerable<Predicate> Values
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

        public static Predicate Parse(string symbol)
        {
            return Values.Single(value => value.Symbol == symbol);
        }

        public static bool TryParse(string symbol, out Predicate predicate)
        {
            return (predicate = Values.SingleOrDefault(value => value.Symbol == symbol)) != default(Predicate);
        }

        public override bool Equals(object obj)
        {
            return Symbol.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }

        public override string ToString()
        {
            return Symbol;
        }
    }
}