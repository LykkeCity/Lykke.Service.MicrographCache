using System.Globalization;
using System.Linq;
using Lykke.Service.MicrographCache.Contracts;

namespace Lykke.Service.MicrographCache.Services
{
    public static class FeedHoursHistoryExt
    {
        public static FeedHoursHistory ToDto(string assetPairId, string data)
        {
            return new FeedHoursHistory
            {
                AssetPairId = assetPairId,
                Changes = data.Split(';').Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToArray()
            };
        }
    }
}
