namespace Core.CrossCuttingConcerns.Exceptions.Types
{
    public class UnauthorizeException : Exception
    {
        public UnauthorizeException() : base()
        {
        }

        public UnauthorizeException(string message) : base(message)
        {
        }
    }
}