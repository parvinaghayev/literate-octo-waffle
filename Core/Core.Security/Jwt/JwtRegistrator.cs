using Core.Security.Jwt.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Security.Jwt
{
    public static class JwtRegistrator
    {
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            ////Jwt Configuration
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(option =>
            //    {
            //        option.TokenValidationParameters = new()
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,

            //            ValidIssuer = configuration["Jwt:Issuer"],
            //            ValidAudience = configuration["Jwt:Audience"],
            //            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            //        };
            //    });

            //Jwt Services Adding
            services.AddSingleton<ITokenHelper, JwtTokenHelper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}