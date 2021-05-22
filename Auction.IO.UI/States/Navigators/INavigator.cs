using Auction.IO.UI.Commands;
using Auction.IO.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Auction.IO.UI.States.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio,
        Bid,
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
