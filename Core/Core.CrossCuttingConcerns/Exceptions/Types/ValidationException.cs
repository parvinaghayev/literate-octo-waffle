namespace Core.CrossCuttingConcerns.Exceptions.Types
{
    public class ValidationException : Exception
    {
        public Dictionary<string, List<string>> Errors { get; set; }

        public ValidationException(Dictionary<string, List<string>> errors) : base()
        {
            this.Errors = errors;
        }

        public ValidationException(Dictionary<string, List<string>> errors, string message) : base(message)
        {
            this.Errors = errors;
        }
    }
}