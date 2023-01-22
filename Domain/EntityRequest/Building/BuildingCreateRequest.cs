using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Building;

public class BuildingCreateRequest
{
    [MaxLength(20, ErrorMessage = "Building Name length must less than 20")]
    public string BuildingName { get; set; }

    [MaxLength(200, ErrorMessage = "Description Name length must less than 200")]
    public string Description { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Floor numbers must not be negative")]
    public int? TotalFloor { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Room numbers must not be negative")]
    public int? TotalRooms { get; set; }

    public int? CoordinateX { get; set; }
    public int? CoordinateY { get; set; }
    public bool Status { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Area Id must not be negative")]
    public int AreaId { get; set; }
}