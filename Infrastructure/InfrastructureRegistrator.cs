using System.Reflection;
using AttributeInjection.Markers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class InfrastructureRegistrator : AssemblyRegistrator
{
    public override void AddDependenciesManually(IServiceCollection services)
    {
        IConfiguration? configuration = services.BuildServiceProvider().GetService<IConfiguration>();

        
        // services.AddElasticSearch(configuration);
        // services.AddSingleton<ILogger, ElasticSearchLogger>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}