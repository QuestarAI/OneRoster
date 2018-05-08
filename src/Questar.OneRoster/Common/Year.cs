namespace Questar.OneRoster.Common
{
    public struct Year
    {
        private int _year;
        public static implicit operator Year(int year) => new Year { _year = year };
        public static implicit operator int(Year p) => p._year;
    }
}