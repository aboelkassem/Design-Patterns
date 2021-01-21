using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.FacadePattern
{
    public class ShoppingBasket
    {
        private List<BasketItem> _items = new List<BasketItem>();

        public void AddItem(BasketItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(string itemId)
        {
            var item = _items.Find(s => s.ItemId == itemId);
            if (item.Quantity > 0)
                item.Quantity = item.Quantity - 1;
        }

        public List<BasketItem> GetItems()
        {
            return _items;
        }
    }
}
