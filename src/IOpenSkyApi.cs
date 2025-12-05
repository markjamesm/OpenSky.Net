using OpenSky.Net.Models;
using Refit;

namespace OpenSky.Net;

internal interface IOpenSkyApi
{
    [Get("/states/all")]
    Task<StateResponse> GetAllStateVectorsAsync(CancellationToken cancellationToken, StateRequest? stateRequest = null);
    
    [Get("/metadata/aircraft/icao/{icao24}")]
    Task<MetadataResponse> GetAircraftMetadataAsync(string icao24, CancellationToken cancellationToken);
    
    [Get("/flights/all")]
    Task<FlightResponse> GetFlightsAsync(FlightRequest flightRequest, CancellationToken cancellationToken);
}