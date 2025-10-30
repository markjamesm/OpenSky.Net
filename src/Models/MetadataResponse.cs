using System.Text.Json.Serialization;
using OpenSky.Net.JsonConverters;

namespace OpenSky.Net.Models;

public class MetadataResponse
{
        [JsonPropertyName("registration")] 
        public string Registration { get; set; } = "";

        [JsonPropertyName("manufacturerName")]
        public string ManufacturerName { get; set; } = "";

        [JsonPropertyName("manufacturerIcao")]
        public string ManufacturerIcao { get; set; } = "";

        [JsonPropertyName("model")]
        public string Model { get; set; } = "";

        [JsonPropertyName("typecode")]
        public string Typecode { get; set; } = "";

        [JsonPropertyName("serialNumber")]
        public string SerialNumber { get; set; } = "";

        [JsonPropertyName("lineNumber")]
        public string LineNumber { get; set; } = "";

        [JsonPropertyName("icaoAircraftClass")]
        public string IcaoAircraftClass { get; set; } = "";

        [JsonPropertyName("selCal")]
        public string SelCal { get; set; } = "";

        [JsonPropertyName("operator")]
        public string Operator { get; set; } = "";

        [JsonPropertyName("operatorCallsign")]
        public string OperatorCallsign { get; set; } = "";

        [JsonPropertyName("operatorIcao")]
        public string OperatorIcao { get; set; } = "";

        [JsonPropertyName("operatorIata")]
        public string OperatorIata { get; set; } = "";

        [JsonPropertyName("owner")]
        public string Owner { get; set; } = "";

        [JsonPropertyName("categoryDescription")]
        public string CategoryDescription { get; set; } = "";

        [JsonPropertyName("registered")]
        [JsonConverter(typeof(UnixTimeConverterMilliseconds))]
        public DateTimeOffset? Registered { get; set; }

        [JsonPropertyName("regUntil")]
        [JsonConverter(typeof(UnixTimeConverterMilliseconds))]
        public DateTimeOffset? RegUntil { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = "";

        [JsonPropertyName("built")]
        [JsonConverter(typeof(UnixTimeConverterMilliseconds))]
        public DateTimeOffset? Built { get; set; }

        [JsonPropertyName("firstFlightDate")]
        [JsonConverter(typeof(UnixTimeConverterMilliseconds))]
        public DateTimeOffset? FirstFlightDate { get; set; }

        [JsonPropertyName("engines")] 
        public string Engines { get; set; } = "";

        [JsonPropertyName("modes")]
        public bool? Modes { get; set; }

        [JsonPropertyName("adsb")]
        public bool? Adsb { get; set; }

        [JsonPropertyName("acars")]
        public bool? Acars { get; set; }

        [JsonPropertyName("vdl")]
        public bool? Vdl { get; set; }

        [JsonPropertyName("notes")] 
        public string Notes { get; set; } = "";

        [JsonPropertyName("country")] 
        public string Country { get; set; } = "";

        [JsonPropertyName("lastSeen")]
        [JsonConverter(typeof(UnixTimeConverterMilliseconds))]
        public DateTimeOffset? LastSeen { get; set; }

        [JsonPropertyName("firstSeen")]
        [JsonConverter(typeof(UnixTimeConverterMilliseconds))]
        public DateTimeOffset? FirstSeen { get; set; }

        [JsonPropertyName("icao24")] 
        public string Icao24 { get; set; } = "";

        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(UnixTimeConverterMilliseconds))]
        public DateTimeOffset? Timestamp { get; set; }
}