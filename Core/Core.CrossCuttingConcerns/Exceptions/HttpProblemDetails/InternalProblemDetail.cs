using System.Net;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Commons;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class InternalProblemDetail : BaseProblemDetail
    {
        public InternalProblemDetail(Exception exception)
        {
            Title = "Internal Exception";
            Detail = exception.Message;
            Status = (int)HttpStatusCode.InternalServerError;
            TraceId = GenerateTraceId();
        }
    }
}