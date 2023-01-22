using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesDTO.MailMessageDTO;

public class MailMessageDto
{
    public List<string> Receivers { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public List<IFormFile> Attachments { get; set; }
}