using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auction.IO.EntityFramework.Services
{
    public class UserAccountDataService : IUserAccountService
    {
        private readonly AuctionDbContextFactory _contextFactory;

        public UserAccountDataService(AuctionDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<UserAccount> Create(UserAccount entity)
        {
            using (AuctionDbContext context = _contextFactory.CreateDbContext())
            {
                var createdUserAccount = await context.AddAsync(entity);
                await context.SaveChangesAsync();

                return createdUserAccount.Entity;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            using (AuctionDbContext context = _contextFactory.CreateDbContext())
            {
                var queryUserAccount = await context.UserAccounts.FirstOrDefaultAsync(a => a.Id == Id);
                context.Set<UserAccount>().Remove(queryUserAccount);

                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<UserAccount> Get(int Id)
        {
            using (AuctionDbContext context = _contextFactory.CreateDbContext())
            {
                var foundUserAccount = await context.UserAccounts.FirstOrDefaultAsync(a => a.Id == Id);

                return foundUserAccount;
            }
        }

        public async Task<IEnumerable<UserAccount>> GetAll()
        {
            using (AuctionDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.UserAccounts.ToListAsync();
            }
        }

        public async Task<UserAccount> GetByEmail(string email)
        {
            using(AuctionDbContext context = _contextFactory.CreateDbContext())
            {
                var foundByEmail = await context.UserAccounts.FirstOrDefaultAsync(a => a.Email == email);

                return foundByEmail;
            }
        }

        public async Task<UserAccount> GetByUserName(string username)
        {
            using (AuctionDbContext context = _contextFactory.CreateDbContext())
            {
                var foundByUserName = await context.UserAccounts.FirstOrDefaultAsync(a => a.Name == username);

                return foundByUserName;
            }
        }

        public async Task<UserAccount> Update(int Id, UserAccount entity)
        {
            using (AuctionDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = Id;
                context.Set<UserAccount>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
