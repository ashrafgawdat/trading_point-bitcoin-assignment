using BitcoinTicker.Core;
using BitcoinTicker.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTicker.EntityFrameworkCore.Repositories
{
    public class BitcoinPriceRepositoryBase<TEntity> : BitcoinPriceRepositoryBase<TEntity, int> where TEntity : EntityBase
    {
        public BitcoinPriceRepositoryBase(BitcoinPriceDbContext dbContext) : base(dbContext)
        {
        }
    }
    public class BitcoinPriceRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<BitcoinPriceDbContext, TEntity, TPrimaryKey> where TEntity : EntityBase<TPrimaryKey>
    {
        public BitcoinPriceRepositoryBase(BitcoinPriceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
