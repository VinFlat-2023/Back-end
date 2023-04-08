using System.ComponentModel.DataAnnotations;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Image;

public class MultipleImageUploadRequest
{
    [MaxUploadedFileSize(4 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    public List<IFormFile> ImageUploadRequest { get; set; }
}