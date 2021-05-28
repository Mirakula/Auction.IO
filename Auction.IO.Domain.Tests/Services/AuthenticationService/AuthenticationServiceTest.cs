using NUnit.Framework;
using Auction.IO.Domain.Services.AuthenticationService;
using Moq;
using Auction.IO.Domain.Services;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Tests.Services.AuthenticationService
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        // Konvencija testiranja -> public void ImeMetode_Scenariji_Rezultat
        [Test]
        public async Task Login_CorrectPasswordForExistingUser_ReturnsAccountForCorrectUsername()
        {
            // Arrange
            string expectedUsername = "Amar";
            string password = "password";

            Mock<IUserAccountService> mockAccountService = new Mock<IUserAccountService>();
            Mock<IPasswordHasher> mockPasswordHasher = new Mock<IPasswordHasher>();
            Domain.Services.AuthenticationServices.AuthenticationService authentication = new Domain.Services.AuthenticationServices.AuthenticationService(mockAccountService.Object, mockPasswordHasher.Object);
            
            // Act
            var userAccount = await authentication.Login(expectedUsername, password);

            // Assert
            Assert.AreEqual(expectedUsername, userAccount.Name);
        }
    }
}
