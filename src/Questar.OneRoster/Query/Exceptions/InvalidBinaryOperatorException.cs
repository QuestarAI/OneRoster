namespace Questar.OneRoster.Query.Exceptions
{
    using System;

    internal class InvalidBinaryOperatorException : Exception
    {
        public BinaryOperator Operator { get; }
        public Type Type { get; }
        public string FieldName { get; }

        private InvalidBinaryOperatorException(BinaryOperator op, Type type, string fieldName, string message)
            : base(message)
        {
            Operator = op;
            Type = type;
            FieldName = fieldName;
        }

        internal static Exception FromArgs(BinaryOperator op, Type type, string fieldName)
        {
            var message = $"Cannot apply {op} operator to field {fieldName} with type {type.FullName}.";
            return new InvalidBinaryOperatorException(op, type, fieldName, message);
        }
    }
}