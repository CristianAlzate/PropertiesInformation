using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Core.DTO;
using Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class FilesRepository : IFilesRepository
    {

        public async Task<bool> UploadImage(FileUploadProperties fileProperties)
        {
            try
            {
                BlobContainerClient client = new BlobContainerClient(fileProperties.containerProperties.ConnectionString, fileProperties.containerProperties.Container);
                BlobClient blobClient = client.GetBlobClient(fileProperties.FileName);
                BlobUploadOptions uploadOptions = new BlobUploadOptions();
                uploadOptions.HttpHeaders = new BlobHttpHeaders();
                uploadOptions.HttpHeaders.ContentType = fileProperties.ContentType;
                var uploadedFile = await blobClient.UploadAsync(fileProperties.memoryStream, uploadOptions);
                if (uploadedFile.GetRawResponse().Status == 201)    
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
