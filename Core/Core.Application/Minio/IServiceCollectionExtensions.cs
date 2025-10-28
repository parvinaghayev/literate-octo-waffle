using Core.Application.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;

namespace Core.Application.Minio
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMinio(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddMinio(configureClient => configureClient
                .WithEndpoint(configuration["Minio:Client"])
                .WithCredentials(configuration.GetEnvValue<string>("Minio:AccessKey"),
                    configuration.GetEnvValue<string>("Minio:SecretKey"))
                .WithSSL(Convert.ToBoolean(configuration["Minio:SSL"])));

            services.AddScoped<IMinioService, MinioManager>();
            return services;
        }
    }
}