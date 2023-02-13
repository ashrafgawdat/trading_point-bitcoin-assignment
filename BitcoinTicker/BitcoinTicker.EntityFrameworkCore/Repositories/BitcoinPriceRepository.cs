using BitcoinTicker.Application.Shared;
using BitcoinTicker.Core;
using BitcoinTicker.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTicker.EntityFrameworkCore.Repositories
{
    public class BitcoinPriceRepository : BitcoinPriceRepositoryBase<BitcoinPrice>, IBitcoinPriceRepository
    {
        public BitcoinPriceRepository(BitcoinPriceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
