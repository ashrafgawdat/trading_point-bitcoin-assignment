using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;

namespace BitcoinTicker.Application.Shared.BitcoinTicks
{
    public interface IBitcoinPriceService
    {
        Task<BitcoinPriceSourcesOutput> GetBitcoinPriceSources();
        Task<BitcoinPriceOutput> GetCurrentBitcoinPrice(GetCurrentBitcoinPriceRequestInput input);
    }
}