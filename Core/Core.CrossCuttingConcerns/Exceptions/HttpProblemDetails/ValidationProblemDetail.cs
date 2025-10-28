using System.Net;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Commons;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetail : BaseProblemDetail
    {
        [JsonProperty("errors")] Dictionary<string, List<string>> Errors;

        public ValidationProblemDetail(Exception exception)
        {
            Title = "Validation Exception";
            Detail = "One or more validation exception occured.";
            Status = (int)HttpStatusCode.UnprocessableEntity;
            TraceId = GenerateTraceId();
            Errors = (exception as ValidationException).Errors;
        }
    }
}