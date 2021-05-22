using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.EntityFramework;
using Auction.IO.EntityFramework.Services;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.ViewModels;
using Auction.IO.UI.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
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
            services.AddSingleton<IDataService<Item>, GenericDataService<Item>>();
            services.AddSingleton<IDataService<Account>, GenericDataService<Account>>();
            services.AddSingleton<IBidItemService, BidItemService>();



            // Registrujem sve potrebne factory-ije koji ce automtaski da generisu sve viewModel-e
            services.AddSingleton<IRootAuctionViewModelFactory, RootAuctionViewModelFactory>();
            services.AddSingleton<IAuctionViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IAuctionViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
            services.AddSingleton<IAuctionViewModelFactory<ItemViewModel>, ItemViewModelFactory>();

            // Registrujem service navigacije i startup MainViewModel
            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<BidViewModel>();

            // Registrujem servis za podizanje glavnog prozora.
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
