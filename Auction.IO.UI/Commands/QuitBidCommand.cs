using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.ViewModels;
using System;
using System.Windows.Input;

namespace Auction.IO.UI.Commands
{
    public class QuitBidCommand : ICommand
    {
        private readonly IRenavigator _quitRenavigator;
        private readonly BidViewModel _bidViewModel;


        public QuitBidCommand(BidViewModel bidViewModel, IRenavigator quitRenavigator)
        {
            _bidViewModel = bidViewModel;
            _quitRenavigator = quitRenavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _quitRenavigator.Renavigate();
        }
    }
}
