using Application.IRepository;
using Domain.CustomEntities.AzureStorage;
using Microsoft.AspNetCore.Http;
using Service.IService;

namespace Service.Service;

public class AzureStorageService : IAzureStorageService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public AzureStorageService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<BlobResponse?> UploadAsync(IFormFile? file, string containerName, string? fileExtension)
    {
        return await _repositoryWrapper.AzureStorage.UploadAsync(file, containerName, fileExtension);
    }

    public async Task<BlobResponse?> UpdateAsync(IFormFile? file, string? fileName, string containerName,
        string? fileExtension)
    {
        return await _repositoryWrapper.AzureStorage.UpdateFileAsync(file, fileName, containerName, fileExtension);
    }


    public async Task<Blob?> DownloadAsync(string blobFilename, string containerName)
    {
        return await _repositoryWrapper.AzureStorage.DownloadAsync(blobFilename, containerName);
    }

    public async Task<BlobResponse> DeleteAsync(string blobFilename, string containerName)
    {
        return await _repositoryWrapper.AzureStorage.DeleteAsync(blobFilename, containerName);
    }

    public async Task<List<Blob>> ListAsync(string containerName)
    {
        return await _repositoryWrapper.AzureStorage.ListAsync(containerName);
    }
}