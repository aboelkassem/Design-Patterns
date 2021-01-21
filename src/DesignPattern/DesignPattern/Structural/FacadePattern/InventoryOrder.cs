using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.FacadePattern
{
    public class InventoryOrder
    {
        public string CreateOrder(ShoppingBasket basket, string storeId)
        {
            basket.GetItems();
            return $"Order Number is {System.Guid.NewGuid().ToString()}";
        }
    }
}
