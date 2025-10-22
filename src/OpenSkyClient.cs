using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Options;
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
}