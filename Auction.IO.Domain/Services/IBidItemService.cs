using Auction.IO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Services
{
    public interface IBidItemService
    {
        Task<UserAccount> Bid(UserAccount buyer, Item item);
    }
}
