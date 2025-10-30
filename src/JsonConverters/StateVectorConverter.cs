using System.Text.Json;
using System.Text.Json.Serialization;
using OpenSky.Net.Enums;
using OpenSky.Net.Models;

namespace OpenSky.Net.JsonConverters;

internal sealed class StateVectorConverter : JsonConverter<IReadOnlyList<StateVector>>
{
    public override IReadOnlyList<StateVector> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // The OpenSky API returns states as an array of arrays
        
            var list = new List<StateVector>();
            if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException();

            reader.Read();
            while (reader.TokenType == JsonTokenType.StartArray)
            {
                list.Add(ReadSingleState(ref reader));
                reader.Read();
            }
            return list;
    }

    public override void Write(Utf8JsonWriter writer, IReadOnlyList<StateVector>? value, JsonSerializerOptions options)
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
    
    private StateVector ReadSingleState(ref Utf8JsonReader reader)
    {
        var sv = new StateVector();
        
        reader.Read(); 
        sv.Icao24 = reader.GetString() ?? "";
        
        reader.Read(); 
        sv.Callsign = reader.TokenType == JsonTokenType.String ? reader.GetString() : null;
        
        reader.Read(); 
        sv.OriginCountry = reader.GetString() ?? "";
        
        reader.Read(); 
        sv.TimePosition = reader.TokenType == JsonTokenType.Number ? DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(reader.GetInt64())) : null;
        
        reader.Read(); 
        sv.LastContactTime = reader.TokenType == JsonTokenType.Number ? DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(reader.GetInt64())) : null;
        
        reader.Read();
        sv.Longitude = reader.TokenType == JsonTokenType.Number ? reader.GetSingle() : null;
        
        reader.Read(); 
        sv.Latitude = reader.TokenType == JsonTokenType.Number ? reader.GetSingle() : null;
        
        reader.Read(); 
        sv.BaroAltitude = reader.TokenType == JsonTokenType.Number ? reader.GetSingle() : null;
        
        reader.Read(); 
        sv.OnGround = reader.TokenType is JsonTokenType.True or JsonTokenType.False ? reader.GetBoolean() : null;
        
        reader.Read(); 
        sv.Velocity = reader.TokenType == JsonTokenType.Number ? reader.GetSingle() : null;
        
        reader.Read(); 
        sv.TrueTrack = reader.TokenType == JsonTokenType.Number ? reader.GetSingle() : null;
        
        reader.Read(); 
        sv.VerticalRate = reader.TokenType == JsonTokenType.Number ? reader.GetSingle() : null;
        
        reader.Read();
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            var sensors = new List<int>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    sv.Sensors = sensors;
                    break;
                }
                
                sensors.Add(reader.GetInt32());
            }
        }

        if (reader.TokenType == JsonTokenType.Null)
        {
            sv.Sensors = null;
        }

        reader.Read(); 
        sv.GeoAltitude = reader.TokenType == JsonTokenType.Number ? reader.GetSingle() : null;
        
        reader.Read(); 
        sv.Squawk = reader.GetString() ?? "";
        
        reader.Read(); 
        sv.Spi = reader.TokenType is JsonTokenType.True or JsonTokenType.False ? reader.GetBoolean() : null;
        
        reader.Read();
        sv.PositionSource = reader.TokenType == JsonTokenType.Number ? (PositionSource)reader.GetSingle() : null;
        
        reader.Read();
        if (reader.TokenType == JsonTokenType.Number)
        {
            sv.Category = (Category)reader.GetInt32();
            reader.Read();
        }
        
        return sv;
    }
}