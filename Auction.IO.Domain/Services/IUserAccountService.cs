using Auction.IO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Services
{
    public interface IUserAccountService : IDataService<UserAccount>
    {
        Task<UserAccount> GetByUserName(string username);
        Task<UserAccount> GetByEmail(string email);
    }
}
