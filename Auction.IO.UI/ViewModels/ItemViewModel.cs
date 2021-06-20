using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.States;
using Auction.IO.UI.States.Timers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Auction.IO.UI.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private readonly IDataService<Item> _dataService;
        private readonly TimerStore _timerStore;
        private readonly ItemStore _itemStore;

        public ItemViewModel(IDataService<Item> dataService, TimerStore timerStore, ItemStore itemStore)
        {
            _dataService = dataService;
            _timerStore = timerStore;
            _itemStore = itemStore;

            _timerStore.RemainingSecondsChanged += _timerStore_RemainingSecondsChanged;
            _timerStore.Start();

            Items = Task.Run(async () => await _dataService.GetAll()).Result;
            ObservableItems = new ObservableCollection<Item>(Items);
            Visibility = Visibility.Collapsed;
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

        private void _timerStore_RemainingSecondsChanged()
        {
            OnPropertyChanged(nameof(RemainingSeconds));

            if (RemainingSeconds == 0)
                _timerStore.Start();
        }

        private Visibility _visibility;
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged(nameof(Visibility));
            }
        }

        public double RemainingSeconds => _timerStore.RemainingSeconds;

        private IEnumerable<Item> _items;

        public IEnumerable<Item> Items
        {
            get => _items;
            set
            { 
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        private ObservableCollection<Item> _observableItems;
        public ObservableCollection<Item> ObservableItems 
        {
            get => _observableItems;
            set
            {
                _observableItems = value;
                OnPropertyChanged(nameof(ObservableItems));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private bool _isDeleted;
        public bool IsDeleted
        {
            get => _isDeleted;
            set 
            {
                _isDeleted = value;
                OnPropertyChanged(nameof(IsDeleted));
            }
        }

        private double _price;
        public double Price
        {
            get => _price;
            set 
            {  
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string _location;
        public string Location  
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        private double _lastBidderPrice;
        public double LastBidderPrice
        {
            get =>_lastBidderPrice; 
            set 
            {
                _lastBidderPrice = value;
                OnPropertyChanged(nameof(LastBidderPrice));
            }
        }
      
        private bool _isSold;

        public bool IsSold
        {
            get => _isSold;
            set 
            { 
                _isSold = value;
                OnPropertyChanged(nameof(IsSold));
            }
        }

        private string _lastBidder;

        public string LastBidder
        {
            get => _lastBidder;
            set 
            { 
                _lastBidder = value;
                OnPropertyChanged(nameof(LastBidder));
            }
        }
    }
}
