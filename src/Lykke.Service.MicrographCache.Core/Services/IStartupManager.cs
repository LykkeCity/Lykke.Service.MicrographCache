using System.Threading.Tasks;

namespace Lykke.Service.MicrographCache.Core.Services
{
    public interface IStartupManager
    {
        Task StartAsync();
    }
}