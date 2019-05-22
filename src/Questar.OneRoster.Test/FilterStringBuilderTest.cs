namespace Questar.OneRoster.Test
{
    using System;
    using System.Linq.Expressions;
    using Filtering;
    using Mock;
    using static Mock.Util;

    public class FilterStringBuilderTest
    {
        private static void CanApplyFilter(string expected, Expression<Func<Entity, bool>> actual) =>
            Assert.Equal(expected, new FilterExpression<Entity>(actual).ToFilter().ToString(), StringComparer.OrdinalIgnoreCase);

        [Fact]
        public void CanApplyDateTimeEqualExpression() =>
            CanApplyFilter("BazDateTime='2018-05-21'", e => e.BazDateTime == UtcDate(2018, 5, 21));

        [Fact]
        public void CanApplyDateTimeGreaterThanExpression()
        {
            var datetime = UtcDate(2018, 5, 21);
            CanApplyFilter(
                "BazDateTime>'2018-05-21'",
                e => e.BazDateTime > datetime);
        }

        [Fact]
        public void CanApplyDateTimeGreaterThanOrEqualExpression()
        {
            var datetime = UtcDate(2018, 5, 21);
            CanApplyFilter(
                "BazDateTime>='2018-05-21'",
                e => e.BazDateTime >= datetime);
        }

        [Fact]
        public void CanApplyDateTimeLessThanExpression()
        {
            var datetime = UtcDate(2018, 5, 21);
            CanApplyFilter(
                "BazDateTime<'2018-05-21'",
                e => e.BazDateTime < datetime);
        }

        [Fact]
        public void CanApplyDateTimeLessThanOrEqualExpression()
        {
            var datetime = UtcDate(2018, 5, 21);
            CanApplyFilter(
                "BazDateTime<='2018-05-21'",
                e => e.BazDateTime <= datetime);
        }

        [Fact]
        public void CanApplyDateTimeNotEqualExpression()
        {
            var datetime = UtcDate(2018, 5, 21);
            CanApplyFilter(
                "BazDateTime!='2018-05-21'",
                e => e.BazDateTime != datetime);
        }

        [Fact]
        public void CanApplyEnumEqualExpression()
        {
            CanApplyFilter("CorgeEnum='One'", e => e.CorgeEnum == Count.One);
        }

        // do not explicitly support this
        //[Fact]
        //public void CanApplyEnumEqualExpressionWithInvalidValue()
        //{
        //    CanApplyFilter("CorgeEnum='OutOfRange'", e => e.CorgeEnum == Enum.Parse<Count>("OutOfRange"));
        //}

        [Fact]
        public void CanApplyEnumNotEqualExpression()
        {
            CanApplyFilter("CorgeEnum!='One'", e => e.CorgeEnum != Count.One);
        }

        // do not explicitly support this
        //[Fact]
        //public void CanApplyEnumNotEqualExpressionWithInvalidValue()
        //{
        //    CanApplyFilter("CorgeEnum!='OutOfRange'", e => e.CorgeEnum != Enum.Parse<Count>("OutOfRange"));
        //}

        [Fact]
        public void CanApplyGuidEqualExpression()
        {
            var guid = new Guid("4D868BC4-34DE-4411-9F9F-9C5F1FAE1DDB");
            CanApplyFilter(
                "QuxGuid='4D868BC4-34DE-4411-9F9F-9C5F1FAE1DDB'",
                e => e.QuxGuid == guid);
        }

        [Fact]
        public void CanApplyGuidNotEqualExpression()
        {
            var guid = new Guid("0D256148-18ED-452E-976A-80FDD3129DCD");
            CanApplyFilter(
                "QuxGuid!='0D256148-18ED-452E-976A-80FDD3129DCD'",
                e => e.QuxGuid != guid);
        }

        [Fact]
        public void CanApplyIntEqualExpression()
        {
            CanApplyFilter(
                "BarInt='4'",
                e => e.BarInt == 4);
        }

        [Fact]
        public void CanApplyIntGreaterThanExpression()
        {
            CanApplyFilter(
                "BarInt>'5'",
                e => e.BarInt > 5);
        }

        [Fact]
        public void CanApplyIntGreaterThanOrEqualExpression()
        {
            CanApplyFilter(
                "BarInt>='5'",
                e => e.BarInt >= 5);
        }

        [Fact]
        public void CanApplyIntLessThanExpression()
        {
            CanApplyFilter(
                "BarInt<'5'",
                e => e.BarInt < 5);
        }

        [Fact]
        public void CanApplyIntLessThanOrEqualExpression()
        {
            CanApplyFilter(
                "BarInt<='5'",
                e => e.BarInt <= 5);
        }

        [Fact]
        public void CanApplyIntNotEqualExpression()
        {
            CanApplyFilter(
                "BarInt!='4'",
                e => e.BarInt != 4);
        }

        [Fact]
        public void CanApplyLogicalAndExpression()
        {
            CanApplyFilter(
                "FooString='9001' AND BarInt='6'",
                e => e.FooString == "9001" && e.BarInt == 6);
        }

        [Fact]
        public void CanApplyLogicalAndOrExpression()
        {
            CanApplyFilter(
                "FooString='42' AND BarInt='5' OR FooString='Nope'",
                e => e.FooString == "42" && e.BarInt == 5 || e.FooString == "Nope");
        }

        [Fact]
        public void CanApplyLogicalOrAndExpression()
        {
            CanApplyFilter(
                "FooString='Nope' OR FooString='42' AND BarInt='5'",
                e => e.FooString == "Nope" || e.FooString == "42" && e.BarInt == 5);
        }

        [Fact]
        public void CanApplyLogicalOrExpression()
        {
            CanApplyFilter(
                "FooString='42' OR FooString='9001'",
                e => e.FooString == "42" || e.FooString == "9001");
        }

        [Fact]
        public void CanApplyLogicalOrOrOrExpression()
        {
            CanApplyFilter(
                "BarInt='2' OR BarInt='4' OR BarInt='6'",
                e => e.BarInt == 2 || e.BarInt == 4 || e.BarInt == 6);
        }

        [Fact]
        public void CanApplyStringEqualExpression()
        {
            CanApplyFilter("FooString='42'", e => e.FooString == "42");
        }

        [Fact]
        public void CanApplyStringNotEqualExpression()
        {
            CanApplyFilter("FooString!='42'", e => e.FooString != "42");
        }
    }
}