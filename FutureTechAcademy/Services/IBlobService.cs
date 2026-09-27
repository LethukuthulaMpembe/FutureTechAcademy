namespace FutureTechAcademy.Services
{
    public interface IBlobService
    {
        Task<string> UploadImageAsync(IFormFile file, string fileName);
        Task<string> GetSecureSasUrl(string fileName);
    }
}
