using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Auction.IO.EntityFramework
{
    public class AuctionDbContextFactory : IDesignTimeDbContextFactory<AuctionDbContext>
    {
        public AuctionDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<AuctionDbContext>();
            options.UseSqlServer("Data Source=BETA\\SQLEXPRESS;Initial Catalog=eAukcija;User Id=sa;Password=amar2000");

            return new AuctionDbContext(options.Options);
        }
    }
}
