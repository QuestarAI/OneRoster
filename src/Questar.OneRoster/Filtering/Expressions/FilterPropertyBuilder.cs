namespace Questar.OneRoster.Filtering.Expressions
{
    public class FilterPropertyBuilder
    {
        public FilterProperty Value { get; private set; }

        public void Add(string name)
        {
            Value = new FilterProperty(name, Value);
        }
    }
}