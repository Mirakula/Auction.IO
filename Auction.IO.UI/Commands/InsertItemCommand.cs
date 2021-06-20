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
    public class InsertItemCommand : ICommand
    {
        private readonly IDataService<Item> _itemDataService;
        private readonly IRenavigator _renavigator;
        private readonly AddItemViewModel _addItemViewModel;

        public InsertItemCommand(IDataService<Item> itemDataService, IRenavigator renavigator, AddItemViewModel addItemViewModel)
        {
            _itemDataService = itemDataService;
            _renavigator = renavigator;
            _addItemViewModel = addItemViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Item item = new Item
            {
                Name = _addItemViewModel.Name,
                Price = _addItemViewModel.Price,
                Location = _addItemViewModel.Location,
                LastBidPrice = _addItemViewModel.Price
            };

             _itemDataService.Create(item);
            MessageBox.Show("Item Added !");

            _addItemViewModel.Name = "";
            _addItemViewModel.Price = 0;
            _addItemViewModel.Location = "";

            _renavigator.Renavigate();
        }
    }
}
