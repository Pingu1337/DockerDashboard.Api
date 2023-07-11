using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Domain.Models.Attributes;

public class DockerDateTimeOffsetConverter : IsoDateTimeConverter
{
    public DockerDateTimeOffsetConverter()
    {
        DateTimeFormat = "yyyy-MM-dd HH:mm:ss zzz";
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString()))
        {
            return null;
        }

        var dateVal = reader.Value.ToString()?.Replace("CEST", string.Empty).Trim();

        return DateTimeOffset.TryParseExact(dateVal, DateTimeFormat, null, System.Globalization.DateTimeStyles.None,
            out var offset)
            ? offset
            : base.ReadJson(reader, objectType, existingValue, serializer);
    }
}