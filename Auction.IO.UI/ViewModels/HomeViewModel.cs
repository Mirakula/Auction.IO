using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.States.Navigators;

namespace Auction.IO.UI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public Navigator Navigator { get; set; }
        public ItemViewModel ItemViewModel { get; set; }

        public HomeViewModel(ItemViewModel itemViewModel)
        {
            ItemViewModel = itemViewModel;
        }
    }
}
