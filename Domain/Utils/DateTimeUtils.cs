namespace Domain.Utils;

public static class DateTimeUtils
{
    private static readonly TimeZoneInfo AsiaStandardTime =
        TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

    public static DateTime GetCurrentDateTime()
    {
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, AsiaStandardTime);
    }
    
    public static DateTime? ConvertToDateTime(this string? dateString)
    {
        Console.WriteLine(dateString+"//////////////////////////////////////////////////");
        try
        {
            //  2009-05-08 14:40:52,531
            //  5/8/2009 14:40:52
            //  yyyy-MM-dd HH:mm:ss,fff

            string[] formats = {
                "d/M/yyyy HH:mm:ss", "d/M/yyyy",
                                "d/M/yyyy HH:mm: ss", "d / M / yyyy"};
            DateTime myDate = DateTime.ParseExact(dateString, formats,
                            System.Globalization.CultureInfo.InvariantCulture);
            return DateTime.ParseExact(dateString, formats,
                            System.Globalization.CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}