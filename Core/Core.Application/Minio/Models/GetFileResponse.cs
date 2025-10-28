namespace Core.Application.Minio.Models
{
    public class GetFileResponse
    {
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
        public string Url { get; set; }

        public GetFileResponse(byte[] bytes, string contentType, string? url = null)
        {
            Bytes = bytes;
            ContentType = contentType;
            Url = url;
        }
    }
}