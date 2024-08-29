using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;
using System.Data;

namespace BLL
{
    public class ProductService
    {
        ProductDataAccess obj = new ProductDataAccess();
        public List<ProductEntity> ListAllProducts()
        {
            var products =  obj.GetAllProducts();
            return products;
        }

        public List<ProductEntity> ListAllProducts(string Cid)
        {
             
            var products = obj.GetAllProductsOnCategory(Convert.ToInt32(Cid));
            return products;
        }
        public ProductEntity ListProduct(int id)
        {
            var product = obj.GetProductById(id);
            return product;
        }
        public DataTable GetCategory()
        {
            DataTable dt = obj.GetCategories();
            return dt;
        }
    }
}
