using Refit;

namespace OpenSky.Net.Models;

public class FlightRequest
{
    /// <summary>
    /// Start of time interval to retrieve flights for as Unix time (seconds since epoch).
    /// </summary>
    [AliasAs("begin")]
    public long Begin { get; set; }
    
    /// <summary>
    /// End of time interval to retrieve flights for as Unix time (seconds since epoch).
    /// </summary>
    [AliasAs("end")]
    public long End { get; set; }
}