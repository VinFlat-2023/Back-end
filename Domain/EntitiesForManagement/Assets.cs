namespace Domain.EntitiesForManagement;

public class Assets
{
    public int AssetId { get; set; }
    public int AssetTypeId { get; set; }
    public virtual AssetType AssetType { get; set; }
    public int NumberOfAssets { get; set; }
    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; }
}