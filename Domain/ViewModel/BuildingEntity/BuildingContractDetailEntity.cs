namespace Domain.ViewModel.BuildingEntity;

public class BuildingContractDetailEntity
{
    public int BuildingId { get; set; }
    public string BuildingName { get; set; }
    public string BuildingPhoneNumber { get; set; }
    public int AccountId { get; set; }
    public string BuildingAddress { get; set; }
    public AccountBuildingDetailEntity Account { get; set; }
}