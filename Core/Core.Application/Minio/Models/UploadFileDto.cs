using Microsoft.AspNetCore.Http;

namespace Core.Application.Minio.Models
{
    public class UploadFileDto
    {
        public UploadFileDto()
        {
        }

        public UploadFileDto(IFormFile? file)
        {
            File = file;
        }

        public IFormFile? File { get; set; }
    }
}