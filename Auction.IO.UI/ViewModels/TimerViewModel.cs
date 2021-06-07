using Auction.IO.UI.States.Timers;
using System.Windows.Input;

namespace Auction.IO.UI.ViewModels
{
    public class TimerViewModel : ViewModelBase
    {
        private readonly TimerStore _timerService;
        private int _duration;

        public TimerViewModel(TimerStore timerService)
        {
            _timerService = timerService;
            _timerService.RemainingSecondsChanged += _timerStore_RemainingSecondsChanged;
        }

        public int Duration
        {
            get => _duration;
            set 
            { 
                _duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        public ICommand TimerCommand { get; set; }

        public double RemainingSeconds => _timerService.RemainingSeconds;

        private void _timerStore_RemainingSecondsChanged()
        {
            OnPropertyChanged(nameof(RemainingSeconds));
        }
    }
}
