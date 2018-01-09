using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Service.MicrographCache.Core.Repositories;
using Lykke.Service.MicrographCache.Core.Services;
using Lykke.Service.MicrographCache.Services.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Lykke.Service.MicrographCache.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IFeedHoursHistoryRepository _feedHoursHistoryRepository;
        private readonly TimeSpan _cacheExpiration;

        public HistoryService(IDistributedCache distributedCache, IFeedHoursHistoryRepository feedHoursHistoryRepository, TimeSpan cacheExpiration)
        {
            _distributedCache = distributedCache;
            _feedHoursHistoryRepository = feedHoursHistoryRepository;
            _cacheExpiration = cacheExpiration;
        }

        public async Task<double[]> Get(string assetPairId)
        {
            return await _distributedCache.TryGetFromCache($"feed:{assetPairId}:history", async () => (await _feedHoursHistoryRepository.GetAsync(assetPairId)).Split(';').Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToArray(), _cacheExpiration);
        }
    }
}
