using Auction.IO.Domain.Services;


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
