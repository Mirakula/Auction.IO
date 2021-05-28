using Auction.IO.UI.ViewModels;

namespace Auction.IO.UI.States.Navigators
{
    public class ViewModelDelegateRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        public ViewModelDelegateRenavigator(CreateViewModel<TViewModel> createViewModel, INavigator navigator)
        {
            _createViewModel = createViewModel;
            _navigator = navigator;
        }

        public void Renavigate()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
