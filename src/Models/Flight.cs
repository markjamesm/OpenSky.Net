using System.Text.Json.Serialization;
using OpenSky.Net.JsonConverters;

namespace OpenSky.Net.Models;

public class Flight
{
    [JsonPropertyName("icao24")] 
    public string Icao24 { get; set; } = "";

    [JsonPropertyName("firstSeen")]
    [JsonConverter(typeof(UnixTimeConverterSeconds))]
    public DateTimeOffset? FirstSeen { get; set; }

    [JsonPropertyName("estDepartureAirport")]
    public string EstDepartureAirport { get; set; } = "";

    [JsonPropertyName("lastSeen")]
    [JsonConverter(typeof(UnixTimeConverterSeconds))]
    public DateTimeOffset? LastSeen { get; set; }

    [JsonPropertyName("estArrivalAirport")]
    public string EstArrivalAirport { get; set; } = "";

    [JsonPropertyName("callsign")] 
    public string Callsign { get; set; } = "";

    [JsonPropertyName("estDepartureAirportHorizDistance")]
    public int? EstDepartureAirportHorizDistance { get; set; }

    [JsonPropertyName("estDepartureAirportVertDistance")]
    public int? EstDepartureAirportVertDistance { get; set; }

    [JsonPropertyName("estArrivalAirportHorizDistance")]
    public int? EstArrivalAirportHorizDistance { get; set; }

    [JsonPropertyName("estArrivalAirportVertDistance")]
    public int? EstArrivalAirportVertDistance { get; set; }

    [JsonPropertyName("departureAirportCandidatesCount")]
    public int? DepartureAirportCandidatesCount { get; set; }

    [JsonPropertyName("arrivalAirportCandidatesCount")]
    public int? ArrivalAirportCandidatesCount { get; set; }
}