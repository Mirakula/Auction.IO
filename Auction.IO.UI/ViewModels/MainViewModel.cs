using Auction.IO.UI.Commands;
using Auction.IO.UI.States.Authenticators;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.ViewModels.Factories;
using System.Windows.Input;

namespace Auction.IO.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAuctionViewModelFactory _viewModelFactory;

        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; }
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator, IAuctionViewModelFactory viewModelFactory)
        {
            Authenticator = authenticator;
            Navigator = navigator;
            _viewModelFactory = viewModelFactory;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);

            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
