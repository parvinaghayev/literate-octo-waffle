using System.ComponentModel;

namespace Core.Application.Minio.Enums
{
    public enum FileTypeEnum : byte
    {
        [Description("application/pdf")] Pdf = 1,
        [Description("image/png")] Png = 2,
        [Description("image/jpeg")] Jpeg = 3,
        [Description("application/zip")] Zip = 4,

        [Description("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        Xlsx = 5,

        [Description("application/vnd.ms-excel")]
        Xls = 6,
        [Description("application/msword")] Doc = 7,

        [Description("application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        Docx = 8,
    }
}