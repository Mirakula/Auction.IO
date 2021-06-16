using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.States.Authenticators;
using Auction.IO.UI.States.Navigators;
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

        public Item SelectedItem { get; set; }

        public ItemBidCommand(IAuthenticator authenticator, INavigator navigator, IBidItemService bidItemService, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _navigator = navigator;
            _bidItemService = bidItemService;
            _renavigator = renavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_authenticator.IsLoggedIn)
                _navigator.CurrentViewModel = new BidViewModel(_bidItemService);
            else
                _navigator.CurrentViewModel = new LoginViewModel(_authenticator, _renavigator);
        }
    }
}
