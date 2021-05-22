using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.UI.ViewModels.Factories
{
    public class BidViewModelFactory : IAuctionViewModelFactory<BidViewModel>
    {
        private readonly IBidItemService _bidService;

        public BidViewModelFactory(IBidItemService bidItemService)
        {
            _bidService = bidItemService;
        }

        public BidViewModel CreateViewModel()
        {
            return new BidViewModel(_bidService);
        }
    }
}
