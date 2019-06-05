using System;
using System.Linq.Expressions;
using Questar.OneRoster.Test.Comparers;
using Questar.OneRoster.Test.Mocks;
using Xunit;

namespace Questar.OneRoster.Test
{
    public class ExpressionComparerTest
    {
        [Fact]
        public void EquivalentExpressionsAreEqual()
        {
            // Note both parameters are named "e".
            Expression<Func<Entity, bool>> actual = e => e.FooString == "42";
            Expression<Func<Entity, bool>> expected = e => e.FooString == "42";
            Assert.True(ExpressionComparer.AreEqual(expected, actual));
        }

        [Fact]
        public void EquivalentExpressionsAreEqualRegardlessOfParameterName()
        {
            // Note one parameter is named "a" while the other is named "b".
            Expression<Func<Entity, bool>> actual = a => a.FooString == "42";
            Expression<Func<Entity, bool>> expected = b => b.FooString == "42";
            Assert.True(ExpressionComparer.AreEqual(expected, actual));
        }
    }
}