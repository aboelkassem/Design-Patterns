using DesignPatterns.Behavioral.CommandPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            if (product == null)
                return;

            _products.Add(product);
        }

        public Product Get(string id)
        {
            return _products
                .Where(p => p.ArticleId == id)
                .ToList()
                .FirstOrDefault();
        }

        public void RemoveAll(string id)
        {
            _products = _products.Where(p => p.ArticleId != id).ToList();
        }

        public void DecreaseQuantity(string id)
        {
            _products.Where(p => p.ArticleId == id).ToList().ForEach(x => x.Quantity--);
        }

        public void IncreaseQuantity(string id)
        {
            _products.Where(p => p.ArticleId == id).ToList().ForEach(x => x.Quantity++);
        }
    }
}
