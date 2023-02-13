using BitcoinTicker.Shared.CustomConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitcoinTicker.Application.Shared.BitcoinTicks.Dto
{
    public class BitcoinPriceProviderOutput
    {
        public string? CurrencyPair { get; set; }
        public virtual decimal Price { get; set; }


        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(UnixTimeStampJsonConverter))]
        public virtual DateTime Timestamp { get; set; }
        public string? Source { get; set; }
    }
}
