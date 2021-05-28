using Auction.IO.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Services.AuthenticationService
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UserNameAlreadyExists
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string name, string surname, string email, string password, string confirmPassword, string street, string city, string country, DateTime DateJoined, int RoleId);
        Task<UserAccount> Login(string username, string password);
    }
}
