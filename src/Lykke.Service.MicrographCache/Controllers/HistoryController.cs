using System.Threading.Tasks;
using Lykke.Service.MicrographCache.Contracts;
using Lykke.Service.MicrographCache.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.MicrographCache.Controllers
{
    [Route("api/history")]
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;
        
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;            
        }

        [HttpGet("{assetPairId}")]
        public async Task<FeedHoursHistory> Get(string assetPairId)
        {
            return new FeedHoursHistory { Changes = await _historyService.Get(assetPairId) };
        }
    }
}
