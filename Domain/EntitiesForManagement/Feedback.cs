using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Feedback
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FeedbackId { get; set; }

    public string FeedbackTitle { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreateDate { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? ImageUrl { get; set; }
    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; } = null!;
    public int RenterId { get; set; }
    public virtual Renter Renter { get; set; } = null!;
    public int FeedbackTypeId { get; set; }
    public virtual FeedbackType FeedbackType { get; set; } = null!;
}