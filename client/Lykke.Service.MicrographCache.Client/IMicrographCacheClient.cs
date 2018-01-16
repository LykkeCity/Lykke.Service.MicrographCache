
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.MicrographCache.Contracts;

namespace Lykke.Service.MicrographCache.Client
{
    public interface IMicrographCacheClient
    {
        Task<FeedHoursHistory> GetAsync(string assetPairId);
        Task<Dictionary<string, double[]>> GetAsync(string[] assetPairIds);
    }
}
