namespace Questar.OneRoster.Filtering
{
    public class FilterString
    {
        internal FilterString(string value)
        {
            Value = value;
        }

        public string Value { get; }

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