namespace Questar.OneRoster.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Filtering;
    using Mock;
    using Xunit;
    using static Mock.Util;

    public class FilterExpressionParserTest
    {
        private static void AreEqual(string filter, Func<Entity, bool> expected) =>
            AreEqual(Entity.BuildEntities(), filter, expected);

        private static void AreEqual<T>(ICollection<T> source, string filter, Func<T, bool> expected) =>
            Are(Assert.Equal, source, filter, expected);

        private static void Are<T>(Action<IEnumerable<T>, IEnumerable<T>> assertion, ICollection<T> source, string filter, Func<T, bool> expected) =>
            assertion(source.Where(expected).ToList(), source.Where(Filter.Parse(filter).ToFilterExpression<T>().Compile()).ToList());

        [Fact]
        public void CanApplyContainsAllExpression() =>
            AreEqual("Subjects=subject1,subject2,subject3", e => new[] { "subject1", "subject2", "subject3" }.All(e.Subjects.Contains));

        [Fact]
        public void CanApplyContainsAnyExpression() =>
            AreEqual("Subjects~subject6,subject7,subject8", e => new[] { "subject6", "subject7", "subject8" }.Any(e.Subjects.Contains));

        [Fact]
        public void CanApplyDateTimeEqualExpression() =>
            AreEqual("BazDateTime='2018-05-21'", e => e.BazDateTime == UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeGreaterThanExpression() =>
            AreEqual("BazDateTime>'2018-05-21'", e => e.BazDateTime > UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeGreaterThanOrEqualExpression() =>
            AreEqual("BazDateTime>='2018-05-21'", e => e.BazDateTime >= UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeLessThanExpression() =>
            AreEqual("BazDateTime<'2018-05-21'", e => e.BazDateTime < UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeLessThanOrEqualExpression() =>
            AreEqual("BazDateTime<='2018-05-21'", e => e.BazDateTime <= UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeNotEqualExpression() =>
            AreEqual("BazDateTime!='2018-05-21'", e => e.BazDateTime != UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyEnumEqualExpression() =>
            AreEqual("CorgeEnum='One'", e => e.CorgeEnum == Count.One);

        [Fact]
        public void CanApplyEnumEqualExpressionWithInvalidValue() =>
            AreEqual("CorgeEnum='OutOfRange'", e => false);

        [Fact]
        public void CanApplyEnumNotEqualExpression() =>
            AreEqual("CorgeEnum!='One'", e => e.CorgeEnum != Count.One);

        [Fact]
        public void CanApplyEnumNotEqualExpressionWithInvalidValue() =>
            AreEqual("CorgeEnum!='OutOfRange'", e => true);

        [Fact]
        public void CanApplyGuidEqualExpression() =>
            AreEqual("QuxGuid='4D868BC4-34DE-4411-9F9F-9C5F1FAE1DDB'", e => e.QuxGuid == new Guid("4D868BC4-34DE-4411-9F9F-9C5F1FAE1DDB"));

        [Fact]
        public void CanApplyGuidNotEqualExpression() =>
            AreEqual("QuxGuid!='0D256148-18ED-452E-976A-80FDD3129DCD'", e => e.QuxGuid != new Guid("0D256148-18ED-452E-976A-80FDD3129DCD"));

        [Fact]
        public void CanApplyIntEqualExpression() =>
            AreEqual("BarInt='4'", e => e.BarInt == 4);
        
        [Fact]
        public void CanApplyIntGreaterThanExpression() =>
            AreEqual("BarInt>'5'", e => e.BarInt > 5);

        [Fact]
        public void CanApplyIntGreaterThanOrEqualExpression() =>
            AreEqual("BarInt>='5'", e => e.BarInt >= 5);

        [Fact]
        public void CanApplyIntLessThanExpression() =>
            AreEqual("BarInt<'5'", e => e.BarInt < 5);

        [Fact]
        public void CanApplyIntLessThanOrEqualExpression() =>
            AreEqual("BarInt<='5'", e => e.BarInt <= 5);

        [Fact]
        public void CanApplyIntNotEqualExpression() =>
            AreEqual("BarInt!='4'", e => e.BarInt != 4);

        [Fact]
        public void CanApplyLogicalAndExpression() =>
            AreEqual("FooString='9001' AND BarInt='6'", e => e.FooString == "9001" && e.BarInt == 6);

        [Fact]
        public void CanApplyLogicalAndOrExpression() =>
            AreEqual("FooString='42' AND BarInt='5' OR FooString='Nope'", e => e.FooString == "42" && e.BarInt == 5 || e.FooString == "Nope");

        [Fact]
        public void CanApplyLogicalOrAndExpression() =>
            AreEqual("FooString='Nope' OR FooString='42' AND BarInt='5'", e => e.FooString == "Nope" || e.FooString == "42" && e.BarInt == 5);

        [Fact]
        public void CanApplyLogicalOrExpression() =>
            AreEqual("FooString='42' OR FooString='9001'", e => e.FooString == "42" || e.FooString == "9001");

        [Fact]
        public void CanApplyLogicalOrOrOrExpression() =>
            AreEqual("BarInt='2' OR BarInt='4' OR BarInt='6'", e => e.BarInt == 2 || e.BarInt == 4 || e.BarInt == 6);

        [Fact]
        public void CanApplyStringEqualExpression() =>
            AreEqual("FooString='42'", e => e.FooString == "42");

        [Fact]
        public void CanApplyStringNotEqualExpression() =>
            AreEqual("FooString!='42'", e => e.FooString != "42");

        [Fact]
        public void CanParseStringEqual()
        {
            var expected = new FilterExpression<Entity>(e => e.FooString == "42");
            var actual = Filter.Parse("FooString='42'").ToFilterExpression<Entity>();
            Assert.True(ExpressionComparer.AreEqual(expected.Expression, actual.Expression));
        }
    }
}