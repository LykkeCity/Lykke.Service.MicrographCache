using System.Collections.Generic;
using AutoMapper;
using Lykke.Service.MicrographCache.Contracts;

namespace Lykke.Service.MicrographCache.Client
{
    public class ClientAutomapperProfile : Profile
    {
        public ClientAutomapperProfile()
        {
            CreateMap<AutorestClient.Models.FeedHoursHistory, FeedHoursHistory>();
            CreateMap<Dictionary<string, IList<double?>>, Dictionary<string, double[]>>();
        }
    }
}
