using System;
using System.Threading.Tasks;
using Common;
using Common.Log;
using Lykke.Service.MicrographCache.Core.Services;

namespace Lykke.Service.MicrographCache.PeriodicalHandlers
{
    public class CacheUpdaterHandler : TimerPeriod
    {
        private readonly IHistoryService _historyService;

        public CacheUpdaterHandler(
            IHistoryService historyService,
            TimeSpan cacheUpdateInterval,
            ILog log) :
            base(nameof(CacheUpdaterHandler), (int)cacheUpdateInterval.TotalMilliseconds, log)
        {
            _historyService = historyService;
        }

        public override async Task Execute()
        {
            await _historyService.UpdateCacheAsync();
        }
    }
}
