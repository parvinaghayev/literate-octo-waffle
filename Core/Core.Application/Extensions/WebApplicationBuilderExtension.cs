using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace Core.Application.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static T GetEnvValue<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(
            this IConfiguration configuration, string key)
        {
            var envKey = key.Replace(':', '_');

            var value = configuration.GetValue<T>(envKey);

            if (value == null)
                value = configuration.GetValue<T>(key);

            return value;
        }
    }
}