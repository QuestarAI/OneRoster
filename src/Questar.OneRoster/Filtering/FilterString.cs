namespace Questar.OneRoster.Filtering
{
    public class FilterString
    {
        internal FilterString(string value) =>
            Value = value;

        public string Value { get; }

        public override bool Equals(object obj) =>
            Value.Equals(obj);

        public override int GetHashCode() =>
            Value.GetHashCode();

        public override string ToString() =>
            Value;

        public static implicit operator string(FilterString filter) =>
            filter.ToString();
    }
}