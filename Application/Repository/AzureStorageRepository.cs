using Application.IRepository;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Domain.CustomEntities.AzureStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Repository;

public class AzureStorageRepository : IAzureStorageRepository
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    private readonly string _storageConnectionString;

    public AzureStorageRepository(IConfiguration configuration, ILoggerFactory logger)
    {
        _configuration = configuration;
        _storageConnectionString = configuration.GetValue<string>("TotallyNotConnectionString:ImageContainer");
        _logger = logger.CreateLogger<AzureStorageRepository>();
    }

    public async Task<BlobResponse?> UploadAsync(IFormFile? file, string containerName, string? fileExtension)
    {
        BlobResponse? response = new();

        // Get a reference to a container named in appsettings.json and then create it
        var container = new BlobContainerClient(_storageConnectionString, GetContainerName(containerName));
        //await container.CreateAsync();

        await container.CreateIfNotExistsAsync(PublicAccessType.Blob);

        try
        {
            if (file == null)
                return response = null;

            // Get a reference to the blob just uploaded from the API in a container from configuration settings

            var uniqueId = Guid.NewGuid();

            var client = container.GetBlobClient(uniqueId + file.FileName);

            // Open a stream for the file we want to upload
            await using (var data = file.OpenReadStream())
            {
                // Upload the file async
                await client.UploadAsync(data,
                    new BlobHttpHeaders
                    {
                        // fileExtension should be image/{extension}
                        ContentType = $"image/{fileExtension}"
                    });
            }

            // Everything is OK and file got uploaded
            response.Status = $"File {file.FileName} uploaded Successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;
        }
        // If the file already exists, we catch the exception and do not upload it
        catch (RequestFailedException ex)
            when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
        {
            _logger
                .LogError("File with name {FileFileName} already exists in container. " +
                          "Set another name to store the file in the container: " +
                          "\'{StorageContainerName}.\'",
                    file.FileName, containerName);
            response.Status = $"File with name {file.FileName} already exists. " +
                              "Please use another name to store your file.";
            response.Error = true;
            return response;
        }
        // If we get an unexpected error, we catch it here and return the error message
        catch (RequestFailedException ex)
        {
            // Log error to console and create a new response we can return to the requesting method
            _logger.LogError("Unhandled Exception. ID: {ExStackTrace} " +
                             "- Message: {ExMessage}", ex.StackTrace, ex.Message);
            response.Status = $"Unexpected error: {ex.StackTrace}. Check log with StackTrace ID.";
            response.Error = true;
            return response;
        }

        // Return the BlobUploadResponse object
        return response;
    }

    public async Task<BlobResponse?> UpdateFileAsync(IFormFile? file, string? fileName, string containerName,
        string? fileExtension, bool isPrivate)
    {
        BlobResponse? response = new();

        // Get a reference to a container named in appsettings.json and then create it
        var container = new BlobContainerClient(_storageConnectionString, GetContainerName(containerName));
        //await container.CreateAsync();

        switch (isPrivate)
        {
            case true:
                await container.CreateIfNotExistsAsync();
                break;
            case false:
                await container.CreateIfNotExistsAsync(PublicAccessType.Blob);
                break;
        }

        try
        {
            var fileToDelete = container.GetBlobClient(fileName);

            try
            {
                // delete current file to upload new one if exist
                if (await fileToDelete.DeleteIfExistsAsync())
                    _logger.LogInformation("File {@FileNameIfExist} was deleted", fileName);
                _logger.LogError("File {@FileNameIfExist} was not found", fileName);
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                // File did not exist, log to console and return new response to requesting method
                _logger.LogError("File {@FileNameIfExist} was not found and execution failed!", fileName);
            }

            // check there is a duplicate
            if (file == null)
                return response = null;

            // Get a reference to the blob just uploaded from the API in a container from configuration settings

            var uniqueId = Guid.NewGuid();

            var client = container.GetBlobClient(uniqueId + file.FileName);

            // Open a stream for the file we want to upload
            await using (var data = file.OpenReadStream())
            {
                // Upload the file async
                await client.UploadAsync(data,
                    new BlobHttpHeaders
                    {
                        // fileExtension should be image/{extension}
                        ContentType = $"image/{fileExtension}"
                    });
            }

            // Everything is OK and file got uploaded
            response.Status = $"File {file.FileName} uploaded Successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;
        }
        // If the file already exists, we catch the exception and do not upload it
        catch (RequestFailedException ex)
            when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
        {
            _logger
                .LogError("File with name {FileName} already exists in container. " +
                          "Set another name to store the file in the container: " +
                          "\'{StorageContainerName}.\'",
                    file?.FileName, containerName);
            response.Status = $"File with name {file.FileName} already exists. " +
                              "Please use another name to store your file.";
            response.Error = true;
            return response;
        }
        // If we get an unexpected error, we catch it here and return the error message
        catch (RequestFailedException ex)
        {
            // Log error to console and create a new response we can return to the requesting method
            _logger.LogError("Unhandled Exception. ID: {ExStackTrace} " +
                             "- Message: {ExMessage}", ex.StackTrace, ex.Message);
            response.Status = $"Unexpected error: {ex.StackTrace}. Check log with StackTrace ID.";
            response.Error = true;
            return response;
        }

        // Return the BlobUploadResponse object
        return response;
    }

    public async Task<Blob?> DownloadAsync(string blobFilename, string containerName)
    {
        // Get a reference to a container named in appsettings.json
        var client = new BlobContainerClient(_storageConnectionString, containerName);

        try
        {
            // Get a reference to the blob uploaded earlier from the API in the container from configuration settings
            var file = client.GetBlobClient(blobFilename);

            // Check if the file exists in the container
            if (await file.ExistsAsync())
            {
                var data = await file.OpenReadAsync();

                // Download the file details async
                var content = await file.DownloadContentAsync();

                // Add data to variables in order to return a BlobDto
                var contentType = content.Value.Details.ContentType;

                // Create new BlobDto with blob data from variables
                return new Blob
                {
                    Content = data,
                    Name = blobFilename,
                    ContentType = contentType
                };
            }
        }
        catch (RequestFailedException ex)
            when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
        {
            // Log error to console
            _logger.LogError("File {BlobFilename} was not found", blobFilename);
        }

        // File does not exist, return null and handle that in requesting method
        return null;
    }

    public async Task<BlobResponse> DeleteAsync(string blobFilename, string containerName)
    {
        var client = new BlobContainerClient(_storageConnectionString, containerName);

        var file = client.GetBlobClient(blobFilename);

        try
        {
            // Delete the file
            await file.DeleteAsync();
        }
        catch (RequestFailedException ex)
            when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
        {
            // File did not exist, log to console and return new response to requesting method
            _logger.LogError("File {BlobFilename} was not found", blobFilename);
            return new BlobResponse
            {
                Error = true,
                Status = $"File with name {blobFilename} not found."
            };
        }

        // Return a new BlobResponseDto to the requesting method
        return new BlobResponse
        {
            Error = false,
            Status = $"File: {blobFilename} has been successfully deleted."
        };
    }

    public async Task<List<Blob>> ListAsync(string containerName)
    {
        // Get a reference to a container named in appsettings.json
        var container = new BlobContainerClient(_storageConnectionString, containerName);

        // Create a new list object for 
        var files = new List<Blob>();

        await foreach (var file in container.GetBlobsAsync())
        {
            // Add each file retrieved from the storage container to the files list by creating a BlobDto object
            var uri = container.Uri.ToString();
            var name = file.Name;
            var fullUri = $"{uri}/{name}";

            files.Add(new Blob
            {
                Uri = fullUri,
                Name = name,
                ContentType = file.Properties.ContentType
            });
        }

        // Return all files to the requesting method
        return files;
    }

    private async Task<Uri> CreateSasTokenAdminAsync(string containerName)
    {
        var container = new BlobContainerClient(_storageConnectionString, GetContainerName(containerName));

        var blobSasBuilder = new BlobSasBuilder
        {
            StartsOn = DateTime.Now,
            ExpiresOn = DateTime.Now.AddDays(2),
            Resource = "c" // c = access to Container
        };
        blobSasBuilder
            .SetPermissions(
                BlobSasPermissions.Write
                | BlobSasPermissions.Add
                | BlobSasPermissions.Create
                | BlobSasPermissions.Delete
                | BlobSasPermissions.List
                | BlobSasPermissions.Read);

        return await Task.FromResult(container.GenerateSasUri(blobSasBuilder));
    }

    private async Task<Uri> CreateSasTokenUserAsync(string containerName)
    {
        var container = new BlobContainerClient(_storageConnectionString, GetContainerName(containerName));

        var blobSasBuilder = new BlobSasBuilder
        {
            StartsOn = DateTime.Now,
            ExpiresOn = DateTime.Now.AddHours(2),
            Resource = "c" // c = access to Container
        };
        blobSasBuilder
            .SetPermissions(
                BlobSasPermissions.Write
                | BlobSasPermissions.Add);

        return await Task.FromResult(container.GenerateSasUri(blobSasBuilder));
    }

    private string GetContainerName(string containerName)
    {
        return _configuration.GetValue<string>($"ContainerNames:{containerName}");
    }
}