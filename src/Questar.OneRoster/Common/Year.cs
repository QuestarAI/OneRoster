namespace Questar.OneRoster.Common
{
    /// <summary>
    /// A type alias representing a year as an integer.
    /// </summary>
    public struct Year
    {
        private int _year;
        public static implicit operator Year(int year) => new Year { _year = year };
        public static implicit operator int(Year p) => p._year;
    }
}