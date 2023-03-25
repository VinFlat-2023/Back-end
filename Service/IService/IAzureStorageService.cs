using Domain.CustomEntities.AzureStorage;
using Microsoft.AspNetCore.Http;

namespace Service.IService;

public interface IAzureStorageService
{
    /// <summary>
    ///     This method uploads a file submitted with the ticketFilterRequest
    /// </summary>
    /// <param name="file">File for upload</param>
    /// <param name="containerName"></param>
    /// <param name="fileExtension"></param>
    /// <returns>Blob with status</returns>
    Task<BlobResponse?> UploadAsync(IFormFile? file, string containerName, string? fileExtension);

    Task<BlobResponse?> UpdateAsync(IFormFile? file, string? fileName, string containerName, string? fileExtension);

    /// <summary>
    ///     This method downloads a file with the specified filename
    /// </summary>
    /// <param name="blobFilename">Filename</param>
    /// <param name="containerName"></param>
    /// <returns>Blob</returns>
    Task<Blob?> DownloadAsync(string blobFilename, string containerName);

    /// <summary>
    ///     This method deleted a file with the specified filename
    /// </summary>
    /// <param name="blobFilename">Filename</param>
    /// <param name="containerName"></param>
    /// <returns>Blob with status</returns>
    Task<BlobResponse> DeleteAsync(string blobFilename, string containerName);

    /// <summary>
    ///     This method returns a list of all files located in the container
    /// </summary>
    /// <returns>Blobs in a list</returns>
    Task<List<Blob>> ListAsync(string containerName);
}