using AutoMapper;
using BitcoinTicker.Application.Shared;
using BitcoinTicker.Application.Shared.BitcoinTicks;
using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;
using BitcoinTicker.Core;

namespace BitcoinTicker.Application.BitcoinTicks
{
    public class BitcoinPriceService : IBitcoinPriceService
    {
        private readonly IBitcoinPriceFactory _bitcoinPriceFactory;
        private readonly IBitcoinPriceRepository _bitcoinPriceRepository;
        private readonly IMapper _mapper;

        public BitcoinPriceService(IBitcoinPriceFactory bitcoinPriceFactory, IBitcoinPriceRepository bitcoinPriceRepository, IMapper mapper)
        {
            _bitcoinPriceFactory = bitcoinPriceFactory;
            _bitcoinPriceRepository = bitcoinPriceRepository;
            _mapper = mapper;
        }

        public Task<BitcoinPriceSourcesOutput> GetBitcoinPriceSources()
        {
            var sources = Enum.GetNames(typeof(BitcoinPriceSourceEnum)).ToList();
            var output = new BitcoinPriceSourcesOutput { Sources = sources };
            return Task.FromResult(output);
        }

        public async Task<BitcoinPriceDto> GetCurrentBitcoinPrice(GetCurrentBitcoinPriceRequestInput input)
        {
            if (Enum.TryParse<BitcoinPriceSourceEnum>(input.Source, true, out var sourceEnum))
            {

            }
            var provider = _bitcoinPriceFactory.GetProvider(sourceEnum);
            var result = await provider.GetCurrentBitcoinPrice(input);
            
            var priceEntity = _mapper.Map<BitcoinPrice>(result);
            await _bitcoinPriceRepository.InsertAsync(priceEntity);
            await _bitcoinPriceRepository.SaveChangesAsync();
            return _mapper.Map<BitcoinPriceDto>(priceEntity);
        }

        public async Task<BitcoinPriceHistoryOutput> GetBitcoinPriceHistory()
        {
            var result = new BitcoinPriceHistoryOutput();

            var lstEntities = await _bitcoinPriceRepository.GetAllListAsync();
            result.Prices = _mapper.Map<List<BitcoinPriceDto>>(lstEntities);

            return result;
        }
    }
}
