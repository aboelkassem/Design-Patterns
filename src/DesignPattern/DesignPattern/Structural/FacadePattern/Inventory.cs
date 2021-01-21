using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.FacadePattern
{
    public class Inventory
    {
        public bool CheckItemQuantity(string itemId, double quantity)
        {
            return quantity < 100;
        }
    }
}
