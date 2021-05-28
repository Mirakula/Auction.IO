using Auction.IO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Services
{
    public class BidItemService : IBidItemService
    {
        private readonly IDataService<Item> _itemDataService;
        private readonly IDataService<UserAccount> _userAccountDataService;


        public BidItemService(IDataService<UserAccount> userAccountDataService, IDataService<Item> itemDataService)
        {
            _userAccountDataService = userAccountDataService;
            _itemDataService = itemDataService;
        }

        //TODO: Implement bidding
        public Task<UserAccount> Bid(UserAccount buyer, Item item)
        {
            throw new NotImplementedException();
        }
    }
}
