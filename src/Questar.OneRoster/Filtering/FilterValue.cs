namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Text.RegularExpressions;

    public class FilterValue
    {
        private static readonly Regex ScalarRegex = new Regex(@"'(?<Scalar>[^']*)'", RegexOptions.Compiled);

        private static readonly Regex VectorRegex = new Regex(@"(?<Vector>[^']*)", RegexOptions.Compiled);

        protected internal FilterValue(FilterValueType type, string value)
        {
            Type = type;
            Value = value;
        }

        public FilterValueType Type { get; }

        public string Value { get; }

        public bool IsScalar()
            => Type == FilterValueType.Scalar;

        public bool IsVector()
            => Type == FilterValueType.Vector;

        public static FilterValue Parse(string text)
        {
            var scalar = ScalarRegex.Match(text);
            if (scalar.Success)
                return new FilterValue
                (
                    FilterValueType.Scalar,
                    scalar.Groups["Scalar"].Value
                );
            var vector = VectorRegex.Match(text);
            if (vector.Success)
                return new FilterValue
                (
                    FilterValueType.Vector,
                    scalar.Groups["Vector"].Value
                );
            throw new ArgumentException($"Couldn't parse filter value '{text}'.");
        }

        public override string ToString()
            => Value;
    }
}