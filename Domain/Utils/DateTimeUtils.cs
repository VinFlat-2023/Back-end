using System.Globalization;

namespace Domain.Utils;

public static class DateTimeUtils
{
    private static readonly TimeZoneInfo AsiaStandardTime =
        TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

    public static DateTime GetCurrentDateTime()
    {
        return TimeZoneInfo
            .ConvertTimeFromUtc(DateTime.UtcNow, AsiaStandardTime);
    }

    public static DateTime ToDateTime(this string s,
        string format = "d/M/yyyy")
    {
        var r = DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
        return r;
    }
}