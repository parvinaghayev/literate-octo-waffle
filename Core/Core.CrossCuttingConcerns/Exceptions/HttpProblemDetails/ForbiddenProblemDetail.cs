using System.Net;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Commons;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ForbiddenProblemDetail : BaseProblemDetail
    {
        public ForbiddenProblemDetail(Exception exception)
        {
            Title = "Forbidden Exception";
            Detail = exception.Message;
            Status = (int)HttpStatusCode.Forbidden;
            TraceId = GenerateTraceId();
        }
    }
}