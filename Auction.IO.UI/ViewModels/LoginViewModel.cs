using Auction.IO.UI.Commands;
using Auction.IO.UI.States.Authenticators;
using Auction.IO.UI.States.Navigators;
using System.Windows.Input;

namespace Auction.IO.UI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _loginRenavigator;

        public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator)
        {
            _authenticator = authenticator;
            _loginRenavigator = loginRenavigator;

            LoginCommand = new LoginCommand(this, _authenticator, _loginRenavigator);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand LoginCommand { get; set; }
    }
}
