using SkiaSharp;
using ZXing;
using ZXing.Common;

public static class GenerateBarcodeExtensions
{
    public static string GenerateBarcode(string text)
    {
        var writer = new BarcodeWriterPixelData
        {
            Format = BarcodeFormat.CODE_128,
            Options = new EncodingOptions
            {
                Width = 192,
                Height = 55
            }
        };

        var pixelData = writer.Write(text);

        var info = new SKImageInfo(pixelData.Width, pixelData.Height, SKColorType.Bgra8888, SKAlphaType.Premul);

        using var bitmap = new SKBitmap(info);
        IntPtr pixelsPtr = bitmap.GetPixels();

        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, pixelsPtr, pixelData.Pixels.Length);

        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);

        var base64String = Convert.ToBase64String(data.ToArray());

        return base64String;
    }
}