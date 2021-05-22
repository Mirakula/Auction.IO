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
        private readonly IDataService<Account> _accountDataService;


        public BidItemService(IDataService<Account> accountDataService, IDataService<Item> itemDataService)
        {
            _accountDataService = accountDataService;
            _itemDataService = itemDataService;
        }

        //TODO: Implement bidding
        public Task<Account> Bid(Account buyer, Item item)
        {
            throw new NotImplementedException();
        }
    }
}
