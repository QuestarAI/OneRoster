namespace Questar.OneRoster.Query.Exceptions
{
    using System;

    public class NotSupportedTypeException : NotSupportedException
    {
        public Type Type { get; }

        private NotSupportedTypeException(Type type, string message)
            : base(message)
        {
            Type = type;
        }
        public static NotSupportedTypeException FromArgs(Type type)
        {
            var message = $"Unable to build filter for type {type.FullName}.";
            return new NotSupportedTypeException(type, message);
        }
    }
}