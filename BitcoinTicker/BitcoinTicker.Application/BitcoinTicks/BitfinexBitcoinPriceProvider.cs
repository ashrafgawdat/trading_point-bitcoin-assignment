using BitcoinTicker.Application.Shared.BitcoinTicks;
using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using AutoMapper;

namespace BitcoinTicker.Application.BitcoinTicks
{
    public class BitfinexBitcoinPriceProvider : BitcoinPriceBaseProvider, IBitcoinPriceBitfinexProvider
    {
        private readonly IMapper _mapper;

        public BitfinexBitcoinPriceProvider(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override async Task<BitcoinPriceOutput> GetCurrentBitcoinPrice(GetCurrentBitcoinPriceInput input)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.bitfinex.com/v1/pubticker/{input.CurrencyPair}"),
                Headers =
                {
                    { "accept", "application/json" },
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var provOutput = JsonSerializer.Deserialize<BitfinexApiPriceProviderOutput>(body);
            var output = _mapper.Map<BitcoinPriceOutput>(provOutput);
            output.Source = BitcoinPriceSourceEnum.Bitfinex.ToString();
            output.CurrencyPair = input.CurrencyPair;

            return output;
        }
    }
}
