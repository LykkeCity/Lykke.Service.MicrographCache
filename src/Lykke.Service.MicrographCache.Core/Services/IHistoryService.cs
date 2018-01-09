using System.Threading.Tasks;

namespace Lykke.Service.MicrographCache.Core.Services
{
    public interface IHistoryService
    {
        Task<double[]> Get(string assetPairId);
    }
}
