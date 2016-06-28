using System;
using System.Configuration;
using System.IO;
using CollectedCompany.ServiceLayer.Integrations.AzureStorage.Bindings;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CollectedCompany.ServiceLayer.Integrations.AzureStorage.Impl
{
    public class AzureStorageService: IAzureStorageService
    {
        public String SaveImage(FileStream image, String fileName, String containerReference)
        {
            try
            {
                var account = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ToString());
                var client = account.CreateCloudBlobClient();
                var container = client.GetContainerReference(containerReference);

                if (!container.Exists())
                {
                    container.Create();
                    container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                var blob = container.GetBlockBlobReference(fileName + Guid.NewGuid() + Path.GetExtension(image.Name));
                using (image)
                {
                    blob.UploadFromStream(image);
                }
    
                return blob.Uri.ToString();
            }
            catch (Exception exception)
            {
                return String.Empty;
            }
        }

    }
}