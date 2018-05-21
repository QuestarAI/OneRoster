using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Questar.OneRoster.Common
{
    /// <summary>
    /// ISO 8601 parser. Attempts to more closely match standards than simple DateTime.Parse/ParseExact would provide.
    /// Derived from Stack Overflow answer here: https://stackoverflow.com/a/31246449/221867.
    /// </summary>
    public static class Iso8601
    {
        private static readonly Regex WeekAndDayRegex = new Regex(@"\b(\d{4})(-W(\d{2})-|W(\d{2}))(\d)(T\S+)?\b", RegexOptions.Compiled);
        private static readonly Regex ExcessiveFractions = new Regex(@"(\d(\.|,‎)\d{8,})", RegexOptions.Compiled);
        private static readonly Regex LeapSecond = new Regex("T23:?59:?60", RegexOptions.Compiled);

        private static readonly string[] FourYearFormats =
        {
            "yyyy-MM-ddK", "yyyyMMddK",
            "yyyy-MM-ddTHH:mm:ss.fffffffK", "yyyyMMddTHH:mm:ss.fffffffK",
            "yyyy-MM-ddTHH:mm:ss,fffffffK", "yyyyMMddTHH:mm:ss,fffffffK",
            "yyyy-MM-ddTHH:mm:ss.ffffffK", "yyyyMMddTHH:mm:ss.ffffffK",
            "yyyy-MM-ddTHH:mm:ss,ffffffK", "yyyyMMddTHH:mm:ss,ffffffK",
            "yyyy-MM-ddTHH:mm:ss.fffffK", "yyyyMMddTHH:mm:ss.fffffK",
            "yyyy-MM-ddTHH:mm:ss,fffffK", "yyyyMMddTHH:mm:ss,fffffK",
            "yyyy-MM-ddTHH:mm:ss.ffffK", "yyyyMMddTHH:mm:ss.ffffK",
            "yyyy-MM-ddTHH:mm:ss,ffffK", "yyyyMMddTHH:mm:ss,ffffK",
            "yyyy-MM-ddTHH:mm:ss.ffK", "yyyyMMddTHH:mm:ss.ffK",
            "yyyy-MM-ddTHH:mm:ss,ffK", "yyyyMMddTHH:mm:ss,ffK",
            "yyyy-MM-ddTHH:mm:ss.fK", "yyyyMMddTHH:mm:ss.fK",
            "yyyy-MM-ddTHH:mm:ss,fK", "yyyyMMddTHH:mm:ss,fK",
            "yyyy-MM-ddTHH:mm:ssK", "yyyyMMddTHH:mm:ssK",
            "yyyy-MM-ddTHHmmss.fffffffK", "yyyyMMddTHHmmss.fffffffK",
            "yyyy-MM-ddTHHmmss,fffffffK", "yyyyMMddTHHmmss,fffffffK",
            "yyyy-MM-ddTHHmmss.ffffffK", "yyyyMMddTHHmmss.ffffffK",
            "yyyy-MM-ddTHHmmss,ffffffK", "yyyyMMddTHHmmss,ffffffK",
            "yyyy-MM-ddTHHmmss.fffffK", "yyyyMMddTHHmmss.fffffK",
            "yyyy-MM-ddTHHmmss,fffffK", "yyyyMMddTHHmmss,fffffK",
            "yyyy-MM-ddTHHmmss.ffffK", "yyyyMMddTHHmmss.ffffK",
            "yyyy-MM-ddTHHmmss,ffffK", "yyyyMMddTHHmmss,ffffK",
            "yyyy-MM-ddTHHmmss.ffK", "yyyyMMddTHHmmss.ffK",
            "yyyy-MM-ddTHHmmss,ffK", "yyyyMMddTHHmmss,ffK",
            "yyyy-MM-ddTHHmmss.fK", "yyyyMMddTHHmmss.fK",
            "yyyy-MM-ddTHHmmss,fK", "yyyyMMddTHHmmss,fK",
            "yyyy-MM-ddTHHmmssK", "yyyyMMddTHHmmssK",
            "yyyy-MM-ddTHH:mmK", "yyyyMMddTHH:mmK",
            "yyyy-MM-ddTHHK", "yyyyMMddTHHK"
        };

        private static readonly string[] TwoYearFormats = {
            "yy-MM-ddK", "yyMMddK",
            "yy-MM-ddTHH:mm:ss.fffffffK", "yyMMddTHH:mm:ss.fffffffK",
            "yy-MM-ddTHH:mm:ss,fffffffK", "yyMMddTHH:mm:ss,fffffffK",
            "yy-MM-ddTHH:mm:ss.ffffffK", "yyMMddTHH:mm:ss.ffffffK",
            "yy-MM-ddTHH:mm:ss,ffffffK", "yyMMddTHH:mm:ss,ffffffK",
            "yy-MM-ddTHH:mm:ss.fffffK", "yyMMddTHH:mm:ss.fffffK",
            "yy-MM-ddTHH:mm:ss,fffffK", "yyMMddTHH:mm:ss,fffffK",
            "yy-MM-ddTHH:mm:ss.ffffK", "yyMMddTHH:mm:ss.ffffK",
            "yy-MM-ddTHH:mm:ss,ffffK", "yyMMddTHH:mm:ss,ffffK",
            "yy-MM-ddTHH:mm:ss.ffK", "yyMMddTHH:mm:ss.ffK",
            "yy-MM-ddTHH:mm:ss,ffK", "yyMMddTHH:mm:ss,ffK",
            "yy-MM-ddTHH:mm:ss.fK", "yyMMddTHH:mm:ss.fK",
            "yy-MM-ddTHH:mm:ss,fK", "yyMMddTHH:mm:ss,fK",
            "yy-MM-ddTHH:mm:ssK", "yyMMddTHH:mm:ss‎K",
            "yy-MM-ddTHHmmss.fffffffK", "yyMMddTHHmmss.fffffffK",
            "yy-MM-ddTHHmmss,fffffffK", "yyMMddTHHmmss,fffffffK",
            "yy-MM-ddTHHmmss.ffffffK", "yyMMddTHHmmss.ffffffK",
            "yy-MM-ddTHHmmss,ffffffK", "yyMMddTHHmmss,ffffffK",
            "yy-MM-ddTHHmmss.fffffK", "yyMMddTHHmmss.fffffK",
            "yy-MM-ddTHHmmss,fffffK", "yyMMddTHHmmss,fffffK",
            "yy-MM-ddTHHmmss.ffffK", "yyMMddTHHmmss.ffffK",
            "yy-MM-ddTHHmmss,ffffK", "yyMMddTHHmmss,ffffK",
            "yy-MM-ddTHHmmss.ffK", "yyMMddTHHmmss.ffK",
            "yy-MM-ddTHHmmss,ffK", "yyMMddTHHmmss,ffK",
            "yy-MM-ddTHHmmss.fK", "yyMMddTHHmmss.fK",
            "yy-MM-ddTHHmmss,fK", "yyMMddTHHmmss,fK",
            "yy-MM-ddTHHmmssK", "yyMMddTHHmmss‎K",
            "yy-MM-ddTHH:mmK", "yyMMddTHH:mmK",
            "yy-MM-ddTHHK", "yyMMddTHHK"
        };

        private static readonly string[] AllYearFormats = FourYearFormats.Concat(TwoYearFormats).ToArray();

        public static DateTime Parse(
        string iso8601String,
        MidpointRounding rounding = MidpointRounding.ToEven,
        YearFormat yearFormat = YearFormat.FourDigitYear,
        LeapSecondPolicy leapSecondPolicy = LeapSecondPolicy.EndOfDay)
        {
            var match = WeekAndDayRegex.Match(iso8601String);
            if (match.Success)
            {
                if (FromWeekAndDay(out iso8601String, match, out var dateTime))
                {
                    return dateTime;
                }
            }

            if (ExcessiveFractions.IsMatch(iso8601String))
            {
                iso8601String = ExcessiveFractions.Replace(
                  iso8601String,
                  m => decimal.Round(decimal.Parse(m.Value.Substring(0, Math.Max(m.Value.Length, 10))), 7, rounding).ToString());
            }

            if (iso8601String.Contains("T24"))
            {
                return ParseT24Date(iso8601String, rounding, yearFormat);
            }

            if (LeapSecond.IsMatch(iso8601String))
            {
                var oneSecondBefore = Parse(LeapSecond.Replace(iso8601String, "T23:59:59"));
                // Can't have fractions past second 60.
                if (oneSecondBefore.TimeOfDay != new TimeSpan(23, 59, 59))
                {
                    throw new FormatException();
                }

                // Can only be on --12-31 or --06-30
                if (oneSecondBefore.Month == 12 && oneSecondBefore.Day == 31 || oneSecondBefore.Month == 6 && oneSecondBefore.Day == 30)
                {
                    // Since DateTime can't handle leap seconds, we need a policy as to which side of it to be on.
                    return leapSecondPolicy == LeapSecondPolicy.EndOfDay
                        ? oneSecondBefore
                        : oneSecondBefore.AddSeconds(1);
                }

                throw new FormatException();
            }

            var formats = yearFormat == YearFormat.FourDigitYear
                ? FourYearFormats
                : yearFormat == YearFormat.FourOrTwoDigitYear
                    ? AllYearFormats
                    : TwoYearFormats;
            return DateTime.ParseExact(iso8601String, formats, CultureInfo.InvariantCulture, DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite);
        }

        private static DateTime ParseT24Date(string dateString, MidpointRounding rounding, YearFormat yearFormat)
        {
            var yesterday = Parse(dateString.Replace("T24", "T00"), rounding, yearFormat);
            if (yesterday.TimeOfDay != TimeSpan.Zero)
            {
                throw new FormatException();
            }
            return yesterday.AddDays(1);
        }

        private static bool FromWeekAndDay(out string iso8601String, Match match, out DateTime dateTime)
        {
            var year = int.Parse(match.Groups[1].Value);
            var week = int.Parse(match.Groups[3].Value + match.Groups[4].Value);
            var day = int.Parse(match.Groups[5].Value);
            if (year < 1 || year > 9999 || week < 1 || week > 53 || day < 1 || day > 7)
            {
                throw new FormatException();
            }

            var firstOfJanuary = new DateTime(year, 1, 1);
            var firstWeek = firstOfJanuary.DayOfWeek >= DayOfWeek.Friday
                ? firstOfJanuary.AddDays(firstOfJanuary.DayOfWeek - DayOfWeek.Monday - 1)
                : firstOfJanuary.AddDays(DayOfWeek.Monday - firstOfJanuary.DayOfWeek);
            var fromWeekAndDay = firstWeek.AddDays((week - 1) * 7 + day - 1);
            if (week > 51 && fromWeekAndDay > Parse(fromWeekAndDay.Year + "-W01-1"))
            {
                throw new FormatException();
            }

            if (match.Groups[6].Success)
            {
                // We're just going to let the handling for the other formats deal with any time fraction.
                iso8601String = fromWeekAndDay.ToString("yyyy-MM-dd") + match.Groups[6].Value;
                dateTime = DateTime.MinValue;
                return false;
            }

            iso8601String = null;
            dateTime = fromWeekAndDay;
            return true;
        }
    }
}