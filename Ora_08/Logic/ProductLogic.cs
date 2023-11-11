using Ora_08.Model;
using Ora_08.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_08.Logic
{
    public class ProductLogic
    {
        private readonly IRepository<Product> _repository;

        public ProductLogic(IRepository<Product> repository)
        {
            _repository = repository;
        }

        // Returns all products within a given category
        public IEnumerable<Product> GetProductsInCategory(string category)
        {
            return _repository.GetAll().Where(product => product.Category == category);
        }

        // Returns all products with a price greater than the specified value
        public IEnumerable<Product> GetProductsWithPriceGreaterThan(decimal price)
        {
            return _repository.GetAll().Where(product => product.Price > price);
        }

        // Returns all products with a price less than the specified value
        public IEnumerable<Product> GetProductsWithPriceLessThan(decimal price)
        {
            return _repository.GetAll().Where(product => product.Price < price);
        }

        // Returns all products with stock greater than or equal to the specified minimum stock level
        public IEnumerable<Product> GetProductsWithMinimumStock(int minimumStock)
        {
            return _repository.GetAll().Where(product => product.Stock >= minimumStock);
        }

        // Checks if a specific product is in stock
        public bool IsProductInStock(int productId)
        {
            var product = _repository.GetAll().FirstOrDefault(product => product.Id == productId);
            return product != null && product.Stock > 0;
        }
    }
}
