namespace Core.ElasticSearch.Exceptions;

public class ElasticSearchException : Exception
{
    public ElasticSearchException() : base()
    {
    }

    public ElasticSearchException(string message) : base(message)
    {
    }
}