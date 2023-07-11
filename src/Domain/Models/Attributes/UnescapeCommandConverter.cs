using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Domain.Models.Attributes;

public class UnescapeCommandConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(string);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return reader.Value?.ToString()?.Replace("\"", "");
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var token = JToken.FromObject(value);
        var command = token.ToString();
        writer.WriteRawValue(command);
    }
}