using System.ComponentModel.DataAnnotations;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Image;

public class ImageUploadRequest
{
    [MaxUploadedFileSize(10 * 1024 * 1024)]
    [AllowedImageFileExtension(new[] { ".jpg", ".png", ".jpeg" })]
    [DataType(DataType.Upload)]
    public IFormFile Image { get; set; }
}