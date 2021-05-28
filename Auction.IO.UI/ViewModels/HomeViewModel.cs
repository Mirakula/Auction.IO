using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;

namespace Auction.IO.UI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        public ItemViewModel ItemViewModel { get; set; }

        public HomeViewModel(ItemViewModel itemViewModel)
        { 
            ItemViewModel = itemViewModel;
        }
    }
}
