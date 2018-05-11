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
            => CanApplyFilter("FooString='42'", e => e.FooString == "42");

        [Fact]
        public void CanApplyIntEqualExpression()
            => CanApplyFilter("BarInt='4'", e => e.BarInt == 4);

        [Fact]
        public void CanApplyLogicalAndExpression()
            => CanApplyFilter("FooString='9001' AND BarInt='6'", e => e.FooString == "9001" && e.BarInt == 6);

        [Fact]
        public void CanApplyLogicalOrExpression()
            => CanApplyFilter("FooString='42' OR FooString='9001'", e => e.FooString == "42" || e.FooString == "9001");

        private static List<Entity> BuildEntities()
            => new List<Entity>
            {
                new Entity { BarInt = 1, FooString = "Nope", CorgeEnum = Count.None},
                new Entity { BarInt = 2, FooString = "42", CorgeEnum = Count.One },
                new Entity { BarInt = 3, FooString = "9001", CorgeEnum = Count.Two },
                new Entity { BarInt = 4, FooString = "421", CorgeEnum = Count.None },
                new Entity { BarInt = 5, FooString = "42", CorgeEnum = Count.One },
                new Entity { BarInt = 6, FooString = "42 ", CorgeEnum = Count.Two },
                new Entity { BarInt = 6, FooString = "9001", CorgeEnum = Count.Two },
                new Entity { BarInt = 7, FooString = "9001", CorgeEnum = Count.Two },
            };

        private static void CanApplyFilter(string filterString, Func<Entity, bool> filterFunc)
        {
            var list = BuildEntities();
            var predicate = FilterExpressionBuilder<Entity>.FromString(filterString);
            var actual = list.Where(predicate.Compile());
            var expected = list.Where(filterFunc);
            Assert.Equal(expected, actual);
        }
    }
}