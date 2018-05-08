namespace Questar.OneRoster.Test
{
    using Query;
    using Xunit;

    public class FilterParserTest
    {
        [Fact]
        public void CanParseEqual()
        {
            var actual = FilterParser.FromString("FooString='42'");
            Assert.Collection(
                actual,
                f =>
                {
                    Assert.Null(f.AndOr);
                    Assert.Equal("FooString", f.FieldName);
                    Assert.Equal("=", f.Operator);
                    Assert.Equal("42", f.Value);
                });
        }

        [Fact]
        public void CanParseTwoEqual()
        {
            var actual = FilterParser.FromString("FooString='42' AND BarInt='9001'");
            Assert.Collection(
                actual,
                f =>
                {
                    Assert.Null(f.AndOr);
                    Assert.Equal("FooString", f.FieldName);
                    Assert.Equal("=", f.Operator);
                    Assert.Equal("42", f.Value);
                },
                f =>
                {
                    Assert.Equal("AND", f.AndOr);
                    Assert.Equal("BarInt", f.FieldName);
                    Assert.Equal("=", f.Operator);
                    Assert.Equal("9001", f.Value);
                });
        }

        [Fact]
        public void CannotStartRuleWithAnd()
        {
            Assert.Throws<UnusedFilterException>(() => FilterParser.FromString(" AND FooString='42'"));
        }

        [Fact]
        public void CannotStartRuleWithOr()
        {
            Assert.Throws<UnusedFilterException>(() => FilterParser.FromString(" OR FooString='42'"));
        }
    }
}