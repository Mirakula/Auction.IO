using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.ViewModels;
using System;
using System.Windows.Input;

namespace Auction.IO.UI.Commands
{
    public class QuitBidCommand : ICommand
    {
        private readonly INavigator _navigator;
        private readonly BidViewModel _bidViewModel;


        public QuitBidCommand(BidViewModel bidViewModel, INavigator navigator)
        {
            _bidViewModel = bidViewModel;
            _navigator = navigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

        }
    }
}
