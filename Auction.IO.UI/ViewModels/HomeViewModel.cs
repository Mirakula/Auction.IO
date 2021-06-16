using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.Commands;
using Auction.IO.UI.States.Authenticators;
using Auction.IO.UI.States.Navigators;
using System;
using System.Windows.Input;

namespace Auction.IO.UI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IBidItemService _bidItemService;
        private readonly IRenavigator _renavigator;

        public ItemViewModel ItemViewModel { get; set; }

        public HomeViewModel(ItemViewModel itemViewModel, INavigator navigator, IBidItemService bidItemService, IAuthenticator authenticator, IRenavigator renavigator)
        {
            ItemViewModel = itemViewModel;
            _navigator = navigator;
            _bidItemService = bidItemService;
            _authenticator = authenticator;
            _renavigator = renavigator;


            ItemBidCommand = new ItemBidCommand(_authenticator, _navigator, _bidItemService, _renavigator);
        }

        public ICommand ItemBidCommand { get; set; }
    }
}
