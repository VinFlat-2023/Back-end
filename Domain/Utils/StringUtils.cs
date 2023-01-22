namespace Domain.Utils;

public static class StringUtils
{
    public static bool IsNotEmpty(string? str)
    {
        return str != null && str.Trim().Length > 0;
    }

    public static bool IsEmpty(string? str)
    {
        return str == null || str.Trim().Length == 0;
    }
}