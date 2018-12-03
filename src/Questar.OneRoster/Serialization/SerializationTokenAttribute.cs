namespace Questar.OneRoster.Serialization
{
    using System;

    // TODO this seems unnecessary
    public class SerializationTokenAttribute : Attribute
    {
        public SerializationTokenAttribute(string value) => Value = value;
        public SerializationTokenAttribute(int value) => Value = value;
        public object Value { get; }
    }
}