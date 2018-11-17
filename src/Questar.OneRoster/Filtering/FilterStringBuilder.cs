namespace Questar.OneRoster.Filtering
{
    using System.Collections;
    using System.Linq;
    using System.Text;

    internal sealed class FilterStringBuilder<T>
    {
        private readonly StringBuilder _filter = new StringBuilder();

        public void AndAlso(string left, string right)
        {
            _filter.Append($"{left} AND {right}");
        }

        public void All(string value, string source)
        {
            _filter.Append($"{value}={source}");
        }

        public void Any(string value, string source)
        {
            _filter.Append($"{value}~{source}");
        }

        public void Equal(string left, string right)
        {
            _filter.Append($"{left}={right}");
        }

        public void GreaterThan(string left, string right)
        {
            _filter.Append($"{left}>{right}");
        }

        public void GreaterThanOrEqual(string left, string right)
        {
            _filter.Append($"{left}>={right}");
        }

        public void LessThan(string left, string right)
        {
            _filter.Append($"{left}<{right}");
        }

        public void LessThanOrEqual(string left, string right)
        {
            _filter.Append($"{left}<={right}");
        }

        public void NotEqual(string left, string right)
        {
            _filter.Append($"{left}!={right}");
        }

        public void OrElse(string left, string right)
        {
            _filter.Append($"{left} OR {right}");
        }

        public void Property(string member)
        {
            _filter.Append(member);
        }

        public void Value(object value)
        {
            _filter.Append(value is ICollection collection ? string.Join(',', collection.OfType<object>()) : $"'{value}'");
        }

        public string ToFilterString()
        {
            return new FilterString<T>(_filter.ToString());
        }
    }
}