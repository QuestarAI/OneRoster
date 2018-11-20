namespace Questar.OneRoster.Test
{
    using System;
    using System.Linq;
    using Mock;
    using Sorting;
    using Xunit;

    public class SortTest
    {
        [Fact]
        public void SortByAscReflects()
        {
            var entities = Entity.BuildEntities().AsQueryable();
            var expected = entities.SortBy(e => e.Parent.FooString).Expression;
            var actual = entities.SortBy("Parent.FooString").Expression;
            Assert.True(ExpressionComparer.AreEqual(expected, actual));
        }

        [Fact]
        public void SortByDescReflects()
        {
            var entities = Entity.BuildEntities().AsQueryable();
            var expected = entities.SortBy(e => e.Parent.FooString, SortDirection.Desc).Expression;
            var actual = entities.SortBy("Parent.FooString", SortDirection.Desc).Expression;
            Assert.True(ExpressionComparer.AreEqual(expected, actual));
        }

        [Fact]
        public void SortByInvalidPathThrows()
        {
            var entities = Entity.BuildEntities().AsQueryable();
            Assert.Throws<InvalidOperationException>(() => entities.SortBy("NotAProperty"));
        }
    }
}