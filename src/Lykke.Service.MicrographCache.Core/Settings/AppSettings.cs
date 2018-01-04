using Lykke.Service.MicrographCache.Core.Settings.ServiceSettings;
using Lykke.Service.MicrographCache.Core.Settings.SlackNotifications;

namespace Lykke.Service.MicrographCache.Core.Settings
{
    public class AppSettings
    {
        public MicrographCacheSettings MicrographCacheService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}
