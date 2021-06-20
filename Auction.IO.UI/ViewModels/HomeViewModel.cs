using Auction.IO.Domain.Services;
using Auction.IO.UI.Commands;
using Auction.IO.UI.States;
using Auction.IO.UI.States.Authenticators;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.States.Timers;
using System.Windows.Input;

namespace Auction.IO.UI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IBidItemService _bidItemService;
        private readonly IRenavigator _renavigator;
        private readonly ItemStore _itemStore;
        private readonly TimerStore _timerStore;

        public ItemViewModel ItemViewModel { get; set; }

        public HomeViewModel(ItemViewModel itemViewModel, 
                             IBidItemService bidItemService, 
                             IAuthenticator authenticator, 
                             IRenavigator renavigator, 
                             ItemStore itemStore, 
                             TimerStore timerStore, 
                             INavigator navigator)
        {
            ItemViewModel = itemViewModel;
            _navigator = navigator;
            _bidItemService = bidItemService;
            _authenticator = authenticator;
            _renavigator = renavigator;
            _itemStore = itemStore;
            _timerStore = timerStore;

            ItemBidCommand = new ItemBidCommand(_authenticator, _navigator, _bidItemService, _renavigator, ItemViewModel, _itemStore, _timerStore);
        }

        public ICommand ItemBidCommand { get; set; }
    }
}
