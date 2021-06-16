using Auction.IO.Domain.Services;
using System;
using System.Timers;

namespace Auction.IO.UI.States.Timers
{
    public class TimerStore : ITimerService
    {
        private Timer _timer;
        private DateTime _endTime;

        public double EndTimeCurrentTimeSecondsDifference => TimeSpan.FromTicks(_endTime.Ticks).TotalSeconds - TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;
        public double RemainingSeconds => EndTimeCurrentTimeSecondsDifference > 0 ? EndTimeCurrentTimeSecondsDifference : 0;

        public event Action RemainingSecondsChanged;

        public TimerStore()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
        }
        
        public void Start()
        {
            _timer.Start();

            _endTime = DateTime.Now.AddSeconds(120);
            OnRemaininSecondsChanged();
        }
       
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnRemaininSecondsChanged();
        }

        private void OnRemaininSecondsChanged()
        {
            RemainingSecondsChanged?.Invoke();
        }
    }
}
