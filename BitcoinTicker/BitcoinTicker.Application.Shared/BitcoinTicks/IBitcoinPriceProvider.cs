using BitcoinTicker.Application.Shared.BitcoinTicks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTicker.Application.Shared.BitcoinTicks
{
    public interface IBitcoinPriceProvider
    {
        Task<BitcoinPriceOutput> GetCurrentBitcoinPrice(GetCurrentBitcoinPriceInput input);
    }
}
