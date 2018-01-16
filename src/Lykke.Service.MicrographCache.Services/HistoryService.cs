using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.MicrographCache.Core.Repositories;
using Lykke.Service.MicrographCache.Core.Services;

namespace Lykke.Service.MicrographCache.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IFeedHoursHistoryRepository _feedHoursHistoryRepository;
        private ConcurrentDictionary<string, double[]> _cache;

        public HistoryService(IFeedHoursHistoryRepository feedHoursHistoryRepository)
        {
            _feedHoursHistoryRepository = feedHoursHistoryRepository;
        }

        public double[] Get(string assetPairId)
        {
            return  GetDataFromCache(assetPairId);
        }

        public Dictionary<string, double[]> Get(string[] assetPairIds)
        {
            var result = new Dictionary<string, double[]>();

            foreach (string assetPair in assetPairIds)
                result.Add(assetPair, GetDataFromCache(assetPair));

            return result;
        }

        public async Task UpdateCacheAsync()
        {
            _cache = new ConcurrentDictionary<string, double[]>(await _feedHoursHistoryRepository.GetAllAsync());
        }

        private double[] GetDataFromCache(string assetPair)
        {
            return _cache.ContainsKey(assetPair) ? _cache[assetPair] : Array.Empty<double>();
        }
    }
}
