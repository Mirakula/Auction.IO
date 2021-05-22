using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.UI.ViewModels.Factories
{
    public class HomeViewModelFactory : IAuctionViewModelFactory<HomeViewModel>
    {
        private IAuctionViewModelFactory<ItemViewModel> _itemViewModel;
        public HomeViewModelFactory(IAuctionViewModelFactory<ItemViewModel> itemViewModel)
        {
            _itemViewModel = itemViewModel;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_itemViewModel.CreateViewModel());
        }
    }
}
