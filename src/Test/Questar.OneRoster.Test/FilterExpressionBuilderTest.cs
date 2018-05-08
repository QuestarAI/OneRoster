namespace Questar.OneRoster.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        [Fact]
        public void CanApplyStringEqualExpression()
        {
            var predicate = FilterExpressionBuilder<Entity>.FromString("FooString='42'");
            var list = new List<Entity>
            {
                new Entity { BarInt = 1, FooString = "Nope" },
                new Entity { BarInt = 2, FooString = "42" },
                new Entity { BarInt = 3, FooString = "9001" },
                new Entity { BarInt = 4, FooString = "421" },
                new Entity { BarInt = 5, FooString = "42" },
                new Entity { BarInt = 6, FooString = "42 " },
            };

            var filtered = list.Where(predicate.Compile());

            Assert.Collection(
                filtered,
                e =>
                {
                    Assert.Equal(2, e.BarInt);
                },
                e =>
                {
                    Assert.Equal(5, e.BarInt);
                });
        }
    }
}