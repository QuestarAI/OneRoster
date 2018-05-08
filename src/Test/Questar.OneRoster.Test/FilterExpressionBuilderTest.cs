namespace Questar.OneRoster.Test
{
    using System;
    using System.Linq.Expressions;
    using Mock;
    using Query;
    using Xunit;

    public class FilterExpressionBuilderTest
    {
        [Fact]
        public void CanParseStringEqual()
        {
            Expression<Func<Entity, bool>> expected = e => e.FooString == "42";
            var actual = FilterExpressionBuilder<Entity>.FromString("FooString='42'");
            Assert.True(ExpressionComparer.AreEqual(expected, actual));
        }
    }
}