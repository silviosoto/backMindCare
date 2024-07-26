﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace API.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        private readonly string azureStorageConnectionString;

        public AzureStorageService(IConfiguration configuration)
        {
            // this.azureStorageConnectionString = configuration.GetValue<string>("AzureStorageConnectionString");
            this.azureStorageConnectionString = Environment.GetEnvironmentVariable("AzureStorageConnectionString");
        }

        //public async Task DeleteAsync(ContainerEnum container, string blobFilename)
        //{
        //    var containerName = Enum.GetName(typeof(ContainerEnum), container).ToLower();
        //    var blobContainerClient = new BlobContainerClient(this.azureStorageConnectionString, containerName);
        //    var blobClient = blobContainerClient.GetBlobClient(blobFilename);

        //    try
        //    {
        //        await blobClient.DeleteAsync();
        //    }
        //    catch
        //    {
        //    }
        //}

        public async Task<string> UploadAsync(IFormFile file,  string blobName = null)
        {
            if (file.Length == 0) return null;

            var containerName = "hojasdevidas";

            var blobContainerClient = new BlobContainerClient(this.azureStorageConnectionString, containerName);

            // Get a reference to the blob just uploaded from the API in a container from configuration settings
            if (string.IsNullOrEmpty(blobName))
            {
                blobName = Guid.NewGuid().ToString();
            }

            var blobClient = blobContainerClient.GetBlobClient(blobName);

            var blobHttpHeader = new BlobHttpHeaders { ContentType = file.ContentType };

            // Open a stream for the file we want to upload
            await using (Stream stream = file.OpenReadStream())
            {
                // Upload the file async
                await blobClient.UploadAsync(stream, new BlobUploadOptions { HttpHeaders = blobHttpHeader });
            }

            return blobName;
        }
    }

    public interface IAzureStorageService
    {
        /// <summary>
        /// This method uploads a file submitted with the request
        /// </summary>
        /// <param name="file">File for upload</param>
        /// <param name="container">Container where to submit the file</param>
        /// <param name="blobName">Blob name to update</param>
        /// <returns>File name saved in Blob contaienr</returns>
        Task<string> UploadAsync(IFormFile file, string blobName = null);

        /// <summary>
        /// This method deleted a file with the specified filename
        /// </summary>
        /// <param name="container">Container where to delete the file</param>
        /// <param name="blobFilename">Filename</param>
        //Task DeleteAsync(ContainerEnum container, string blobFilename);
    }
}
