using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Jwt.Attributes;
using Core.Security.Jwt.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace Application.AuthenticationAction
{
    public class TokenValidationActionFilter(IWebHostEnvironment hostEnvironment, ITokenHelper tokenHelper)
        : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            if (!ShouldIgnoreAuthentication(actionDescriptor))
            {
                var token = tokenHelper.GetCurrentToken();

                if (!tokenHelper.IsJwtToken(token))
                    throw new UnauthorizeException("Token is not valid");

                if ((hostEnvironment.IsProduction() || hostEnvironment.IsStaging()))
                {
                    // var tokenValidateResonse = await authorizationPort.CheckTokenValid(token);

                    if (false) //!tokenValidateResonse.Valid
                        throw new UnauthorizeException("Token is not valid");
                }
            }

            await next.Invoke();
        }

        private bool ShouldIgnoreAuthentication(ControllerActionDescriptor actionDescriptor)
        {
            return actionDescriptor.MethodInfo.CustomAttributes
                .Any(a => a.AttributeType == typeof(IgnoreAuthenticationAttribute));
        }
    }
}