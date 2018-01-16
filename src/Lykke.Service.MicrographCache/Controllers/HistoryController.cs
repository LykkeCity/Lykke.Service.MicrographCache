using System.Collections.Generic;
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
        public FeedHoursHistory Get(string assetPairId)
        {
            return new FeedHoursHistory { Changes = _historyService.Get(assetPairId) };
        }
        
        [HttpPost("assetPairs")]
        public Dictionary<string, double[]> Get([FromBody]string[] assetPairIds)
        {
            return _historyService.Get(assetPairIds);
        }
    }
}
