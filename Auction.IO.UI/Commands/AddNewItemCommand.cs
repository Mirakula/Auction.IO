using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.States.Navigators;
using Auction.IO.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Auction.IO.UI.Commands
{
    public class AddNewItemCommand : ICommand
    {
        private readonly IDataService<Item> _itemDataService;
        private readonly AddItemViewModel _addItemViewModel;
        private readonly IRenavigator _renavigator;

        public AddNewItemCommand(IDataService<Item> itemDataService, IRenavigator renavigator)
        {
            _itemDataService = itemDataService;
            _renavigator = renavigator;

            _addItemViewModel = new AddItemViewModel(_itemDataService, _renavigator);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Window AddItemWindow = new AddItemWindow();
            AddItemWindow.DataContext = _addItemViewModel;
            AddItemWindow.Show();
        }
    }
}
