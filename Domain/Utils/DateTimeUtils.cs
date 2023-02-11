namespace Domain.Utils;

public class DateTimeUtils
{
    private static readonly TimeZoneInfo Asia_Standar_Time =
        TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

    public static DateTime GetCurrentDateTime()
    {
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Asia_Standar_Time);
    }
}