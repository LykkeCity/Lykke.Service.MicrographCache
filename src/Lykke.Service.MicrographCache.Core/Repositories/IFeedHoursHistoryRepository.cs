using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Service.MicrographCache.Core.Repositories
{
    public interface IFeedHoursHistoryRepository
    {
        Task<double[]> GetAsync(string assetPairId);
        Task<Dictionary<string, double[]>> GetAllAsync();
    }
}
