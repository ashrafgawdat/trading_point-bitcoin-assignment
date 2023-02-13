using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;

namespace BitcoinTicker.Application.Shared.BitcoinTicks
{
    public interface IBitcoinPriceService
    {
        Task<BitcoinPriceSourcesOutput> GetBitcoinPriceSources();
        Task<BitcoinPriceDto> GetCurrentBitcoinPrice(GetCurrentBitcoinPriceRequestInput input);
        Task<BitcoinPriceHistoryOutput> GetBitcoinPriceHistory();
    }
}