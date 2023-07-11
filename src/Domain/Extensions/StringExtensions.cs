using Newtonsoft.Json;

namespace Domain.Extensions;

public static class StringExtensions
{
    public static T Deserialize<T>(this string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    }
}