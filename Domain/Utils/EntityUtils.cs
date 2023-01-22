namespace Domain.Utils;

public static class EntityUtils
{
    public static void CloneEntity<T>(this T source, T target)
    {
        foreach (var prop in source.GetType().GetProperties())
            target.GetType().GetProperty(prop.Name).SetValue(target, prop.GetValue(source, null), null);
    }
}