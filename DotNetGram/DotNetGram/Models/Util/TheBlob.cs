using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetGram.Models.Util
{

    public class TheBlob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        public TheBlob(IConfiguration configuration)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuration["BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();

        }

        // Find container
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer containerRef = CloudBlobClient.GetContainerReference(containerName);
            await containerRef.CreateIfNotExistsAsync();
            await containerRef.SetPermissionsAsync(new BlobContainerPermissions
                                                    { PublicAccess = BlobContainerPublicAccessType.Blob });
            return containerRef;
        }

        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            CloudBlobContainer container = await GetContainer(containerName);
            CloudBlob blob = container.GetBlockBlobReference(imageName);
            return blob;

        }

        public async Task<string> UploadBlob(string containerName, string fileName, string filePath)
        {
            CloudBlobContainer container = await GetContainer(containerName);
            return await UploadBlob(container, fileName, filePath);
            
        }

        // Uploads the file at the given file path to a blob container with the given file name, and returns the Uri to that blob object.
        public async Task<string> UploadBlob(CloudBlobContainer container, string fileName, string filePath)
        {
            CloudBlockBlob blobRef = container.GetBlockBlobReference(fileName);
            await blobRef.UploadFromFileAsync(filePath);
            return blobRef.Uri.AbsoluteUri;
        }
    }
}
