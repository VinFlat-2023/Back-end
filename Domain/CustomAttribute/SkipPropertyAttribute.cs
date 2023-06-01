using System.Reflection;

namespace Utilities.Extensions;

public class SkipPropertyAttribute : Attribute
{
}

public static class TypeExtensions
{
    public static PropertyInfo[] GetFilteredProperties(this Type type)
    {
        return type.GetProperties().Where(pi => pi.GetCustomAttributes(typeof(SkipPropertyAttribute), true).Length == 0)
            .ToArray();
    }
}