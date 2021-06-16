using Auction.IO.UI.States.Timers;
using Auction.IO.UI.ViewModels;
using System;
using System.Windows.Input;

namespace Auction.IO.UI.Commands
{
    public class CallBidCommand : ICommand
    {

        private readonly ItemViewModel _itemViewModel;
        private TimerStore _timerStore;

        public CallBidCommand(ItemViewModel itemViewModel, TimerStore timerStore)
        {
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
            _timerStore.Start();
            _itemViewModel.TimeLeftItems = System.Windows.Visibility.Collapsed;
        }
    }
}
