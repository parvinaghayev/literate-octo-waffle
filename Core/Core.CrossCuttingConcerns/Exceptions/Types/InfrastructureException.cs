namespace Core.CrossCuttingConcerns.Exceptions.Types
{
    public class InfrastructureException : Exception
    {
        public string? TraceId { get; set; } = null;

        public InfrastructureException() : base()
        {
        }

        public InfrastructureException(string message, string traceId) : base(message)
        {
            TraceId = traceId;
        }

        public InfrastructureException(string message) : base(message)
        {
        }
    }
}