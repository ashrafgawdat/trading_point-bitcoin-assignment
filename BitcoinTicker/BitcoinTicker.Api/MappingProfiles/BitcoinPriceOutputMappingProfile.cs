using AutoMapper;
using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;
using BitcoinTicker.Core;

namespace BitcoinTicker.Api.MappingProfiles
{
    public class BitcoinPriceOutputMappingProfile : Profile
    {
        public BitcoinPriceOutputMappingProfile()
        {
            CreateMap<BitcoinPriceProviderOutput, BitcoinPriceOutput>();
            CreateMap<BitcoinPriceOutput, BitcoinPrice>().ReverseMap();
        }
    }
}
