using DesignPatterns.Behavioral.CommandPattern.Models;
using DesignPatterns.Behavioral.CommandPattern.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.CommandPattern.Commands
{
    public class ChangeQuantityCommand : ICommand
    {
        private readonly Operation _operation;
        private readonly IShoppingCartRepository _shoppingCartRepo;
        private readonly IProductRepository _productRepo;
        private readonly Product _product;

        public enum Operation { Increase, Decrease }

        public ChangeQuantityCommand(Operation operation, IShoppingCartRepository shoppingCartRepo,
            IProductRepository productRepo, Product product)
        {
            _operation = operation;
            _shoppingCartRepo = shoppingCartRepo;
            _productRepo = productRepo;
            _product = product;
        }

        public void Execute()
        {
            switch (_operation)
            {
                case Operation.Decrease:
                    _productRepo.IncreaseStockBy(_product.ArticleId, 1);
                    _shoppingCartRepo.DecreaseQuantity(_product.ArticleId);
                    break;
                case Operation.Increase:
                    _productRepo.DecreaseStockBy(_product.ArticleId, 1);
                    _shoppingCartRepo.IncreaseQuantity(_product.ArticleId);
                    break;
            }
        }

        public bool CanExecute()
        {
            switch (_operation)
            {
                case Operation.Decrease:
                    return _shoppingCartRepo.Get(_product.ArticleId).Quantity != 0;
                case Operation.Increase:
                    return (_productRepo.GetStockFor(_product.ArticleId) - 1) >= 0;
            }

            return false;
        }

        public void Undo()
        {
            switch (_operation)
            {
                case Operation.Decrease:
                    _productRepo.DecreaseStockBy(_product.ArticleId, 1);
                    _shoppingCartRepo.IncreaseQuantity(_product.ArticleId);
                    break;
                case Operation.Increase:
                    _productRepo.IncreaseStockBy(_product.ArticleId, 1);
                    _shoppingCartRepo.DecreaseQuantity(_product.ArticleId);
                    break;
            }
        }
    }
}
