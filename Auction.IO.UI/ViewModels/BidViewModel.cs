using Auction.IO.Domain.Models;
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

        private Item _selectedItem;

        public Item SelectedItem
        {
            get => _selectedItem;
            set 
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

    }
}
