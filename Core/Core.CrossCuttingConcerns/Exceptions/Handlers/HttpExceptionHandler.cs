using System.Net;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        protected override Task HandleException(BusinessException exception)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            return response.WriteAsync(new BusinessProblemDetail(exception).ToJson());
        }

        protected override Task HandleException(UnauthorizeException exception)
        {
            response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return response.WriteAsync(new UnauthorizeProblemDetail(exception).ToJson());
        }

        protected override Task HandleException(ValidationException exception)
        {
            response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            return response.WriteAsync(new ValidationProblemDetail(exception).ToJson());
        }

        protected override Task HandleException(ForbiddenException exception)
        {
            response.StatusCode = (int)HttpStatusCode.Forbidden;
            return response.WriteAsync(new ForbiddenProblemDetail(exception).ToJson());
        }

        protected override Task HandleException(Exception exception)
        {
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return response.WriteAsync(new InternalProblemDetail(exception).ToJson());
        }
    }
}