using System;

namespace Questar.OneRoster.Common
{
    [Flags]
    public enum YearFormat
    {
        FourDigitYear = 1 << 0,
        TwoDigitYear = 1 << 1,
        FourOrTwoDigitYear = FourDigitYear | TwoDigitYear,
    }
}