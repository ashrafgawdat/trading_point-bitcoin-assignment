using BitcoinTicker.Application.Shared.BitcoinTicks;
using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinTicker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BitcoinController : ControllerBase
    {
        private readonly ILogger<BitcoinController>? _logger;
        private readonly IBitcoinPriceService _bitcoinPriceService;

        public BitcoinController(ILogger<BitcoinController> logger,
                                IBitcoinPriceService bitcoinPriceService)
        {
            _logger = logger;
            _bitcoinPriceService = bitcoinPriceService;
        }

        [HttpGet]
        public async Task<BitcoinPriceSourcesOutput> Sources()
        {
            return await _bitcoinPriceService.GetBitcoinPriceSources();
        }

        [HttpGet]
        public async Task<BitcoinPriceDto> Prices3(string source, string currencyPair = "btcusd")
        {
            return await _bitcoinPriceService.GetCurrentBitcoinPrice(new GetCurrentBitcoinPriceRequestInput { Source = source, CurrencyPair = currencyPair });
        }

        [HttpGet]
        public async Task<BitcoinPriceHistoryOutput> History()
        {
            return await _bitcoinPriceService.GetBitcoinPriceHistory();
        }
    }
}