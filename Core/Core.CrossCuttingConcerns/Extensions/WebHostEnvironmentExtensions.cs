using Microsoft.AspNetCore.Hosting;

namespace Core.CrossCuttingConcerns.Extensions;

public static class WebHostEnvironmentExtensions
{
    public static bool IsLocal(this IWebHostEnvironment webHostEnvironment) =>
        webHostEnvironment.EnvironmentName == "Local";

    public static bool IsDev(this IWebHostEnvironment webHostEnvironment) =>
        webHostEnvironment.EnvironmentName == "Development";

    public static bool IsStaging(this IWebHostEnvironment webHostEnvironment) =>
        webHostEnvironment.EnvironmentName == "Staging";

    public static bool IsProduction(this IWebHostEnvironment webHostEnvironment) =>
        webHostEnvironment.EnvironmentName == "Production";
}