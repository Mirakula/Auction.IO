using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.UI.ViewModels
{
    public class BidViewModel : ViewModelBase
    {
        private readonly IBidItemService _bidItemService;

        public BidViewModel(IBidItemService bidItemService)
        {
            _bidItemService = bidItemService;
        }
    }
}
