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
                e => e.BarInt == 4);

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

        private static List<Entity> BuildEntities()
            => new List<Entity>
            {
                new Entity { BarInt = 1, BazDateTime = UtcDate(2017, 5, 21), QuxGuid = new Guid("0D256148-18ED-452E-976A-80FDD3129DCD"), FooString = "Nope", CorgeEnum = Count.None },
                new Entity { BarInt = 2, BazDateTime = UtcDate(2018, 5, 21), QuxGuid = new Guid("E773E550-6E27-48B5-84A2-9458A1CE7567"), FooString = "42", CorgeEnum = Count.One },
                new Entity { BarInt = 3, BazDateTime = UtcDate(2019, 5, 21), QuxGuid = new Guid("D1EACDDD-64C9-4415-8584-61CA46FDCCC5"), FooString = "9001", CorgeEnum = Count.Two },
                new Entity { BarInt = 4, BazDateTime = UtcDate(2018, 4, 21), QuxGuid = new Guid("0AB0AFA3-CAF4-4C3E-BFC2-99F7E5A6DE76"), FooString = "421", CorgeEnum = Count.None },
                new Entity { BarInt = 5, BazDateTime = UtcDate(2018, 5, 21), QuxGuid = new Guid("0792B838-2980-4633-B44B-2CA1D0EF9E21"), FooString = "42", CorgeEnum = Count.One },
                new Entity { BarInt = 6, BazDateTime = UtcDate(2018, 6, 21), QuxGuid = new Guid("13F17493-8C5F-43C8-9A1E-54D814E9AE9E"), FooString = "42 ", CorgeEnum = Count.Two },
                new Entity { BarInt = 6, BazDateTime = UtcDate(2018, 5, 20), QuxGuid = new Guid("9987E157-7796-49D7-B475-45AA87F79748"), FooString = "9001", CorgeEnum = Count.None },
                new Entity { BarInt = 7, BazDateTime = UtcDate(2018, 5, 21), QuxGuid = new Guid("4D868BC4-34DE-4411-9F9F-9C5F1FAE1DDB"), FooString = "9002", CorgeEnum = Count.One },
                new Entity { BarInt = 8, BazDateTime = UtcDate(2018, 5, 22), QuxGuid = new Guid("4FC1F6AC-69FC-47CF-99EF-12FC9ED1D896"), FooString = "9003", CorgeEnum = Count.Two },
            };

        private static void CanApplyFilter(string filterString, Func<Entity, bool> filterFunc)
        {
            var list = BuildEntities();
            var predicate = FilterExpressionBuilder<Entity>.FromString(filterString);
            var actual = list.Where(predicate.Compile());
            var expected = list.Where(filterFunc);
            Assert.Equal(expected, actual);
        }

        private static DateTime UtcDate(int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
            => new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
    }
}