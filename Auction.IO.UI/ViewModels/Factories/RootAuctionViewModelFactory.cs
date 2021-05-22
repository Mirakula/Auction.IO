using Auction.IO.UI.States.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.UI.ViewModels.Factories
{
    public class RootAuctionViewModelFactory : IRootAuctionViewModelFactory
    {
        private readonly IAuctionViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IAuctionViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;
        private readonly BidViewModel _bidViewModel;

        public RootAuctionViewModelFactory(IAuctionViewModelFactory<HomeViewModel> homeViewModelFactory, IAuctionViewModelFactory<PortfolioViewModel> portfolioViewModelFactory, BidViewModel bidViewModel)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
            this._bidViewModel = bidViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                case ViewType.Bid:
                    return _bidViewModel;
                default:
                    throw new ArgumentException("The view type does not have a ViewModel", "viewType");
            }
        }
    }
}
