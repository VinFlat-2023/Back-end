using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Ticket
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TicketId { get; set; }

    public string TicketName { get; set; }
    public string Description { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public DateTime? SolveDate { get; set; }
    public decimal? TotalAmount { get; set; }
    public string? CancelledReason { get; set; }
    public string Status { get; set; } = null!;

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    [NotMapped]
    public IFormFile? Image { get; set; }

    public string? ImageUrl1 { get; set; }
    public string? ImageUrl2 { get; set; }
    public string? ImageUrl3 { get; set; }

    // Contract
    public int ContractId { get; set; }

    public virtual Contract Contract { get; set; }

    // Management
    public int? EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    public int TicketTypeId { get; set; }
    public virtual TicketType TicketType { get; set; }
}