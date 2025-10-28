using AttributeInjection.Markers;
using Core.Application.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence;

public class PersistenceRegistrator : AssemblyRegistrator
{
    public override void AddDependenciesManually(IServiceCollection services)
    {
        IConfiguration? configuration = services.BuildServiceProvider().GetService<IConfiguration>();

        services.AddDbContext<DatabaseContext>(option =>
        {
            option.UseNpgsql(configuration.GetEnvValue<string>("Database:ConnectionStrings"));
        });
    }
}