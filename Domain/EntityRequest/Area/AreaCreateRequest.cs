using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Area;

public class AreaCreateRequest
{
    [MaxLength(20, ErrorMessage = "Name length must be less than 20")]
    public string Name { get; set; } = null!;

    [MaxLength(30, ErrorMessage = "Location length must be less than 30")]
    public string Location { get; set; } = null!;

    public bool Status { get; set; }
}