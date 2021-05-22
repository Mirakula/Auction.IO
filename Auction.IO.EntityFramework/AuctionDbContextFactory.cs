using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.EntityFramework
{
    public class AuctionDbContextFactory : IDesignTimeDbContextFactory<AuctionDbContext>
    {
        public AuctionDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<AuctionDbContext>();
            options.UseSqlServer("Data Source=AMARLEGION;Initial Catalog=eAukcija;User Id=sa;Password=sa");

            return new AuctionDbContext(options.Options);
        }
    }
}
