using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AzureStorage;
using Lykke.Service.MicrographCache.Core.Repositories;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Service.MicrographCache.AzureRepositories
{
    public class FeedHoursHistoryEntity : TableEntity
    {
        public string Data { get; set; }

        public static string GeneratePartition()
        {
            return "micro";
        }

        public static string GenerateRowKey(string assetId)
        {
            return assetId;
        }
    }        

    public class FeedHoursHistoryRepository : IFeedHoursHistoryRepository
    {
        private INoSQLTableStorage<FeedHoursHistoryEntity> _tableStorage;

        public FeedHoursHistoryRepository(INoSQLTableStorage<FeedHoursHistoryEntity> tableStorage)
        {
            _tableStorage = tableStorage;
        }

        public async Task<string> GetAsync(string assetPairId)
        {
            var entity = await _tableStorage.GetDataAsync(FeedHoursHistoryEntity.GeneratePartition(),
                FeedHoursHistoryEntity.GenerateRowKey(assetPairId));
            return entity?.Data ?? "0";
        }
    }
}
