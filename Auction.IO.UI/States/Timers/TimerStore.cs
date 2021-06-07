using Auction.IO.Domain.Services;
using System;
using System.Timers;

namespace Auction.IO.UI.States.Timers
{
    public class TimerStore : ITimerService
    {
        private readonly Timer _timer;
        private DateTime _endTime;

        public double RemainingSeconds => TimeSpan.FromTicks(_endTime.Ticks).TotalSeconds - TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;

        public event Action RemainingSecondsChanged;

        public TimerStore()
        {
            _timer = new Timer(120000);
            _timer.Elapsed += _timer_Elapsed;
        }
        
        public void Start(int durationInSeconds)
        {
            _timer.Start();

            _endTime = DateTime.Now.AddSeconds(durationInSeconds);
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
