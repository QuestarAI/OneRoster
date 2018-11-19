namespace Questar.OneRoster.Filtering
{
    using System.Text;

    public sealed class FilterStringBuilder
    {
        private readonly StringBuilder _filter = new StringBuilder();

        public void AndAlso(FilterString left, FilterString right)
        {
            _filter.Append($"{left} AND {right}");
        }

        public void All(FilterProperty property, FilterValue value)
        {
            _filter.Append($"{property}={value}");
        }

        public void Any(FilterProperty property, FilterValue value)
        {
            _filter.Append($"{property}~{value}");
        }

        public void Equal(FilterProperty left, FilterValue value)
        {
            _filter.Append($"{left}={value}");
        }

        public void GreaterThan(FilterProperty property, FilterValue value)
        {
            _filter.Append($"{property}>{value}");
        }

        public void GreaterThanOrEqual(FilterProperty property, FilterValue value)
        {
            _filter.Append($"{property}>={value}");
        }

        public void LessThan(FilterProperty property, FilterValue value)
        {
            _filter.Append($"{property}<{value}");
        }

        public void LessThanOrEqual(FilterProperty property, FilterValue value)
        {
            _filter.Append($"{property}<={value}");
        }

        public void NotEqual(FilterProperty property, FilterValue value)
        {
            _filter.Append($"{property}!={value}");
        }

        public void OrElse(FilterString left, FilterString right)
        {
            _filter.Append($"{left} OR {right}");
        }

        //public void Property(string member)
        //{
        //    _filter.Append(member);
        //}

        //public void Value(object value)
        //{
        //    _filter.Append(value is ICollection collection ? string.Join(',', collection.OfType<object>()) : $"'{value}'");
        //}

        public FilterString ToFilterString()
        {
            return new FilterString(_filter.ToString());
        }
    }
}