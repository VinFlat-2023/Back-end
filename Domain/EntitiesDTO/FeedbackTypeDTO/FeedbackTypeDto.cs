using Domain.EntitiesDTO.FeedbackDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.FeedbackTypeDTO;

public class FeedbackTypeDto
{
    public int FeedbackTypeId { get; set; }

    public string Name { get; set; }

    [JsonIgnore] public virtual ICollection<FeedbackDto> Feedbacks { get; set; }
}