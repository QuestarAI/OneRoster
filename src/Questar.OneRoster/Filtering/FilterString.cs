namespace Questar.OneRoster.Filtering
{
    public struct FilterString
    {
        public string Value { get; }

        internal FilterString(string value)
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

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(FilterString filter)
        {
            return filter.ToString();
        }
    }
}