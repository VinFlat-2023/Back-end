using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Request;

public class RequestCreateRequest
{
    public string RequestName { get; set; } = null!;
    public string Description { get; set; } = null!;

    [Required] public DateTime CreateDate { get; set; }

    public DateTime? SolveDate { get; set; }
    public decimal? Amount { get; set; }
    public string Status { get; set; } = null!;
    [Required] public int RequestTypeId { get; set; }
}