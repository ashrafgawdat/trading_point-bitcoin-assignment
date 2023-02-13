using AutoMapper;
using BitcoinTicker.Application.Shared.BitcoinTicks;
using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BitcoinTicker.Application.BitcoinTicks
{
    public class BitstampBitcoinPriceProvider : BitcoinPriceBaseProvider, IBitcoinPriceBitstampProvider
    {
        private readonly IMapper _mapper;

        public BitstampBitcoinPriceProvider(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override async Task<BitcoinPriceOutput> GetCurrentBitcoinPrice(GetCurrentBitcoinPriceInput input)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.bitstamp.net/api/v2/ticker/{input.CurrencyPair}"),
                Headers =
                {
                    { "accept", "application/json" },
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var provOutput = JsonSerializer.Deserialize<BitstampApiPriceProviderOutput>(body);
            var output = _mapper.Map<BitcoinPriceOutput>(provOutput);
            output.Source = BitcoinPriceSourceEnum.Bitstamp.ToString();
            output.CurrencyPair = input.CurrencyPair;

            return output;
        }
    }
}
