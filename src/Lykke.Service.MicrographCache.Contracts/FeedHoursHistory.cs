using System;

namespace Lykke.Service.MicrographCache.Contracts
{
    public class FeedHoursHistory
    {
        public string AssetPairId { get; set; }
        public double[] Changes { get; set; }
    }
}
