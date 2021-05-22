using Auction.IO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.EntityFramework
{
    public class AuctionDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                UserRole = 1,
                SystemRole = "Adminstrator"
            },
            new Role 
            {
                Id = 2,
                UserRole = 2,
                SystemRole = "User"
            });

            modelBuilder.Entity<Account>()
                .HasOne(x => x.User)
                .WithOne(a => a.Account)
                .HasForeignKey((Account FK) => FK.UserId);

            modelBuilder.Entity<Item>()
                .HasOne(x => x.User)
                .WithMany(a => a.Items)
                .HasForeignKey((Item FK) => FK.UserId);

            base.OnModelCreating(modelBuilder);
        }

        public AuctionDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
