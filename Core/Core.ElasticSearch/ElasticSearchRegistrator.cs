using Core.ElasticSearch.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.ElasticSearch
{
    public static class ElasticSearchRegistrator
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IElasticSearchService, ElasticSearchManager>();
            services.Configure<ElasticSearchSettings>(option =>
            {
                option.Uri = configuration["ElasticSearchSettings:Uri"];
                option.UserName = configuration["ElasticSearchSettings:UserName"];
                option.Password = configuration["ElasticSearchSettings:Password"];
            });

            return services;
        }
    }
}