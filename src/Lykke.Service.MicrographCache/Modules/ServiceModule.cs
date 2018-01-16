using Autofac;
using AzureStorage.Tables;
using Common.Log;
using Lykke.Service.MicrographCache.AzureRepositories;
using Lykke.Service.MicrographCache.Core.Repositories;
using Lykke.Service.MicrographCache.Core.Services;
using Lykke.Service.MicrographCache.Core.Settings.ServiceSettings;
using Lykke.Service.MicrographCache.PeriodicalHandlers;
using Lykke.Service.MicrographCache.Services;
using Lykke.SettingsReader;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;

namespace Lykke.Service.MicrographCache.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<MicrographCacheSettings> _settings;
        private readonly ILog _log;

        public ServiceModule(IReloadingManager<MicrographCacheSettings> settings, ILog log)
        {
            _settings = settings;
            _log = log;
        }

        protected override void Load(ContainerBuilder builder)
        {            
            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();

            builder.RegisterType<HistoryService>()
                .As<IHistoryService>()
                .SingleInstance();

            builder.RegisterInstance<IFeedHoursHistoryRepository>(
                new FeedHoursHistoryRepository(
                    AzureTableStorage<FeedHoursHistoryEntity>.Create(_settings.Nested(x => x.Db).ConnectionString(x => x.HLiquidityConnString), "FeedHoursHistory", _log)));

            builder.RegisterType<CacheUpdaterHandler>()
                .As<IStartable>()
                .AutoActivate()
                .WithParameter(TypedParameter.From(_settings.CurrentValue.CacheUpdateInterval))
                .SingleInstance();
        }        
    }
}
