﻿using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.Commands;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.States.Timers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Auction.IO.UI.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private readonly IDataService<Item> _dataService;
        private readonly TimerStore _timerStore;
        private readonly INavigator _navigator;

        public ItemViewModel(IDataService<Item> dataService, TimerStore timerStore, INavigator navigator)
        {
            _dataService = dataService;
            _timerStore = timerStore;
            _navigator = navigator;

            _timerStore.RemainingSecondsChanged += _timerStore_RemainingSecondsChanged;
            _timerStore.Start();

            Items = Task.Run(async () => await _dataService.GetAll()).Result;
            ObservableItems = new ObservableCollection<Item>(Items);
            Visibility = Visibility.Collapsed;
            IsPutVisible = Visibility.Collapsed;
            IsCallVisible = Visibility.Collapsed;
            TimeLeftItems = Visibility.Collapsed;
            IsAuction = true;
            IsLoggedIn = Visibility.Collapsed;

            ItemBidCommand = new ItemBidCommand(this, _timerStore, navigator);
            CallBidCommand = new CallBidCommand(this, _timerStore);
        }

        public ICommand ItemBidCommand { get; set; }
        public ICommand CallBidCommand { get; set; }

        private void _timerStore_RemainingSecondsChanged()
        {
            OnPropertyChanged(nameof(RemainingSeconds));
            OnPropertyChanged(nameof(RemainingSecondsBid));

            if (RemainingSeconds == 0)
                _timerStore.Start();

            if (RemainingSecondsBid == 0)
                Task.Run(async () => await _dataService.Create(SelectedItem));
        }

        private Visibility _isPutVisible;
        public Visibility IsPutVisible 
        {
            get => _isPutVisible; 
            set
            {
                _isPutVisible = value;
                OnPropertyChanged(nameof(IsPutVisible));
            }
        }

        private Visibility _isCallVisible;
        public Visibility IsCallVisible 
        {
            get => _isCallVisible; 
            set
            {
                _isCallVisible = value;
                OnPropertyChanged(nameof(IsCallVisible));
            }
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

        private Visibility _timeLeftItems;

        public Visibility TimeLeftItems
        {
            get => _timeLeftItems;
            set 
            {
                _timeLeftItems = value;
                OnPropertyChanged(nameof(TimeLeftItems));
            }
        }

        private Visibility _isLoggedIn;
        public Visibility IsLoggedIn
        {
            get => _isLoggedIn;
            set 
            {
                _isLoggedIn = value;
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        private UserAccount _userAccount;
        public UserAccount UserAccount 
        {
            get => _userAccount;
            set 
            {
                _userAccount = value;
                OnPropertyChanged(nameof(UserAccount));
            }
        }

        private bool _isAuction;
        public bool IsAuction 
        {
            get => _isAuction;
            set
            {
                _isAuction = value;
                OnPropertyChanged(nameof(IsAuction));
            }
        }

        public double RemainingSeconds => _timerStore.RemainingSeconds;
        public double RemainingSecondsBid => _timerStore.RemainingSeconds;

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


        private BitmapImage _itemImageBitmap;
        public BitmapImage ItemImageBitmap
        {
            get => _itemImageBitmap;
            set 
            { 
                _itemImageBitmap = value;
                OnPropertyChanged(nameof(ItemImageBitmap));
            }
        }

        private byte[] _image;
        public byte[] Image
        {
            get => _image;
            set 
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
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



        //TODO: Implement image converter
        private BitmapImage ConvertToBitmap(byte[] image)
        {
            throw new NotImplementedException();
        }
    }
}
