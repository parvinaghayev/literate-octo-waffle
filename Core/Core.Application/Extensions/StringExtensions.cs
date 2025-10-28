using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text)
        {
            if (text is null)
                return true;

            if (text == "")
                return true;

            return false;
        }

        public static int GetBase64Size(this string base64)
        {
            var bytes = Convert.FromBase64String(base64);
            int length = Encoding.UTF8.GetString(bytes).Length;

            return length;
        }

        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            string[] parts = fileName.Split('.');

            if (parts.Length > 1)
                return parts[parts.Length - 1];

            else
                return null;
        }
    }
}