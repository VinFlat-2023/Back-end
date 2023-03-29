namespace Service.IHelper;

public interface IDynamicObjectPropertyExistExtension
{
    public bool DoesPropertyExist(dynamic obj, string property);
}