using System;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Services
{
    public interface ITimerService 
    {
        void Start(int seconds);
    }
}
