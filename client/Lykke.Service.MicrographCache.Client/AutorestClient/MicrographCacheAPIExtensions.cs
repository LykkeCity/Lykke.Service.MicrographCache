// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Lykke.Service.MicrographCache.Client.AutorestClient
{
    using Lykke.Service;
    using Lykke.Service.MicrographCache;
    using Lykke.Service.MicrographCache.Client;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for MicrographCacheAPI.
    /// </summary>
    public static partial class MicrographCacheAPIExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='assetPairId'>
            /// </param>
            public static FeedHoursHistory ApiHistoryByAssetPairIdGet(this IMicrographCacheAPI operations, string assetPairId)
            {
                return operations.ApiHistoryByAssetPairIdGetAsync(assetPairId).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='assetPairId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<FeedHoursHistory> ApiHistoryByAssetPairIdGetAsync(this IMicrographCacheAPI operations, string assetPairId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiHistoryByAssetPairIdGetWithHttpMessagesAsync(assetPairId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Checks service is alive
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static object IsAlive(this IMicrographCacheAPI operations)
            {
                return operations.IsAliveAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Checks service is alive
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> IsAliveAsync(this IMicrographCacheAPI operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.IsAliveWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}