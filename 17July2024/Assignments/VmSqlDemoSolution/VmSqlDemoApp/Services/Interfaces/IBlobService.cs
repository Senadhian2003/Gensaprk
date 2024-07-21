namespace VmSqlDemoApp.Services.Interfaces
{
    public interface IBlobService
    {
        public Task<string> UploadImageAsync(IFormFile file, string blobName);

    }
}
