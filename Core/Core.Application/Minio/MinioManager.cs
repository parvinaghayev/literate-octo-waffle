using Core.Application.Extensions;
using Core.Application.Minio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;

namespace Core.Application.Minio;

public class MinioManager : IMinioService
{
    private readonly IMinioClient _minioClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string? _bucket;

    public MinioManager(IMinioClientFactory minioClientFactory, IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration)
    {
        _minioClient = minioClientFactory.CreateClient();
        _httpContextAccessor = httpContextAccessor;
        _bucket = configuration["Minio:Bucket"];
    }

    public string GenerateFileUrl(string token)
    {
        string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLowerInvariant();

        var host = _httpContextAccessor?.HttpContext?.Request.Host.Value;

        string protocol = environment switch
        {
            "staging" or "production" or "testing" => "https",
            _ => "http"
        };

        return $"{protocol}://{host}/api/v1/file/getFile/{token}";
    }

    public async Task<GetFileResponse> GetObject(string token)
    {
        if (!await IsBucketExists(_bucket ?? ""))
            throw new Exception("NotFound");

        var contentType = await IsFileExists(token);

        var destination = new MemoryStream();

        var getObjectArgs = new GetObjectArgs()
            .WithBucket(_bucket)
            .WithObject(token)
            .WithCallbackStream((stream) => { stream.CopyTo(destination); });

        await _minioClient.GetObjectAsync(getObjectArgs);
        return new GetFileResponse(destination.ToArray(), contentType);
    }


    public async Task<string> PutObject(UploadFileDto request)
    {
        if (!await IsBucketExists(_bucket))
            throw new Exception("NotFound");

        var filestream = new MemoryStream(await request.File.GetBytesAsync());
        var filename = Guid.NewGuid().ToString();

        var putObjectArgs = new PutObjectArgs()
            .WithBucket(_bucket)
            .WithObject(filename)
            .WithStreamData(filestream)
            .WithObjectSize(filestream.Length)
            .WithContentType(request.File.ContentType);

        await _minioClient.PutObjectAsync(putObjectArgs);
        return filename;
    }

    private async Task<string> IsFileExists(string token)
    {
        var statObjectArgs = new StatObjectArgs()
            .WithBucket(_bucket)
            .WithObject(token);

        var status = await _minioClient.StatObjectAsync(statObjectArgs);

        if (status is null)
            throw new Exception("File not found or deleted");

        return status.ContentType;
    }

    private Task<bool> IsBucketExists(string bucket) =>
        _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucket));

    public async Task<string> PutObject(string base64, string contentType)
    {
        if (!await IsBucketExists(_bucket))
            throw new Exception("Bucket not founded in Minio");

        byte[] file = Convert.FromBase64String(base64);
        var filestream = new MemoryStream(file);
        var filename = Guid.NewGuid().ToString();

        var putObjectArgs = new PutObjectArgs()
            .WithBucket(_bucket)
            .WithObject(filename)
            .WithStreamData(filestream)
            .WithObjectSize(filestream.Length)
            .WithContentType(contentType);

        await _minioClient.PutObjectAsync(putObjectArgs);
        return filename;
    }
}