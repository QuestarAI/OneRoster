namespace Questar.OneRoster.Test
{
    using System;
    using System.Linq;
    using Comparers;
    using Mocks;
    using Sorting;
    using Xunit;

    public class SortTest
    {
        [Fact]
        public void SortByAscMatchesOrderBy()
        {
            var entities = Entity.BuildEntities().AsQueryable();
            var expected = entities.OrderBy(e => e.Parent.Foo.Name).Expression;
            var actual = entities.SortBy("Parent.Foo.Name").Expression;
            Assert.True(ExpressionComparer.AreEqual(expected, actual));
        }

        [Fact]
        public void SortByAscReflectsSortByAsc()
        {
            var entities = Entity.BuildEntities().AsQueryable();
            var expected = entities.SortBy(e => e.Parent.Foo.Name).Expression;
            var actual = entities.SortBy("Parent.Foo.Name").Expression;
            Assert.True(ExpressionComparer.AreEqual(expected, actual));
        }

        [Fact]
        public void SortByDescMatchesOrderByDescending()
        {
            var entities = Entity.BuildEntities().AsQueryable();
            var expected = entities.OrderByDescending(e => e.Parent.Foo.Name).Expression;
            var actual = entities.SortBy("Parent.Foo.Name", SortDirection.Desc).Expression;
            Assert.True(ExpressionComparer.AreEqual(expected, actual));
        }

        [Fact]
        public void SortByDescReflectsSortByDesc()
        {
            var entities = Entity.BuildEntities().AsQueryable();
            var expected = entities.SortBy(e => e.Parent.Foo.Name, SortDirection.Desc).Expression;
            var actual = entities.SortBy("Parent.Foo.Name", SortDirection.Desc).Expression;
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