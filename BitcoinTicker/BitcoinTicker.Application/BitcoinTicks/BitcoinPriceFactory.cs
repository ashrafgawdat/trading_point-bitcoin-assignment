using BitcoinTicker.Application.Shared.BitcoinTicks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTicker.Application.BitcoinTicks
{
    public class BitcoinPriceFactory : IBitcoinPriceFactory
    {
        private readonly IBitcoinPriceBitstampProvider _bitcoinPriceBitstampProvider;
        private readonly IBitcoinPriceBitfinexProvider _bitcoinPriceBitfinexProvider;

        public BitcoinPriceFactory(IBitcoinPriceBitstampProvider bitcoinPriceBitstampProvider, IBitcoinPriceBitfinexProvider bitcoinPriceBitfinexProvider)
        {
            _bitcoinPriceBitstampProvider = bitcoinPriceBitstampProvider;
            _bitcoinPriceBitfinexProvider = bitcoinPriceBitfinexProvider;
        }

        public IBitcoinPriceProvider GetProvider(BitcoinPriceSourceEnum source)
        {
            return source switch
            {
                BitcoinPriceSourceEnum.Bitstamp => _bitcoinPriceBitstampProvider,
                BitcoinPriceSourceEnum.Bitfinex => _bitcoinPriceBitfinexProvider,
                _ => throw new NotImplementedException($"Source {source} is not implemented"),
            };
        }
    }
}
