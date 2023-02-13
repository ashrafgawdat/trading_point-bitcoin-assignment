using BitcoinTicker.Shared.CustomConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitcoinTicker.Application.Shared.BitcoinTicks.Dto
{
    public class BitcoinPriceHistoryOutput
    {
        public List<BitcoinPriceOutput> Prices { get; set; } = new List<BitcoinPriceOutput>();
    }
}
