using System.Collections.Generic;
using WCApp.Core.Model;
using WCApp.Core.Repository;

namespace WCApp.Core.Service
{
    public class ProductService
    {
        private static readonly ProductRepository ProductRepository = new ProductRepository();

        public List<Product> GetProductsByCategoryId(int id)
        {
            return ProductRepository.GetProductsByCategoryId(id);
        }

        public List<Product> GetOfferProducts()
        {
            return ProductRepository.GetOfferProducts();
        }

        public Product GetProductById(int id)
        {
            return ProductRepository.GetProductById(id);
        }
    }
}
