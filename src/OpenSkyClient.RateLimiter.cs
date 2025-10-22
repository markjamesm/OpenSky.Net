using System.Threading.RateLimiting;

namespace OpenSky.Net;

public sealed partial class OpenSkyClient
{
    internal sealed class RateLimiter : IAsyncDisposable
    {
        private readonly SlidingWindowRateLimiter _limiter;

        public RateLimiter(int maxCallsPerMinute)
        {
            MaxCallsPerMinute = maxCallsPerMinute;
            _limiter = new SlidingWindowRateLimiter(
                new SlidingWindowRateLimiterOptions
                {
                    PermitLimit = maxCallsPerMinute,
                    QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                    QueueLimit = int.MaxValue,
                    Window = TimeSpan.FromMinutes(1),
                    SegmentsPerWindow = 6,
                });
        }

        public int MaxCallsPerMinute { get; }

        public ValueTask<RateLimitLease> AcquireAsync(CancellationToken cancellationToken) =>
            _limiter.AcquireAsync(1, cancellationToken);

        public ValueTask DisposeAsync() => _limiter.DisposeAsync();
    }    
}