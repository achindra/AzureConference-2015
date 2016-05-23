using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ImageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ImageService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ImageService.svc or ImageService.svc.cs at the Solution Explorer and start debugging.
    public class ImageService : IImageService
    {
        public async void UploadImage( ImageInfo img)
        {
            try
            {       
                CloudStorageAccount act = CloudStorageAccount.Parse(  CloudConfigurationManager.GetSetting("StorageConn"));
                CloudBlobClient blobClient = act.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("imagecontainer");
                container.CreateIfNotExists();
                container.SetPermissions(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });
                CloudBlockBlob blockblob = container.GetBlockBlobReference(Guid.NewGuid().ToString()+ ".jpg");
                blockblob.UploadFromStream(new MemoryStream(img.ARGBBuffer));

               using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://hackproject.cloudapp.net:8080/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:
                    HttpResponseMessage response = await client.GetAsync("api/Image?blobUrl="+ blockblob.Uri.ToString());
                    if (response.IsSuccessStatusCode)
                    {
                       // return blockblob.Uri.ToString();
                    }
                }
                
                //return blockblob.Uri.ToString();
            }            
            catch (System.Exception ex)
            {
                //Helpers.LoggingHelper.Instance.LogException(ex, "Upload Image, general");
               // return ex.ToString();
            }
        }
    }
}
