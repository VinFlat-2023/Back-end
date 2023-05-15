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

    public static DateTime ConvertToDateTime(this string dateString)
    {
        try
        {
            //  2009-05-08 14:40:52,531
            //  5/8/2009 14:40:52
            //  yyyy-MM-dd HH:mm:ss,fff


            return DateTime.ParseExact(dateString, "dd-MM-yyyy ", CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return DateTime.Now;
        }
    }

    public static DateTime ToDateTime(this string s,
        string format = "dd-MM-yyyy HH:mm:ss", string cultureString = "tr-TR")
    {
        var r = DateTime.ParseExact(
            s,
            format,
            CultureInfo.GetCultureInfo(cultureString));
        return r;
    }

    public static DateTime ToDateTime(this string s,
        string format, CultureInfo culture)
    {
        var r = DateTime.ParseExact(s, format,
            culture);
        return r;
    }
}