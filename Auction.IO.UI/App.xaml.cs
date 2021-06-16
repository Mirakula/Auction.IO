using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.Domain.Services.AuthenticationService;
using Auction.IO.Domain.Services.AuthenticationServices;
using Auction.IO.EntityFramework;
using Auction.IO.EntityFramework.Services;
using Auction.IO.UI.States.Authenticators;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.States.Timers;
using Auction.IO.UI.ViewModels;
using Auction.IO.UI.ViewModels.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Auction.IO.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Koristim IServiceProvider za generisanje i registraciju svih
            // potrebnih servisa za DP (depenedency injection)
            IServiceProvider serviceProvider = CreateServiceProvider();

            //IPasswordHasher _passwordHasher = serviceProvider.GetRequiredService<IPasswordHasher>();
            //IDataService<UserAccount> _userDataService = serviceProvider.GetRequiredService<IDataService<UserAccount>>();

            //var newUser = new UserAccount()
            //{
            //    Name = "AAmar",
            //    Surname = "Dzanan",
            //    Email = "amar.dzanan@edu.fit.ba",
            //    PasswordHash = _passwordHasher.HashPassword("password"),
            //    Street = "Radnicka 64",
            //    Country = "BiH",
            //    DateJoined = DateTime.Now,
            //    RoleId = 1
            //};

            //var result = Task.Run(async () => await _userDataService.Create(newUser)).Result;

            // Pokrecem glavni prozor.
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        /// <summary>
        /// Metoda koja registruje i instancira sve servise aplikacije. Ovo je dependency injection container.
        /// </summary>
        /// <returns></returns>
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            // Registrujem sve potrebne servise koji ce se koristit kroz aplikaciju
            services.AddSingleton<AuctionDbContextFactory>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IUserAccountService, UserAccountDataService>();
            services.AddSingleton<IDataService<Item>, GenericDataService<Item>>();
            services.AddSingleton<IDataService<UserAccount>, GenericDataService<UserAccount>>();
            services.AddSingleton<IBidItemService, BidItemService>();

            // Servis hasiranja pasvorda koji dolazi
            // iz using Microsoft.AspNet.Identity
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            // Timer servis
            services.AddSingleton<ITimerService, TimerStore>();
            // Registrujem 'tvornicu' koja generise sve view modele.
            services.AddSingleton<IAuctionViewModelFactory, AuctionViewModelFactory>();
            // Registrujem samo jedan BidViewModel jer zelim samo da 
            // uvijek imam samo jednu instacnu ovog view modela.
            services.AddSingleton<BidViewModel>();
            services.AddSingleton<TimerStore>();

            //Registrujem sve potrebne view modele
            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();

            services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
            {
                return () => new HomeViewModel(
                    new ItemViewModel(
                        services.GetRequiredService<IDataService<Item>>(),
                        services.GetRequiredService<TimerStore>()),
                    services.GetRequiredService<INavigator>(),
                    services.GetRequiredService<IBidItemService>(),
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
            });

            services.AddSingleton<CreateViewModel<BidViewModel>>(services => {
                return () => services.GetRequiredService<BidViewModel>();
            });

            services.AddSingleton<CreateViewModel<PortfolioViewModel>>(services =>
            {
                return () => new PortfolioViewModel();
            });


            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>()); 
            });

            // Registrujem service navigacije i startup MainViewModel
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            // Registrujem servis za podizanje glavnog prozora.
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
