﻿using Auction.IO.UI.Commands;
using Auction.IO.UI.Models;
using Auction.IO.UI.ViewModels;
using Auction.IO.UI.ViewModels.Factories;
using System.Windows.Input;

namespace Auction.IO.UI.States.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public Navigator(IRootAuctionViewModelFactory viewModelFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelFactory);
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }
    }
}
