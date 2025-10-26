using System.Text.Json.Serialization;
using OpenSky.Net.JsonConverters;

namespace OpenSky.Net.Models;

public class StateResponse
{
    /// <summary>
    /// The time which the state vectors in this response are associated with.
    /// All vectors represent the state of a vehicle with the interval [time - 1, time].
    /// </summary>
    [JsonConverter(typeof(UnixTimeConverter))]
    public DateTimeOffset? Time { get; set; }
    
    /// <summary>
    /// The state of an aircraft is a summary of all tracking information (mainly position,
    /// velocity, and identity) at a certain point in time.
    /// </summary>
    [JsonPropertyName("states")]
    [JsonConverter(typeof(StateVectorConverter))]
    public IReadOnlyList<StateVector>? StateVectors { get; set; }
}