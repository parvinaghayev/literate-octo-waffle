using Core.Application.Minio.Models;

namespace Core.Application.Minio
{
    public interface IMinioService
    {
        string GenerateFileUrl(string token);
        Task<GetFileResponse> GetObject(string token);
        Task<string> PutObject(UploadFileDto request);
        Task<string> PutObject(string base64, string contentType);
    }
}