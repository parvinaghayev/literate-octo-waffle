namespace Core.CrossCuttingConcerns.Exceptions.Types
{
    public class BusinessException : Exception
    {
        public BusinessException() : base()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }
    }
}