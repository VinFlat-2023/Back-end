namespace Domain.ViewModel.RentalEntity;

public class BasicRentalEntity
{
    public int BuildingId { get; set; }
    public string BuildingName { get; set; }
    public int FlatId { get; set; }
    public string FlatName { get; set; }
    public int RoomFlatId { get; set; }
    
    public string RoomName { get; set; }
}