namespace Questar.OneRoster.Test.Mock
{
    using System;

    public class Util
    {
        internal static DateTime UtcDate(int year, int month, int day)
            => new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);

        internal static DateTime UtcDate(int year, int month, int day, int hour, int minute, int second)
            => new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
    }
}