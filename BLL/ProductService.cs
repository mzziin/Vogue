using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;

namespace BLL
{
    public class ProductService
    {
        ProductRepository obj = new ProductRepository();
        public List<ProductEntity> ListAllProducts()
        {
            var products =  obj.GetAllProducts();
            return products;
        }
        public ProductEntity ListProduct(int id)
        {
            var product = obj.GetProductById(id);
            return product;
        }
    }
}
