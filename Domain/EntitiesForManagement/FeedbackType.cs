using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class FeedbackType
{
    public FeedbackType()
    {
        Feedbacks = new HashSet<Feedback>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbackTypeId { get; set; }

    public string Name { get; set; }
    public virtual ICollection<Feedback> Feedbacks { get; set; }
}