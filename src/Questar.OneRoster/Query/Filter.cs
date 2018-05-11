namespace Questar.OneRoster.Query
{
    public class Filter
    {
        public LogicalOperator? AndOr { get; set; }
        public string FieldName { get; set; }
        public BinaryOperator Operator { get; set; }
        public string Value { get; set; }
    }
}