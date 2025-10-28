using Application;
using Application.AuthenticationAction;
using AttributeInjection.Extensions;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Extensions;
using Core.IoC;
using Core.Security.Cors.Extensions;
using Core.Security.Jwt;
using Infrastructure;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers(config =>
{
    // config.Filters.Add<TokenValidationActionFilter>();
});

builder.WebHost.ConfigureKestrel(options => { options.AddServerHeader = false; });

// builder.WebHost.UseSentry();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();
builder.Services.AddAttributeInjection(new ApplicationRegistrator(), new PersistenceRegistrator(),
    new InfrastructureRegistrator());
builder.Services.AddExceptionHandler();
builder.Services.AddCorsPolicies();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddHttpContextAccessor();

DIInjectionTool.CopyServiceProvider(builder.Services.BuildServiceProvider());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsLocal())
{
    app.MapOpenApi();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseExceptionHandling();
// app.UseSentryTracing();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();