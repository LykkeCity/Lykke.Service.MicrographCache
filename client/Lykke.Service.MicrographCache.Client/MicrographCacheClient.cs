using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
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

        public async Task<FeedHoursHistory> Get(string assetPairId)
        {
            return Mapper.Map<FeedHoursHistory>(await _micrographCache.ApiHistoryByAssetPairIdGetAsync(assetPairId));
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}
