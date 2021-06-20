using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using Auction.IO.UI.Commands;
using Auction.IO.UI.States.Navigators;
using System.Windows.Input;

namespace Auction.IO.UI.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        private readonly IRenavigator _renavigator;
        private readonly IDataService<Item> _itemDataService;

        public AddItemViewModel(IDataService<Item> itemDataService, IRenavigator renavigator)
        {
            _itemDataService = itemDataService;
            _renavigator = renavigator;

            InsertItemCommand = new InsertItemCommand(_itemDataService, _renavigator, this);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private double _price;
        public double Price
        {
            get => _price;
            set 
            { 
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string _location;
        public string Location
        {
            get => _location;
            set 
            { 
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public ICommand InsertItemCommand { get; set; }
    }
}