namespace Questar.OneRoster.Filtering
{
    using System.Collections.Generic;

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
            using (var properties = ((IEnumerable<string>) text.Split('.')).GetEnumerator())
            {
                properties.MoveNext();
                var property = new FilterProperty(properties.Current);
                do
                {
                    property = new FilterProperty(properties.Current, property);
                } while (properties.MoveNext());
                return property;
            }
        }
    }
}