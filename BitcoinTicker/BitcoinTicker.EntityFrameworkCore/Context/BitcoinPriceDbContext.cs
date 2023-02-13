using BitcoinTicker.Core;
using Microsoft.EntityFrameworkCore;

namespace BitcoinTicker.EntityFrameworkCore.Context
{
    public class BitcoinPriceDbContext : DbContext
    {
        public DbSet<BitcoinPrice> BitcoinPrices { get; set; }
        public BitcoinPriceDbContext(DbContextOptions<BitcoinPriceDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BitcoinPrice>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.CurrencyPair).HasMaxLength(10);
                e.Property(p => p.Source).HasMaxLength(256);
            });
        }
    }
}
