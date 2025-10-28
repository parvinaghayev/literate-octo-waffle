using System.Reflection;
using AttributeInjection.Markers;
using Core.Application.Minio;
using Core.Application.Pipelines;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Application;

public class ApplicationRegistrator : AssemblyRegistrator
{
    public override void AddDependenciesManually(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        // services.AddMinio();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddHttpClient();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
    }
}