using Auction.IO.UI.ViewModels;

namespace Auction.IO.UI.States.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio,
        Bid,
        Login
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
