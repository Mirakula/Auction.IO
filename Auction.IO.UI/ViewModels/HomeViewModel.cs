using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
