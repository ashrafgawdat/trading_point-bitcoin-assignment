using BitcoinTicker.Shared.CustomConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitcoinTicker.Application.Shared.BitcoinTicks.Dto
{
    public class BitfinexApiPriceProviderOutput : BitcoinPriceProviderOutput
    {
        [JsonPropertyName("last_price")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public override decimal Price { get; set; }
    }
}
