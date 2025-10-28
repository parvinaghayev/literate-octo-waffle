using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails.Commons
{
    public class BaseProblemDetail : ProblemDetails
    {
        [JsonProperty("traceId")] public string TraceId { get; set; }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        protected string GenerateTraceId()
            => $"{DateTime.Now:dd-MM-yyyy:HH:mm:ss}-{Guid.NewGuid().ToString()}";
    }
}