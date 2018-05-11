using System;

namespace Questar.OneRoster.Query.Exceptions
{
    public class BinaryOperatorOutOfRangeException : Exception
    {
        public BinaryOperator Operator { get; }

        private BinaryOperatorOutOfRangeException(BinaryOperator op, string message)
            : base(message)
        {
            Operator = op;
        }

        internal static BinaryOperatorOutOfRangeException FromArgs(BinaryOperator op)
        {
            var message = $"Unhandled binary operator {op}; this should be added to the applicable switch-case.";
            return new BinaryOperatorOutOfRangeException(op, message);
        }
    }
}