using BitcoinTicker.Application.Shared.BitcoinTicks;
using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTicker.Application.BitcoinTicks
{
    public abstract class BitcoinPriceBaseProvider : IBitcoinPriceProvider
    {
        public abstract Task<BitcoinPriceOutput> GetCurrentBitcoinPrice(GetCurrentBitcoinPriceInput input);
    }
}
