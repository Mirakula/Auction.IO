using Auction.IO.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Auction.IO.EntityFramework
{
    public class AuctionDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                        .HasKey(x => x.UserRole);

            modelBuilder.Entity<Role>()
                        .HasOne(r => r.UserAccount)
                        .WithOne(i => i.Role)
                        .HasForeignKey((UserAccount FK) => FK.RoleId)
                        .IsRequired(true);

            modelBuilder.Entity<Item>()
                .HasMany(u => u.Users)
                .WithMany(i => i.Items);

            modelBuilder.Entity<Role>().HasData(new Role
            {
                UserRole = 1,
                SystemRole = "Administrator",
            },
            new Role
            {
                UserRole = 2,
                SystemRole = "User"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                Name = "Test 1",
                Image = null,
                Price = 289.99,
                LastBidder = "Bidder 8",
                LastBidPrice = 132.99,
                IsDeleted = false,
                IsSold = false
            },
            new Item
            {
                Id = 2,
                Name = "Test 2",
                Image = null,
                Price = 129.99,
                LastBidder = "Bidder 5",
                LastBidPrice = 149.10,
                IsDeleted = false,
                IsSold = false
            },
            new Item
            {
                Id = 3,
                Name = "Test 3",
                Image = null,
                Price = 150,
                LastBidder = "Bidder 6",
                LastBidPrice = 168.50,
                IsDeleted = false,
                IsSold = false
            });

            base.OnModelCreating(modelBuilder);
        }

        public AuctionDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserAccount> UserAccounts{ get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
