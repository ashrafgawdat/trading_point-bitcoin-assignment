using AutoMapper;
using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;

namespace BitcoinTicker.Api.MappingProfiles
{
    public class BitcoinPriceOutputMappingProfile : Profile
    {
        public BitcoinPriceOutputMappingProfile()
        {
            CreateMap<BitcoinPriceProviderOutput, BitcoinPriceOutput>();
        }
    }
}
