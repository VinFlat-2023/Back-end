using Service.IHelper;

namespace Service.Helper;

public class DynamicObjectPropertyExistExtension : IDynamicObjectPropertyExistExtension
{
    public bool DoesPropertyExist(dynamic obj, string property)
    {
        return ((Type)obj.GetType()).GetProperties().Any(p => p.Name.Equals(property));
    }
}