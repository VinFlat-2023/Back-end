using System.Dynamic;
using Service.IHelper;

namespace Service.Helper;

public class DynamicObjectPropertyExistExtension : IDynamicObjectPropertyExistExtension
{
    public bool DoesPropertyExist(dynamic obj, string name)
    {
        if (obj is ExpandoObject eo) return (eo as IDictionary<string, object>).ContainsKey(name);

        return obj.GetType().GetProperty(name);
    }
}