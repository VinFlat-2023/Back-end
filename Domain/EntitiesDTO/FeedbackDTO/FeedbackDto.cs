using Domain.EntitiesDTO.FeedbackTypeDTO;
using Domain.EntitiesDTO.FlatDTO;
using Domain.EntitiesDTO.RenterDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.FeedbackDTO;

public class FeedbackDto
{
    public int FeedbackId { get; set; }

    public string? FeedbackTitle { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime CreateDate { get; set; }

    public int FlatId { get; set; }

    [JsonIgnore] public virtual FlatDto Flat { get; set; } = null!;

    public int RenterId { get; set; }

    [JsonIgnore] public virtual RenterDto Renter { get; set; } = null!;

    public int FeedbackTypeId { get; set; }

    [JsonIgnore] public virtual FeedbackTypeDto FeedbackType { get; set; } = null!;
}