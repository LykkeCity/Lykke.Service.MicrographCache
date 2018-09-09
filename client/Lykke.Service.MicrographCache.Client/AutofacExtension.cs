using System;
using Autofac;
using Common.Log;
using Lykke.Common.Log;

namespace Lykke.Service.MicrographCache.Client
{
    public static class AutofacExtension
    {
        [Obsolete("Please, use the overload which does not require ILog instead.")]
        public static void RegisterMicrographCacheClient(this ContainerBuilder builder, string serviceUrl, ILog log)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (serviceUrl == null) throw new ArgumentNullException(nameof(serviceUrl));
            if (log == null) throw new ArgumentNullException(nameof(log));
            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            builder.RegisterInstance(new MicrographCacheClient(serviceUrl)).As<IMicrographCacheClient>().SingleInstance();
        }

        public static void RegisterMicrographCacheClient(this ContainerBuilder builder, string serviceUrl)
        {
            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            builder.RegisterInstance(new MicrographCacheClient(serviceUrl))
                .As<IMicrographCacheClient>()
                .SingleInstance();
        }
    }
}
