using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenSky.Net.JsonConverters;

public class UnixTimeConverterMilliseconds : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var unixTimeMilliseconds = reader.GetInt64();
        var dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMilliseconds);
        
        return dateTimeOffset;
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
        }

        else
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}