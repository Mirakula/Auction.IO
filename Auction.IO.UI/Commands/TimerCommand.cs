using Auction.IO.UI.States.Timers;
using Auction.IO.UI.ViewModels;
using System;
using System.Windows.Input;

namespace Auction.IO.UI.Commands
{
    public class TimerCommand : ICommand
    {

        private readonly TimerStore _timerStore;


        public TimerCommand(TimerStore timerStore)
        {
            _timerStore = timerStore;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            _timerStore.Start();
        }
    }
}
