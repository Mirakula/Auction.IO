using Auction.IO.Domain.Models;
using Auction.IO.UI.States.Timers;
using Auction.IO.UI.ViewModels;
using System;
using System.Windows.Input;

namespace Auction.IO.UI.Commands
{
    public class ItemBidCommand : ICommand
    {
        private readonly TimerStore _timerStore;
        private readonly ItemViewModel _itemViewModel;

        public ItemBidCommand(ItemViewModel itemViewModel, TimerStore timerStore)
        {
            _timerStore = timerStore;
            _itemViewModel = itemViewModel;
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
            _itemViewModel.IsAuction = false;

            _itemViewModel.LastBidder = _itemViewModel.SelectedItem.LastBidder;
            _itemViewModel.LastBidderPrice = _itemViewModel.SelectedItem.LastBidPrice;
        }
    }
}
