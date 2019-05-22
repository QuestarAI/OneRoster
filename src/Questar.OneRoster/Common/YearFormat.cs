namespace Questar.OneRoster.Common
{
    using System;

    [Flags]
    public enum YearFormat
    {
        FourDigitYear = 1 << 0,
        TwoDigitYear = 1 << 1,
        FourOrTwoDigitYear = FourDigitYear | TwoDigitYear
    }
}