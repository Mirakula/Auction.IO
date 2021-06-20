using Auction.IO.UI.ViewModels;

namespace Auction.IO.UI.States.Navigators
{
    public enum ViewType
    {
        Home,
        Bid,
        Login,
        AddItem
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
