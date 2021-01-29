using DesignPatterns.Behavioral.CommandPattern.Models;
using DesignPatterns.Behavioral.CommandPattern.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Commands
{
    public class AddToCartCommand : ICommand
    {
        private readonly IShoppingCartRepository _shoppingCartRepo;
        private readonly IProductRepository _productRepo;
        private readonly Product _product;

        public AddToCartCommand(IShoppingCartRepository shoppingCartRepo, IProductRepository productRepo, Product product)
        {
            _shoppingCartRepo = shoppingCartRepo;
            _productRepo = productRepo;
            _product = product;
        }


        public void Execute()
        {
            if (_product == null)
                return;

            _productRepo.DecreaseStockBy(_product.ArticleId, 1);
            _shoppingCartRepo.Add(_product);
        }

        public bool CanExecute()
        {
            if (_product == null)
                return false;

            return _productRepo.GetStockFor(_product.ArticleId) > 0;
        }

        public void Undo()
        {
            if (_product == null)
                return;

            var lineItem = _shoppingCartRepo.Get(_product.ArticleId);
            _productRepo.IncreaseStockBy(_product.ArticleId, lineItem.Quantity);

            _shoppingCartRepo.RemoveAll(_product.ArticleId);
        }
    }
}
