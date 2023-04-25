namespace Domain.ViewModel.AreaEntity;

public class AreaDetailEntity
{
    public int AreaId { get; set; }

    public string Name { get; set; }

    //public string Location { get; set; }
    public bool Status { get; set; }
    public string? AreaImageUrl1 { get; set; }
    public string? AreaImageUrl2 { get; set; }
    public string? AreaImageUrl3 { get; set; }
    public string? AreaImageUrl4 { get; set; }
}