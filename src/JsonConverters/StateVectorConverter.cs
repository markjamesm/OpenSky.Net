using System.Text.Json;
using System.Text.Json.Serialization;
using OpenSky.Net.Helpers;
using OpenSky.Net.Models;

namespace OpenSky.Net.JsonConverters;

public class StateVectorConverter : JsonConverter<List<StateVector>>
{
    public override List<StateVector> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stateVectors = new List<StateVector>();

        // The OpenSky API returns states as an array of arrays
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                if (reader.TokenType == JsonTokenType.StartArray)
                {
                    var rawStateVectors = new List<object?>();

                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            var stateVector = StateVectorMapper.MapToStateVector(rawStateVectors);
                            stateVectors.Add(stateVector);
                            break;
                        }

                        if (reader.TokenType == JsonTokenType.String)
                        {
                            rawStateVectors.Add(reader.GetString());
                        }

                        if (reader.TokenType == JsonTokenType.Number)
                        {
                            if (reader.TryGetSingle(out var x))
                            {
                                rawStateVectors.Add(x);
                            }

                            if (!reader.TryGetDouble(out var i))
                            {
                                rawStateVectors.Add(null);
                            }
                        }

                        if (reader.TokenType is JsonTokenType.True or JsonTokenType.False)
                        {
                            rawStateVectors.Add(reader.GetBoolean());
                        }

                        if (reader.TokenType is JsonTokenType.Null or JsonTokenType.None)
                        {
                            rawStateVectors.Add(null);
                        }
                    }
                }
            }
        }

        return stateVectors;
    }

    public override void Write(Utf8JsonWriter writer, List<StateVector> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}