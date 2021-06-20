using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.Commands;
using Auction.IO.UI.States;
using Auction.IO.UI.States.Authenticators;
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
        private readonly IRenavigator _quitRenavigator;
        private readonly IAuthenticator _authenticator;
        private readonly IDataService<Item> _itemDataService;
        private Item _item;

        public BidViewModel(IBidItemService bidItemService,
                            ItemStore itemStore,
                            TimerStore timerStore,
                            IRenavigator quitRenavigator,
                            Item item, IAuthenticator authenticator)
        {
            _bidItemService = bidItemService;
            _itemStore = itemStore;
            _timerStore = timerStore;
            _quitRenavigator = quitRenavigator;
            _item = item;
            _authenticator = authenticator;


            _timerStore.RemainingSecondsChanged += _timerStore_RemainingSecondsChanged;

            _itemStore.ItemSelected += _itemStore_ItemSelected;

            QuitBidCommand = new QuitBidCommand(this, _quitRenavigator);
            BidCommand = new BidCommand(_bidItemService, _quitRenavigator, this, _authenticator, _timerStore);
            _item = item;
        }

        public ICommand QuitBidCommand { get; set; }
        public ICommand BidCommand { get; set; }

        private void _timerStore_RemainingSecondsChanged()
        {
            OnPropertyChanged(nameof(RemainingSeconds));

            if (RemainingSeconds == 0)
            {
                _timerStore.Start();
            }
        }

        private void _itemStore_ItemSelected(Item obj)
        {
            Item = obj;
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

        public Item Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
         }

        private double _newBidPrice;
        public double NewBidPrice
        {
            get => _newBidPrice;
            set
            {
                _newBidPrice = value;
                OnPropertyChanged(nameof(NewBidPrice));
            }
        }

        public double RemainingSeconds => _timerStore.RemainingSeconds;
    }
}
