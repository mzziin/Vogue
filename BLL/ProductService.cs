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
        ProductDataAccess productDataAccess = new ProductDataAccess();
        public List<ProductEntity> ListAllProducts()
        {
            var products =  productDataAccess.GetAllProducts();
            return products;
        }

        public List<ProductEntity> ListAllProducts(string Cid)
        {
             
            var products = productDataAccess.GetAllProductsOnCategory(Convert.ToInt32(Cid));
            return products;
        }
        public ProductEntity ListProduct(int id)
        {
            var product = productDataAccess.GetProductById(id);
            return product;
        }
        public void DeleteProduct(int pid)
        {
            productDataAccess.Delete(pid);
        }
        public void UpdateProductStock(int pid, int qty)
        {
            ProductEntity product = productDataAccess.GetProductById(pid);
            qty = product.Stock - qty;
            productDataAccess.UpdateStock(pid, qty);
        }
        public void StockOutProduct(int pid)
        {
            productDataAccess.UpdateStock(pid, 0); ;
        }
        public int GetStock(int pId)
        {
            ProductEntity product = productDataAccess.GetProductById(pId);
            return product.Stock;
        }
        public DataTable GetCategory()
        {
            DataTable dt = productDataAccess.GetCategories();
            return dt;
        }
    }
}
