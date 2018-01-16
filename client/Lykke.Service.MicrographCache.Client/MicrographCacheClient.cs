using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Service.MicrographCache.Client.AutorestClient;
using Lykke.Service.MicrographCache.Contracts;

namespace Lykke.Service.MicrographCache.Client
{
    public class MicrographCacheClient : IMicrographCacheClient, IDisposable
    {        
        private MicrographCacheAPI _micrographCache;

        public MicrographCacheClient(string serviceUrl)
        {
            _micrographCache = new MicrographCacheAPI(new Uri(serviceUrl));
        }

        public async Task<FeedHoursHistory> GetAsync(string assetPairId)
        {
            return Mapper.Map<FeedHoursHistory>(await _micrographCache.ApiHistoryByAssetPairIdGetAsync(assetPairId));
        }

        public async Task<Dictionary<string, double[]>> GetAsync(string[] assetPairIds)
        {
            return Mapper.Map<Dictionary<string, double[]>>(await _micrographCache.ApiHistoryAssetPairsPostAsync(assetPairIds));
        }

        public void Dispose()
        {
            if (_micrographCache == null)
                return;
            _micrographCache.Dispose();
            _micrographCache = null;
        }
    }
}
