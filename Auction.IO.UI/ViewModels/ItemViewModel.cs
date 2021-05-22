using Auction.IO.Domain.Models;
using Auction.IO.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Auction.IO.UI.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private readonly IDataService<Item> _dataService;

        public Item Item { get; set; }

        public ItemViewModel(IDataService<Item> dataService)
        {
            _dataService = dataService;

            Items = Task.Run(async () => await _dataService.GetAll()).Result;

            foreach (var item in Items)
            {
                Name = item.Name;
                Image = item.Image;
                Price = item.Price;
                IsSold = item.IsSold;
                Image = item.Image;
            }
        }

        private IEnumerable<Item> _items;

        public IEnumerable<Item> Items
        {
            get => _items;
            set 
            { 
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
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

        private bool _isDeleted;
        public bool IsDeleted
        {
            get => _isDeleted;
            set 
            {
                _isDeleted = value;
                OnPropertyChanged(nameof(IsDeleted));
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

        private BitmapImage _itemImageBitmap;
        public BitmapImage ItemImageBitmap
        {
            get => _itemImageBitmap;
            set 
            { 
                _itemImageBitmap = value;
                OnPropertyChanged(nameof(ItemImageBitmap));
            }
        }

        private byte[] _image;
        public byte[] Image
        {
            get => _image;
            set 
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        private bool _isSold;

        public bool IsSold
        {
            get => _isSold;
            set 
            { 
                _isSold = value;
                OnPropertyChanged(nameof(IsSold));
            }
        }


        //TODO: Implement image converter
        private BitmapImage ConvertToBitmap(byte[] image)
        {
            throw new NotImplementedException();
        }
    }
}
