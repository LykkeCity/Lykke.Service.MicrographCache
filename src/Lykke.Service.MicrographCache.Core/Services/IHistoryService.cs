using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Service.MicrographCache.Core.Services
{
    public interface IHistoryService
    {
        double[] Get(string assetPairId);
        Dictionary<string, double[]> Get(string[] assetPairIds);
        Task UpdateCacheAsync();
    }
}
