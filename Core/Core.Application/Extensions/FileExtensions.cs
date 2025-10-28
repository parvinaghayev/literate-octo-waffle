using Microsoft.AspNetCore.Http;

namespace Core.Application.Extensions;

public static class FileExtensions
{
    public static async Task<byte[]> GetBytesAsync(this IFormFile formFile)
    {
        await using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }

    public static string GetFileExtension(this IFormFile file)
    {
        if (file == null || file.Length == 0)
            return string.Empty;

        return Path.GetExtension(file.FileName);
    }

    public static long GetFileSize(this IFormFile file)
    {
        return file?.Length ?? 0;
    }

    public static async Task<string> ToBase64StringAsync(this IFormFile file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file));
        }

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            byte[] fileBytes = memoryStream.ToArray();
            string base64String = Convert.ToBase64String(fileBytes);

            return base64String;
        }
    }

    public static string GetFileNameWithoutExtention(this IFormFile file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file));
        }

        return Path.GetFileNameWithoutExtension(file.FileName);
    }

    public static string GetFileNameWithExtension(this IFormFile file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file));
        }

        return Path.GetFileName(file.FileName);
    }
}