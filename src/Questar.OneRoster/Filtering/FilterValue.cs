namespace Questar.OneRoster.Filtering
{
    using System;
    using System.Text.RegularExpressions;

    public sealed class FilterValue
    {
        private static readonly Regex Scalar = new Regex(@"'(?<Scalar>[^']*)'", RegexOptions.Compiled);

        private static readonly Regex Vector = new Regex(@"(?<Vector>[^']*)", RegexOptions.Compiled);

        public FilterValue(FilterValueType type, string value)
        {
            Type = type;
            Value = value;
        }

        public FilterValueType Type { get; }

        public string Value { get; }

        public static FilterValue Parse(string text)
        {
            var scalar = Scalar.Match(text);
            if (scalar.Success)
                return new FilterValue
                (
                    FilterValueType.Scalar,
                    scalar.Groups["Scalar"].Value
                );
            var vector = Vector.Match(text);
            if (vector.Success)
                return new FilterValue
                (
                    FilterValueType.Vector,
                    vector.Groups["Vector"].Value
                );
            throw new ArgumentException($"Couldn't parse filter value '{text}'.");
        }

        public override string ToString()
        {
            switch (Type)
            {
                case FilterValueType.Scalar:
                    return $"'{Value}'";
                case FilterValueType.Vector:
                    return Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type));
            }
        }
    }
}