namespace Domain.ViewModel.BuildingEntity;

public class BuildingDetailEntity
{
    public string BuildingName { get; set; }
    public string BuildingPhoneNumber { get; set; }
    public BuildingManagerDetailEntity BuildingManager { get; set; }
}