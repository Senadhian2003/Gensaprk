using Azure.Storage.Blobs;
using VmSqlDemoApp.Services.Interfaces;

namespace VmSqlDemoApp.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public BlobService()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=senablobstorage;AccountKey=VOy0IosW//xfexUeEk1wtGE1J0D4J3QLnJFru1CEq/Kj64/IFCgh2R+rn/3S/UmJo0Zj8OCije5M+AStn1Tksg==;EndpointSuffix=core.windows.net";
            _blobServiceClient = new BlobServiceClient(connectionString);
            _containerName = "imagecontainer";
        }


        public async Task<string> UploadImageAsync(IFormFile file, string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, true);

            return blobClient.Uri.ToString();
        }



        public async Task<string> GetBlobUrlAsync(string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            return blobClient.Uri.ToString();
        }
    }
}
