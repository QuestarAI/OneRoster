namespace Questar.OneRoster.Test
{
    using static Mock.Util;
    using System;
    using System.Linq.Expressions;
    using Mock;
    using Query;
    using Xunit;

    public class FilterQueryStringBuilderTest
    {
        [Fact]
        public void CanApplyStringEqualExpression()
            => CanApplyFilter("FooString='42'", e => e.FooString == "42");

        [Fact]
        public void CanApplyStringNotEqualExpression()
            => CanApplyFilter("FooString!='42'", e => e.FooString != "42");

        [Fact]
        public void CanApplyEnumEqualExpression()
            => CanApplyFilter("CorgeEnum='One'", e => e.CorgeEnum == Count.One);

        [Fact]
        public void CanApplyEnumNotEqualExpression()
            => CanApplyFilter("CorgeEnum!='One'", e => e.CorgeEnum != Count.One);

        [Fact]
        public void CanApplyEnumEqualExpressionWithInvalidValue()
            => CanApplyFilter("CorgeEnum='OutOfRange'", e => false);

        [Fact]
        public void CanApplyEnumNotEqualExpressionWithInvalidValue()
            => CanApplyFilter("CorgeEnum!='OutOfRange'", e => true);

        [Fact]
        public void CanApplyIntEqualExpression()
            => CanApplyFilter(
                "BarInt='4'",
                e => (e.BarInt == 4));

        [Fact]
        public void CanApplyIntNotEqualExpression()
            => CanApplyFilter(
                "BarInt!='4'",
                e => e.BarInt != 4);

        [Fact]
        public void CanApplyIntGreaterThanExpression()
            => CanApplyFilter(
                "BarInt>'5'",
                e => e.BarInt > 5);

        [Fact]
        public void CanApplyIntGreaterThanOrEqualExpression()
            => CanApplyFilter(
                "BarInt>='5'",
                e => e.BarInt >= 5);

        [Fact]
        public void CanApplyIntLessThanExpression()
            => CanApplyFilter(
                "BarInt<'5'",
                e => e.BarInt < 5);

        [Fact]
        public void CanApplyIntLessThanOrEqualExpression()
            => CanApplyFilter(
                "BarInt<='5'",
                e => e.BarInt <= 5);

        [Fact]
        public void CanApplyDateTimeEqualExpression()
            => CanApplyFilter(
                "BazDateTime='2018-05-21'",
                e => e.BazDateTime == UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeNotEqualExpression()
            => CanApplyFilter(
                "BazDateTime!='2018-05-21'",
                e => e.BazDateTime != UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeGreaterThanExpression()
            => CanApplyFilter(
                "BazDateTime>'2018-05-21'",
                e => e.BazDateTime > UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeGreaterThanOrEqualExpression()
            => CanApplyFilter(
                "BazDateTime>='2018-05-21'",
                e => e.BazDateTime >= UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeLessThanExpression()
            => CanApplyFilter(
                "BazDateTime<'2018-05-21'",
                e => e.BazDateTime < UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeLessThanOrEqualExpression()
            => CanApplyFilter(
                "BazDateTime<='2018-05-21'",
                e => e.BazDateTime <= UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyGuidEqualExpression()
            => CanApplyFilter(
                "QuxGuid='4D868BC4-34DE-4411-9F9F-9C5F1FAE1DDB'",
                e => e.QuxGuid == new Guid("4D868BC4-34DE-4411-9F9F-9C5F1FAE1DDB"));

        [Fact]
        public void CanApplyGuidNotEqualExpression()
            => CanApplyFilter(
                "QuxGuid!='0D256148-18ED-452E-976A-80FDD3129DCD'",
                e => e.QuxGuid != new Guid("0D256148-18ED-452E-976A-80FDD3129DCD"));

        [Fact]
        public void CanApplyLogicalAndExpression()
            => CanApplyFilter(
                "FooString='9001' AND BarInt='6'",
                e => e.FooString == "9001" && e.BarInt == 6);

        [Fact]
        public void CanApplyLogicalOrExpression()
            => CanApplyFilter(
                "FooString='42' OR FooString='9001'",
                e => e.FooString == "42" || e.FooString == "9001");

        [Fact]
        public void CanApplyLogicalAndOrExpression()
            => CanApplyFilter(
                "FooString='42' AND BarInt='5' OR FooString='Nope'",
                e => e.FooString == "42" && e.BarInt == 5 || e.FooString == "Nope");

        [Fact]
        public void CanApplyLogicalOrAndExpression()
            => CanApplyFilter(
                "FooString='Nope' OR FooString='42' AND BarInt='5'",
                e => e.FooString == "Nope" || e.FooString == "42" && e.BarInt == 5);

        [Fact]
        public void CanApplyLogicalOrOrOrExpression()
            => CanApplyFilter(
                "BarInt = '2' OR BarInt = '4' OR BarInt = '6'",
                e => e.BarInt == 2 || e.BarInt == 4 || e.BarInt == 6);

        private static void CanApplyFilter(string expectedFilterString, Expression<Func<Entity, bool>> filterFunc)
        {
            var actual = FilterQueryStringBuilder<Entity>.FromExpression(filterFunc);
            Assert.Equal(expectedFilterString, actual);
        }
    }
}