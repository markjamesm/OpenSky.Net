using OpenSky.Net.Enums;

namespace OpenSky.Net.Models;

public class StateVector
{
    /// <summary>
    /// Unique ICAO 24-bit address of the transponder in hex string representation.
    /// </summary>
    public string? Icao24 { get; set; }

    /// <summary>
    /// Callsign of the vehicle (8 chars). Can be null if no callsign has been received.
    /// </summary>
    public string? Callsign { get; set; }

    /// <summary>
    /// Country name inferred from the ICAO 24-bit address.
    /// </summary>
    public string? OriginCountry { get; set; }

    /// <summary>
    /// Unix timestamp (seconds) for the last position update. Can be null if no
    /// position report was received by OpenSky within the past 15s.
    /// </summary>
    public DateTimeOffset? TimePosition { get; set; }

    /// <summary>
    /// Unix timestamp (seconds) for the last update in general. This field is
    /// updated for any new, valid message received from the transponder.
    /// </summary>
    public DateTimeOffset? LastContactTime { get; set; }
    
    /// <summary>
    /// WGS-84 longitude in decimal degrees. Can be null.
    /// </summary>
    public float? Latitude { get; set; }
    
    /// <summary>
    /// WGS-84 latitude in decimal degrees. Can be null.
    /// </summary>
    public float? Longitude { get; set; }
    
    /// <summary>
    /// Barometric altitude in meters. Can be null.
    /// </summary>
    public float? BaroAltitude { get; set; }
    
    /// <summary>
    /// Boolean value which indicates if the position was retrieved from a
    /// surface position report.
    /// </summary>
    public bool? OnGround { get; set; }
    
    /// <summary>
    /// Velocity over ground in m/s. Can be null.
    /// </summary>
    public float? Velocity { get; set; }
    
    /// <summary>
    /// True track in decimal degrees clockwise from north (north=0°). Can be null.
    /// </summary>
    public float? TrueTrack { get; set; }
    
    /// <summary>
    /// Vertical rate in m/s. A positive value indicates that the airplane is
    /// climbing, a negative value indicates that it descends. Can be null.
    /// </summary>
    public float? VerticalRate { get; set; }
    
    /// <summary>
    /// IDs of the receivers which contributed to this state vector. Is null
    /// if no filtering for sensor was used in the request.
    /// </summary>
    public IReadOnlyList<int>? Sensors { get; set; }
    
    /// <summary>
    /// Geometric altitude in meters. Can be null.
    /// </summary>
    public float? GeoAltitude { get; set; }
    
    /// <summary>
    /// The transponder code aka Squawk. Can be null.
    /// </summary>
    public string? Squawk { get; set; }
    
    /// <summary>
    /// Whether flight status indicates special purpose indicator.
    /// </summary>
    public bool? Spi { get; set; }
    
    /// <summary>
    /// Origin of this state’s position.
    /// </summary>
    public PositionSource? PositionSource { get; set; } 
    
    // <summary>
    // Aircraft category. Is listed in the API documentation but
    // is not present in actual responses.
    // </summary>
    // public Category? Category { get; set; }
}