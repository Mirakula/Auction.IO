using Auction.IO.UI.States.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.UI.ViewModels.Factories
{
    public interface IAuctionViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
