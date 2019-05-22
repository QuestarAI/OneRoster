namespace Questar.OneRoster.Models
{
    public class Metadata
    {
        public Metadata(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }

        public object Value { get; private set; }
    }
}