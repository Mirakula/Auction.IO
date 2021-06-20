using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.States.Authenticators;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.States.Timers;
using Auction.IO.UI.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace Auction.IO.UI.Commands
{
    public class BidCommand : ICommand
    {
        private readonly IBidItemService _bidItemService;
        private readonly IRenavigator _ItemBoughtRenavigator;
        private readonly BidViewModel _bidViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly TimerStore _timerStore;


        public BidCommand(IBidItemService bidItemService, IRenavigator itemBoughtRenavigator, BidViewModel bidViewModel, IAuthenticator authenticator, TimerStore timerStore)
        {
            _bidItemService = bidItemService;
            _ItemBoughtRenavigator = itemBoughtRenavigator;
            _bidViewModel = bidViewModel;
            _authenticator = authenticator;
            _timerStore = timerStore;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_bidViewModel.Item.LastBidPrice > _bidViewModel.NewBidPrice)
                MessageBox.Show("The new price cannot be lower than last bid price !");
            else
            {
                _bidViewModel.NewBidPrice += 1;
                Item item = new Item
                {
                    Name = _bidViewModel.Item.Name,
                    LastBidder = _authenticator.CurrentUserAccount.Name,
                    Price = _bidViewModel.Item.Price, 
                    LastBidPrice = _bidViewModel.NewBidPrice,
                    Location = _bidViewModel.Item.Location,
                    IsSold = true,
                    IsDeleted = false,
                };

                _bidViewModel.Item = item;
                _timerStore.Start();
            }
        }
    }
}
