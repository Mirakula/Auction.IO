using Auction.IO.Domain.Models;
using System;

namespace Auction.IO.UI.States
{
    public class ItemStore
    {
        public event Action<Item> ItemSelected;

        public void SelectedItem(Item item)
        {
            ItemSelected?.Invoke(item);
        }

    }
}
