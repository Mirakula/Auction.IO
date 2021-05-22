using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;

namespace Auction.IO.UI.ViewModels.Factories
{
    public class ItemViewModelFactory : IAuctionViewModelFactory<ItemViewModel>
    {
        private readonly IDataService<Item> _itemDataService;

        public ItemViewModelFactory(IDataService<Item> itemDataService)
        {
            _itemDataService = itemDataService;
        }

        public ItemViewModel CreateViewModel()
        {
            return new ItemViewModel(_itemDataService);
        }
    }
}
