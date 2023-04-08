using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Image;

public class MultipleImageUploadRequest
{
    public List<IFormFile> ImageUploadRequest { get; set; }
}