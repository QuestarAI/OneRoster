namespace Questar.OneRoster.Filtering
{
    public struct FilterString<T>
    {
        public string Value { get; }

        public FilterString(string value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return Value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public FilterExpression<T> ToFilterExpression()
        {
            return new FilterExpressionParser().Parse<T>(Value);
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(FilterString<T> filter)
        {
            return filter.ToString();
        }

        public static implicit operator FilterString<T>(string value)
        {
            return new FilterString<T>(value);
        }
    }
}