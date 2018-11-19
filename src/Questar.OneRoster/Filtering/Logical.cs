namespace Questar.OneRoster.Filtering
{
    using System.Collections.Generic;
    using System.Linq;

    public struct Logical
    {
        public static readonly Logical And = new Logical("AND");

        public static readonly Logical Or = new Logical("OR");

        private Logical(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }

        public static implicit operator string(Logical logical)
        {
            return logical.Symbol;
        }

        public static IEnumerable<Logical> Values
        {
            get
            {
                yield return And;
                yield return Or;
            }
        }

        public static Logical Parse(string symbol)
        {
            return Values.Single(value => value.Symbol == symbol);
        }

        public static bool TryParse(string symbol, out Logical logical)
        {
            return (logical = Values.SingleOrDefault(value => value.Symbol == symbol)) != default(Logical);
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