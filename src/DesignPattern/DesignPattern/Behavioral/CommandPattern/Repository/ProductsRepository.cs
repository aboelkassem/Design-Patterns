using DesignPatterns.Behavioral.CommandPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Repository
{
    public class ProductsRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Name = "TLOU", ArticleId = "1", AmountInStock = 10, Quantity = 0 },
            new Product { Name = "AC", ArticleId = "2", AmountInStock = 100, Quantity = 0 },
            new Product { Name = "HZD", ArticleId = "3", AmountInStock = 1000, Quantity = 0 }
        };

        public void DecreaseStockBy(string id, int amount)
        {
            _products.Where(p => p.ArticleId == id).ToList().ForEach(x => x.AmountInStock -= amount);
        }

        public void IncreaseStockBy(string id, int amount)
        {
            _products.Where(p => p.ArticleId == id).ToList().ForEach(x => x.AmountInStock += amount);
        }

        public int GetStockFor(string id)
        {
            return _products.Where(p => p.ArticleId == id).Select(x => x.AmountInStock).FirstOrDefault();
        }

        public Product FindBy(string id)
        {
            return _products.FirstOrDefault(p => p.ArticleId == id);
        }
    }
}
