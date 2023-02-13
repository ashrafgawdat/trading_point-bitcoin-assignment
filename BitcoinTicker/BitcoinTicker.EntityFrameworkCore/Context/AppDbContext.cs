using Microsoft.EntityFrameworkCore;

namespace BitcoinTicker.EntityFrameworkCore.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
