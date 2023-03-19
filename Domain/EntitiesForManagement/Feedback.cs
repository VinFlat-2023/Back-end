using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Feedback
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbackId { get; set; }

    public string FeedbackTitle { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; } = null!;
    public int RenterId { get; set; }
    public virtual Renter Renter { get; set; } = null!;
    public int FeedbackTypeId { get; set; }
    public virtual FeedbackType FeedbackType { get; set; } = null!;
}