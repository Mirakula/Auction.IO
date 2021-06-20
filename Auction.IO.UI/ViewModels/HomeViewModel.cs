using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.Commands;
using Auction.IO.UI.States;
using Auction.IO.UI.States.Authenticators;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.States.Timers;
using System.Windows;
using System.Windows.Input;

namespace Auction.IO.UI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IBidItemService _bidItemService;
        private readonly IRenavigator _loginRenavigator;
        private readonly IRenavigator _quitRenavigator;
        private readonly ItemStore _itemStore;
        private readonly TimerStore _timerStore;
        private readonly IDataService<Item> _itemDataService;

        public ItemViewModel ItemViewModel { get; set; }

        public HomeViewModel(ItemViewModel itemViewModel,
                             IBidItemService bidItemService,
                             IAuthenticator authenticator,
                             IRenavigator loginRenavigator,
                             IRenavigator quitRenavigator,
                             ItemStore itemStore,
                             TimerStore timerStore, 
                             INavigator navigator,
                             IDataService<Item> itemDataService)
        {

            ItemViewModel = itemViewModel;
            _navigator = navigator;
            _bidItemService = bidItemService;
            _authenticator = authenticator;
            _loginRenavigator = loginRenavigator;
            _itemStore = itemStore;
            _timerStore = timerStore;
            _quitRenavigator = quitRenavigator;
            _itemDataService = itemDataService;


            ItemBidCommand = new ItemBidCommand(_authenticator,
                                                _navigator,
                                                _bidItemService,
                                                _loginRenavigator,
                                                ItemViewModel,
                                                _itemStore,
                                                _timerStore,
                                                _quitRenavigator);

            AddNewItemCommand = new AddNewItemCommand(_itemDataService, _quitRenavigator);
            _navigator = navigator;

            CheckUserStatus(_authenticator);
        }

        public void CheckUserStatus(IAuthenticator _authenticator)
        {
            if (_authenticator.CurrentUserAccount == null)
                Visibility = Visibility.Collapsed;
            else if (_authenticator.CurrentUserAccount.RoleId == 2)
                Visibility = Visibility.Visible;
            else
                Visibility = Visibility.Collapsed;

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

        public bool IsAdmin { get; set; }

        public ICommand ItemBidCommand { get; set; }
        public ICommand AddNewItemCommand { get; set; }
    }
}
