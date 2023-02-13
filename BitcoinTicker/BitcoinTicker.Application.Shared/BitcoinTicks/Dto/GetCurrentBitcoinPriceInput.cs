using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTicker.Application.Shared.BitcoinTicks.Dto
{
    public class GetCurrentBitcoinPriceInput
    {
        public string? CurrencyPair { get; set; }
    }
}
