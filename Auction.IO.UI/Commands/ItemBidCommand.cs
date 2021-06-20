using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.States;
using Auction.IO.UI.States.Authenticators;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.States.Timers;
using Auction.IO.UI.ViewModels;
using System;
using System.Windows.Input;

namespace Auction.IO.UI.Commands
{
    public delegate void NotifyItemSelected();

    public class ItemBidCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IBidItemService _bidItemService;
        private readonly IRenavigator _renavigator;
        private readonly ItemStore _itemStore;
        private readonly TimerStore _timerStore;
        private readonly ItemViewModel _itemViewModel;

        public Item SelectedItem { get; set; }

        public ItemBidCommand(IAuthenticator authenticator, 
                              INavigator navigator, 
                              IBidItemService bidItemService, 
                              IRenavigator renavigator, 
                              ItemViewModel itemViewModel ,
                              ItemStore itemStore,
                              TimerStore timerStore)
        {
            _authenticator = authenticator;
            _navigator = navigator;
            _bidItemService = bidItemService;
            _renavigator = renavigator;
            _itemStore = itemStore;
            _itemViewModel = itemViewModel;
            _timerStore = timerStore;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_authenticator.IsLoggedIn)
            {
                Item item = new Item
                {
                    Name = _itemViewModel.Name,
                    Price = _itemViewModel.Price,
                    LastBidder = _itemViewModel.LastBidder,
                    LastBidPrice = _itemViewModel.LastBidderPrice,
                    Location = _itemViewModel.Location,
                    IsDeleted = _itemViewModel.IsDeleted,
                    IsSold = _itemViewModel.IsSold
                };

                _itemStore.SelectedItem(item);
                _navigator.CurrentViewModel = new BidViewModel(_bidItemService, _itemStore, _timerStore, _navigator);
            }
            else
                _navigator.CurrentViewModel = new LoginViewModel(_authenticator, _renavigator);
        }
    }
}
