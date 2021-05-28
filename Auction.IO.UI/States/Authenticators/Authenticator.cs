using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services.AuthenticationService;
using Auction.IO.UI.Models;
using System;
using System.Threading.Tasks;

namespace Auction.IO.UI.States.Authenticators
{
    public class Authenticator : ObservableObject, IDisposable, IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private UserAccount _userAccount;
        public UserAccount CurrentUserAccount 
        {
            get => _userAccount;
            private set
            {
                _userAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        // Ako je trenutni korisnik null nije logovan
        // ako nije null onda je logovan
        public bool IsLoggedIn => CurrentUserAccount != null;

        public async Task<bool> Login(string name, string password)
        {
            bool success = true;
            try
            {
                CurrentUserAccount = await _authenticationService.Login(name, password);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public void Logout()
        {
            CurrentUserAccount = null;
        }

        public async Task<RegistrationResult> Register(string name, string surname, string email, string password, string confirmPassword, string street, string city, string country, DateTime DateJoined, int RoleId)
        {
            return await _authenticationService.Register(name, surname, email, password, confirmPassword, street, city, country, DateJoined, RoleId);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
