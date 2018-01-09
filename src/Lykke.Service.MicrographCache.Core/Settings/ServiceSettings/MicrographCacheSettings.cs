using System;

namespace Lykke.Service.MicrographCache.Core.Settings.ServiceSettings
{
    public class MicrographCacheSettings
    {
        public DbSettings Db { get; set; }

        public RedisSettings RedisSettings { get; set; }
    }

    public class RedisSettings
    {
        public string RedisConfiguration { get; set; }
        public string InstanceName { get; set; }
        public TimeSpan CacheExpiration { get; set; }
    }
}
