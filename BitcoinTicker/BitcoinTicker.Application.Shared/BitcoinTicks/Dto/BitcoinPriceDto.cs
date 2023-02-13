using BitcoinTicker.Shared.CustomConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitcoinTicker.Application.Shared.BitcoinTicks.Dto
{
    public class BitcoinPriceDto
    {
        public string? CurrencyPair { get; set; }
        public string? Price { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public string? Source { get; set; }
    }
}
