using System.Threading.Tasks;

namespace Lykke.Service.MicrographCache.Core.Repositories
{
    public interface IFeedHoursHistoryRepository
    {
        Task<string> GetAsync(string assetPairId);
    }
}
