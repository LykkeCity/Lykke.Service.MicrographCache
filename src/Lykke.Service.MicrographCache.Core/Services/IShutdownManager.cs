using System.Threading.Tasks;

namespace Lykke.Service.MicrographCache.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}