using Auction.IO.Domain.Exceptions;
using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services.AuthenticationService;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IUserAccountService userAccountService, IPasswordHasher passwordHasher)
        {
            _userAccountService = userAccountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserAccount> Login(string username, string password)
        {
            UserAccount storedAccount = await _userAccountService.GetByUserName(username);

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.PasswordHash, password);
            
            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }

        public async Task<RegistrationResult> Register(string name, string surname, string email, string password, string confirmPassword, string street, string city, string country, DateTime dateJoined, int RoleId)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
                result = RegistrationResult.PasswordsDoNotMatch;

            UserAccount emailUser = await _userAccountService.GetByEmail(email);
            if (emailUser != null)
                result = RegistrationResult.EmailAlreadyExists;

            UserAccount userNameUser = await _userAccountService.GetByUserName(name);
            if (userNameUser != null)
                result = RegistrationResult.UserNameAlreadyExists;

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);

                UserAccount userAccount = new UserAccount()
                {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    PasswordHash = hashedPassword,
                    Street = street,
                    City = city,
                    Country = country,
                    DateJoined = dateJoined,
                    RoleId = RoleId
                };

                await _userAccountService.Create(userAccount);
            }

            return result;
        }
    }
}
