using DesignPatterns.Behavioral.CommandPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Repository
{
    public interface IProductRepository
    {
        void DecreaseStockBy(string id, int amount);
        void IncreaseStockBy(string id, int amount);
        int GetStockFor(string id);
        Product FindBy(string id);
    }
}
