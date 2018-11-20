namespace Questar.OneRoster.Filtering
{
    using System.Collections.Generic;
    using System.Linq;

    public class FilterProperty
    {
        public FilterProperty(string name, FilterProperty caller = null)
        {
            Name = name;
            Caller = caller;
        }

        public FilterProperty Caller { get; private set; }

        public string Name { get; private set; }

        public static FilterProperty Parse(string text)
        {
            using (var properties = text.Split('.').Cast<string>().GetEnumerator())
            {
                properties.MoveNext();
                var property = new FilterProperty(properties.Current);
                while (properties.MoveNext()) property = new FilterProperty(properties.Current, property);
                return property;
            }
        }

        public IEnumerable<FilterProperty> GetProperties()
        {
            var property = this;
            do
            {
                yield return property;
                property = property.Caller;
            } while (property != null);
        }

        public override string ToString()
            => string.Join('.', GetProperties().Select(property => property.Name));
    }
}