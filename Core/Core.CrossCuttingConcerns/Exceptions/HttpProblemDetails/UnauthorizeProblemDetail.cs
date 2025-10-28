using System.Net;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Commons;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class UnauthorizeProblemDetail : BaseProblemDetail
    {
        public UnauthorizeProblemDetail(Exception exception)
        {
            Title = "Unauthorize Exception";
            Detail = exception.Message;
            Status = (int)HttpStatusCode.Unauthorized;
            TraceId = GenerateTraceId();
        }
    }
}