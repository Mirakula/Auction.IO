using Auction.IO.UI.States.Navigators;
using System;

namespace Auction.IO.UI.ViewModels.Factories
{
    public class AuctionViewModelFactory : IAuctionViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<BidViewModel> _createBidViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public AuctionViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
                                       CreateViewModel<BidViewModel> createBidViewModel,
                                       CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createBidViewModel = createBidViewModel;
            _createLoginViewModel = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Bid:
                    return _createBidViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                default:
                    throw new ArgumentException("The view type does not have a ViewModel", "viewType");
            }
        }
    }
}
