namespace Questar.OneRoster.Filtering
{
    public struct FilterString
    {
        public string Value { get; }

        internal FilterString(string value)
            => Value = value;

        public override bool Equals(object obj)
            => Value.Equals(obj);

        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => Value;

        public static implicit operator string(FilterString filter)
            => filter.ToString();
    }
}