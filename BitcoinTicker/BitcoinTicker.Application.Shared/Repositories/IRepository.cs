using BitcoinTicker.Core;
using System.Linq.Expressions;

namespace BitcoinTicker.Application.Shared
{
    public interface IBitcoinPriceRepository : IRepository<BitcoinPrice>
    {
    }
}
