using Autofac;
using Autofac.Extensions.DependencyInjection;
using AzureStorage.Tables;
using Common.Log;
using Lykke.Service.MicrographCache.AzureRepositories;
using Lykke.Service.MicrographCache.Core.Repositories;
using Lykke.Service.MicrographCache.Core.Services;
using Lykke.Service.MicrographCache.Core.Settings.ServiceSettings;
using Lykke.Service.MicrographCache.Services;
using Lykke.SettingsReader;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Service.MicrographCache.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<MicrographCacheSettings> _settings;
        private readonly ILog _log;
        // NOTE: you can remove it if you don't need to use IServiceCollection extensions to register service specific dependencies
        private readonly IServiceCollection _services;

        public ServiceModule(IReloadingManager<MicrographCacheSettings> settings, ILog log)
        {
            _settings = settings;
            _log = log;

            _services = new ServiceCollection();
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

            builder.RegisterType<HistoryService>().As<IHistoryService>()
                .WithParameter("cacheExpiration", _settings.CurrentValue.RedisSettings.CacheExpiration)
                .SingleInstance();

            var redis = new RedisCache(new RedisCacheOptions
            {
                Configuration = _settings.CurrentValue.RedisSettings.RedisConfiguration,
                InstanceName = _settings.CurrentValue.RedisSettings.InstanceName
            });

            builder.RegisterInstance(redis).As<IDistributedCache>().SingleInstance();

            builder.RegisterInstance<IFeedHoursHistoryRepository>(
                new FeedHoursHistoryRepository(
                    AzureTableStorage<FeedHoursHistoryEntity>.Create(_settings.Nested(x => x.Db).ConnectionString(x => x.HLiquidityConnString), "FeedHoursHistory", _log)));

            builder.Populate(_services);
        }        
    }
}
