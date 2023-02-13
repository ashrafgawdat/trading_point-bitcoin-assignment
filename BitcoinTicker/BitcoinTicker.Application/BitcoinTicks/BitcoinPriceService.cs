using BitcoinTicker.Application.Shared.BitcoinTicks;
using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;

namespace BitcoinTicker.Application.BitcoinTicks
{
    public class BitcoinPriceService : IBitcoinPriceService
    {
        private readonly IBitcoinPriceFactory _bitcoinPriceFactory;

        public BitcoinPriceService(IBitcoinPriceFactory bitcoinPriceFactory)
        {
            _bitcoinPriceFactory = bitcoinPriceFactory;
        }

        public Task<BitcoinPriceSourcesOutput> GetBitcoinPriceSources()
        {
            var sources = Enum.GetNames(typeof(BitcoinPriceSourceEnum)).ToList();
            var output = new BitcoinPriceSourcesOutput { Sources = sources };
            return Task.FromResult(output);
        }

        public async Task<BitcoinPriceOutput> GetCurrentBitcoinPrice(GetCurrentBitcoinPriceRequestInput input)
        {
            if (Enum.TryParse<BitcoinPriceSourceEnum>(input.Source, true, out var sourceEnum))
            {

            }
            var provider = _bitcoinPriceFactory.GetProvider(sourceEnum);
            var result = await provider.GetCurrentBitcoinPrice(input);
            return result;
        }
    }
}
