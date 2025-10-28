using Newtonsoft.Json;

namespace Core.Application.Extensions;

public static class DictionaryExtensions
{
    public static T ToObject<T>(this Dictionary<string, string> dict)
    {
        var json = JsonConvert.SerializeObject(dict);
        return JsonConvert.DeserializeObject<T>(json)!;
    }
}