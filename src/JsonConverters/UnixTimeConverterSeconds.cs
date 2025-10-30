using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenSky.Net.JsonConverters;

internal sealed class UnixTimeConverterSeconds : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var unixTimeSeconds = reader.GetInt64();
        var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimeSeconds);
        
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
            writer.WriteStringValue(value?.ToString());
        }
    }
}