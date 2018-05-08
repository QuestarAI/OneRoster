namespace Questar.OneRoster.Serialization
{
    using System;

    public class SerializationTokenAttribute : Attribute
    {
        private readonly string _stringValue;
        private readonly int _intValue;
        private readonly Type _valueType;

        public SerializationTokenAttribute(string value)
        {
            _valueType = typeof(string);
            _stringValue = value;
        }

        public SerializationTokenAttribute(int value)
        {
            _valueType = typeof(int);
            _intValue = value;
        }

        public object Value => _valueType == typeof(string)
            ? (object)_stringValue
            : _intValue;
    }
}
