using Newtonsoft.Json;

namespace Domain.Models.Attributes;

public class UnescapeJsonStringConverter : JsonConverter<string>
{
    public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
    {
        writer.WriteValue(value);
    }

    public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        return JsonConvert.DeserializeObject<string>(reader.Value?.ToString() ?? string.Empty);
    }
}