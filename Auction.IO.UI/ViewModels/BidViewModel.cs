using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.Commands;
using Auction.IO.UI.States;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.States.Timers;
using System.Windows.Input;

namespace Auction.IO.UI.ViewModels
{
    public class BidViewModel : ViewModelBase
    {
        private readonly IBidItemService _bidItemService;
        private readonly ItemStore _itemStore;
        private readonly TimerStore _timerStore;
        private readonly INavigator _navigator;

        public BidViewModel(IBidItemService bidItemService, ItemStore itemStore, TimerStore timerStore, INavigator navigator)
        {
            _bidItemService = bidItemService;
            _itemStore = itemStore;
            _navigator = navigator;
            _timerStore = timerStore;


            _timerStore.RemainingSecondsChanged += _timerStore_RemainingSecondsChanged;

            _itemStore.ItemSelected += _itemStore_ItemSelected;

            QuitBidCommand = new QuitBidCommand(this, _navigator);
        }

        public ICommand QuitBidCommand { get; set; }

        private void _timerStore_RemainingSecondsChanged()
        {
            OnPropertyChanged(nameof(RemainingSeconds));

            if (RemainingSeconds == 0)
                _timerStore.Start();
        }

        private void _itemStore_ItemSelected(Item obj)
        {
            SelectedItem = obj;
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

        public double RemainingSeconds => _timerStore.RemainingSeconds;
    }
}
