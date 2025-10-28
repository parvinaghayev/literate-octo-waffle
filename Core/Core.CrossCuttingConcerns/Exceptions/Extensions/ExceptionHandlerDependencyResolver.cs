using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Exceptions.Extensions
{
    public static class ExceptionHandlerDependencyResolver
    {
        public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
        {
            services.AddSingleton<ExceptionHandler, HttpExceptionHandler>();
            return services;
        }
    }
}