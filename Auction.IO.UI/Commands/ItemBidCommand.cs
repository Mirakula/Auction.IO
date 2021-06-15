using Auction.IO.Domain.Models;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.States.Timers;
using Auction.IO.UI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace Auction.IO.UI.Commands
{
    public class ItemBidCommand : ICommand
    {
        private readonly TimerStore _timerStore;
        private readonly ItemViewModel _itemViewModel;
        public readonly INavigator _navigator;

        public ItemBidCommand(ItemViewModel itemViewModel, TimerStore timerStore, INavigator navigator)
        {
            _timerStore = timerStore;
            _itemViewModel = itemViewModel;
            _navigator = navigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _itemViewModel.Visibility = System.Windows.Visibility.Visible;
            _itemViewModel.IsCallVisible = System.Windows.Visibility.Visible;
            _itemViewModel.IsPutVisible = System.Windows.Visibility.Visible;
            _itemViewModel.TimeLeftItems = System.Windows.Visibility.Collapsed;

            _itemViewModel.IsAuction = false;
            _itemViewModel.IsLoggedIn = Visibility.Visible;

            _itemViewModel.LastBidder = _itemViewModel.SelectedItem.LastBidder;

            //MessageBox.Show("Niste prijavljeni u sistem. Molimo Vas da se prijavite klikom na Log in dugme !");
        }
    }
}
