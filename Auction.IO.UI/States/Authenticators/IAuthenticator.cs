using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services.AuthenticationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.UI.States.Authenticators
{
    public interface IAuthenticator
    {
        UserAccount CurrentUserAccount { get; }
        bool IsLoggedIn { get; }
        Task<RegistrationResult> Register(string name, string surname, string email, string password, string confirmPassword, string street, string city, string country, DateTime DateJoined, int RoleId);
        Task<bool> Login(string name, string password);
        void Logout();
    }
}
