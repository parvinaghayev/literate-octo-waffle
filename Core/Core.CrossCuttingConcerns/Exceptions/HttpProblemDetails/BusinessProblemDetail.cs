using System.Net;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Commons;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class BusinessProblemDetail : BaseProblemDetail
    {
        public BusinessProblemDetail(Exception exception)
        {
            Title = "Business Exception";
            Detail = exception.Message;
            Status = (int)HttpStatusCode.BadRequest;
            TraceId = GenerateTraceId();
        }
    }
}