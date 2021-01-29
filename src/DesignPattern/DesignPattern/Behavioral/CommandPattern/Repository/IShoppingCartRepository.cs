using DesignPatterns.Behavioral.CommandPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Repository
{
    public interface IShoppingCartRepository
    {
        void Add(Product product);
        Product Get(string id);
        void RemoveAll(string id);
        void DecreaseQuantity(string id);
        void IncreaseQuantity(string id);
    }
}
