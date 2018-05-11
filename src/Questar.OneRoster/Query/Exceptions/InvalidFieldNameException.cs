namespace Questar.OneRoster.Query.Exceptions
{
    using System;
    using System.Collections.Generic;

    public class InvalidFieldNameException : Exception
    {
        public string InvalidFieldName { get; }
        public IEnumerable<string> ValidFieldNames { get; }

        private InvalidFieldNameException(string invalidFieldName, IEnumerable<string> validFieldNames, string message)
            : base(message)
        {
            InvalidFieldName = invalidFieldName;
            ValidFieldNames = validFieldNames;
        }

        internal static InvalidFieldNameException FromArgs(string invalidFieldName, IList<string> validFieldNames)
        {
            var message = $"No such field named {invalidFieldName}. Valid fields include: {string.Join(", ", validFieldNames)}.";
            return new InvalidFieldNameException(invalidFieldName, validFieldNames, message);
        }
    }
}