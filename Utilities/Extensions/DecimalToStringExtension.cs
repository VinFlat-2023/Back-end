using System.Globalization;

namespace Utilities.Extensions;

public static class DecimalToStringExtension
{
    public static string DecimalToString(this decimal dec)
    {
        var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        var strDecimal = dec.ToString(CultureInfo.CurrentCulture);
        return strDecimal.Contains(separator) ? strDecimal.TrimEnd('0').TrimEnd(separator.ToCharArray()) : strDecimal;
    }
}