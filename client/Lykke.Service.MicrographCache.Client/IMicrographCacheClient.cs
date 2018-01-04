
using System.Threading.Tasks;
using Lykke.Service.MicrographCache.Contracts;

namespace Lykke.Service.MicrographCache.Client
{
    public interface IMicrographCacheClient
    {
        Task<FeedHoursHistory> Get(string assetPairId);
    }
}
