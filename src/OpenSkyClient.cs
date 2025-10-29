using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Options;
using OpenSky.Net.Models;
using Refit;

namespace OpenSky.Net;

public partial class OpenSkyClient
{
    private readonly IOpenSkyApi _openSkyApi;
    private readonly IOptions<OpenSkyOptions> _options;
    private readonly RateLimiter _rateLimiter;

    // public int MaxApiCallsPerMinute => _rateLimiter.MaxCallsPerMinute;

    internal OpenSkyClient(IOpenSkyApi openSkyApi, IOptions<OpenSkyOptions> options, RateLimiter rateLimiter)
    {
        _openSkyApi = openSkyApi;
        _options = options;
        _rateLimiter = rateLimiter;
    }

    public OpenSkyClient(int maxApiCallsPerMinute)
    {
        _rateLimiter = new RateLimiter(maxApiCallsPerMinute);
        _openSkyApi = RestService.For<IOpenSkyApi>(new HttpClient
        {
            BaseAddress = new Uri("https://opensky-network.org/api/")
        }, settings: new RefitSettings
        {
            // Add refit settings
        });
    }

    private async Task<TResponse> WrapApiCall<TResponse>(Func<Task<TResponse>> apiCall,
        CancellationToken cancellationToken)
    {
        using var lease = await _rateLimiter.AcquireAsync(cancellationToken).ConfigureAwait(false);
        if (!lease.IsAcquired)
        {
            ThrowHelper.ThrowTimeoutException();
        }

        return await apiCall().ConfigureAwait(false);
    }

    /// <summary>
    /// The following API call can be used to retrieve any state vector from the OpenSky API.
    /// </summary>
    /// <param name="stateRequest">The StateRequest parameters.</param>
    /// <param name="cancellationToken">Optional cancellation token for cancelling the API request.</param>
    /// <returns></returns>
    public Task<StateResponse> GetAllStateVectorsAsync(StateRequest? stateRequest = null, CancellationToken cancellationToken = default) =>
        WrapApiCall(() => _openSkyApi.GetAllStateVectorsAsync(cancellationToken, stateRequest), cancellationToken);

    public Task<MetadataResponse> GetAircraftMetadataAsync(string icao24, CancellationToken cancellationToken = default) =>
        WrapApiCall(() => _openSkyApi.GetAircraftMetadataAsync(icao24, cancellationToken), cancellationToken);
}