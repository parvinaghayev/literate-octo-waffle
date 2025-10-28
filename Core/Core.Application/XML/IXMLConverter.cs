namespace Core.Application.XML
{
    // ReSharper disable once InconsistentNaming
    public interface IXMLConverter
    {
        string ObjectToString(object @object, bool ignoreXMLDefaultHeader = false);
        T StringToObject<T>(string xmlText);
    }
}