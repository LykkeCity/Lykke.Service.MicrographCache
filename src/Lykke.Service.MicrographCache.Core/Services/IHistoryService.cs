using System.Threading.Tasks;
using Lykke.Service.MicrographCache.Contracts;
using Lykke.Service.MicrographCache.Core.Repositories;

namespace Lykke.Service.MicrographCache.Core.Services
{
    public interface IHistoryService
    {
        Task<FeedHoursHistory> Get(string assetPairId);
    }
}
