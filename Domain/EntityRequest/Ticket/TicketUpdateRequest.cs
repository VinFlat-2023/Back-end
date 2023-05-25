using System.ComponentModel.DataAnnotations;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Ticket;

public class TicketUpdateRequest
{
    public string TicketName { get; set; }
    public string Description { get; set; }

    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    public IFormFileCollection? ImageUploadRequest { get; set; }

    public int? TicketTypeId { get; set; }
}