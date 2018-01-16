using System;
using System.Collections.Generic;
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

        public async Task<double[]> GetAsync(string assetPairId)
        {
            var entity = await _tableStorage.GetDataAsync(FeedHoursHistoryEntity.GeneratePartition(),
                FeedHoursHistoryEntity.GenerateRowKey(assetPairId));

            return GetData(entity);
        }

        public async Task<Dictionary<string, double[]>> GetAllAsync()
        {
            var entities = await _tableStorage.GetDataAsync(FeedHoursHistoryEntity.GeneratePartition());

            return entities.ToDictionary(entity => entity.RowKey, GetData);
        }

        private static double[] GetData(FeedHoursHistoryEntity entity)
        {
            return entity?.Data?.Split(';').Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToArray() ?? Array.Empty<double>();
        }
    }
}
