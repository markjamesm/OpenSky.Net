using OpenSky.Net.Models;
using Refit;

namespace OpenSky.Net;

public interface IOpenSkyApi
{
    [Get("/states/all")]
    Task<StateResponse> GetAllStateVectors(string callsign, CancellationToken cancellationToken);
}