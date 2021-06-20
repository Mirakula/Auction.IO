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

    public class ItemBidCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IBidItemService _bidItemService;
        private readonly IRenavigator _loginRenavigator;
        private readonly IRenavigator _quitRenavigator;
        private readonly ItemStore _itemStore;
        private readonly TimerStore _timerStore;
        private readonly ItemViewModel _itemViewModel;


        public ItemBidCommand(IAuthenticator authenticator,
                              INavigator navigator,
                              IBidItemService bidItemService,
                              IRenavigator loginRenavigator,
                              ItemViewModel itemViewModel,
                              ItemStore itemStore,
                              TimerStore timerStore,
                              IRenavigator quitRenavigator)
        {
            _authenticator = authenticator;
            _navigator = navigator;
            _bidItemService = bidItemService;
            _loginRenavigator = loginRenavigator;
            _itemStore = itemStore;
            _itemViewModel = itemViewModel;
            _timerStore = timerStore;
            _quitRenavigator = quitRenavigator;
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
                    Name = _itemViewModel.SelectedItem.Name,
                    Price = _itemViewModel.SelectedItem.Price,
                    LastBidder = _itemViewModel.SelectedItem.LastBidder,
                    LastBidPrice = _itemViewModel.SelectedItem.LastBidPrice,
                    Location = _itemViewModel.SelectedItem.Location,
                    IsDeleted = _itemViewModel.SelectedItem.IsDeleted,
                    IsSold = _itemViewModel.SelectedItem.IsSold
                };


                _itemStore.SelectedItem(item);
                _navigator.CurrentViewModel = new BidViewModel(_bidItemService, _itemStore, _timerStore, _quitRenavigator, item, _authenticator);
            }
            else
                _navigator.CurrentViewModel = new LoginViewModel(_authenticator, _loginRenavigator);
        }
    }
}
