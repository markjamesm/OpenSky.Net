using Refit;

namespace OpenSky.Net.Models;

public class StateRequest
{
    /// <summary>
    /// The time in seconds since epoch (Unix timestamp) to retrieve states for. Current
    /// time will be used if omitted (optional).
    /// </summary>
    [AliasAs("time")]
    public int? Time { get; set; }
    
    /// <summary>
    /// One or more ICAO24 transponder addresses represented by a hex string (e.g. abc9f3).
    /// To filter multiple ICAO24 append the property once for each address. If omitted,
    /// the state vectors of all aircraft are returned (optional).
    /// </summary>
    [AliasAs("icao24")]
    public string? Icao24 { get; set; }
    
    /// <summary>
    /// Request the category of aircraft by setting the extended parameter to 1 (optional).
    /// </summary>
    [AliasAs("extended")]
    public int? Extended { get; set; }
    
    /// <summary>
    /// Lower bound for the latitude in decimal degrees (optional).
    /// </summary>
    [AliasAs("lamin")]
    public float? Lamin { get; set; }
    
    /// <summary>
    /// Lower bound for the longitude in decimal degrees (optional).
    /// </summary>
    [AliasAs("lomin")]
    public float? Lomin { get; set; }
    
    /// <summary>
    /// Upper bound for the latitude in decimal degrees (optional).
    /// </summary>
    [AliasAs("lamax")]
    public float? Lamax { get; set; }
    
    /// <summary>
    /// Upper bound for the longitude in decimal degrees (optional).
    /// </summary>
    [AliasAs("lomax")]
    public float? Lomax { get; set; }
}