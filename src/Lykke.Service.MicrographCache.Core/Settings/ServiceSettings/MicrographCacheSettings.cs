using System;

namespace Lykke.Service.MicrographCache.Core.Settings.ServiceSettings
{
    public class MicrographCacheSettings
    {
        public DbSettings Db { get; set; }

        public TimeSpan CacheUpdateInterval { get; set; }
    }
}
