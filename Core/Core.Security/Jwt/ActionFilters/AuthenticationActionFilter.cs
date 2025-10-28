using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.IoC;
using Core.Security.Jwt.Attributes;
using Core.Security.Jwt.Helpers;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.Security.Jwt.ActionFilters
{
    public class AuthenticationActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            if (actionDescriptor.MethodInfo.CustomAttributes.FirstOrDefault(a =>
                    a.AttributeType == typeof(IgnoreAuthenticationAttribute)) is not null)
                return;

            string token = context.HttpContext.Request.Headers.Authorization;
            ITokenHelper _tokenHelper = DIInjectionTool.GetService<ITokenHelper>();

            if (!_tokenHelper.ValidateToken(token))
                throw new UnauthorizeException("Your session has been expired.");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
    }
}