using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using System.Data;

namespace BLL
{
    public class AdminServices
    {
        AdminDataAccess adminDataAccess = new AdminDataAccess();
        ProductService productService = new ProductService();
        CartService cartService = new CartService();
        public void DeleteProduct(int pid)
        {
            int i = adminDataAccess.Delete(pid);
        }
        public DataSet Gridbind()
        {
            DataSet ds = adminDataAccess.Gridbind_Fun();
            return ds;
        }
        public DataTable GetCategoryItems()
        {
            DataTable ds = adminDataAccess.GetCategories();
            return ds;
        }
        public void AddProduct(string name , string desc, string price, string stock, string imageurl, string categoryid)
        {
            decimal convertedPrice = Convert.ToDecimal(price);
            int convertedStock = Convert.ToInt32(stock);
            int convertedCategoryid = Convert.ToInt32(categoryid);
            adminDataAccess.AddProductToDb(name, desc, convertedPrice, convertedStock, imageurl, convertedCategoryid);
        }
        public void UpdateProduct(string name, string desc, string price, string stock, string imageurl, string categoryid, int pid)
        {
            decimal convertedPrice = Convert.ToDecimal(price);
            int convertedStock = Convert.ToInt32(stock);
            int convertedCategoryid = Convert.ToInt32(categoryid);
            adminDataAccess.UpdateProductFromDb(name, desc, convertedPrice, convertedStock, imageurl, convertedCategoryid, pid);
        }
        public void MarkAsOutOfStock(int pId)
        {
            productService.StockOutProduct(pId);
            cartService.DeleteFromCartByProduct(pId);
        }

        public DataTable GetOrders()
        {
            return adminDataAccess.GetOrdersFromDb();
        }
        public void PackOrder(int orderId)
        {
            adminDataAccess.UpdateOrderStatus(orderId, "Packed");
        }

        public void ShipOrder(int orderId)
        {
            adminDataAccess.UpdateOrderStatus(orderId, "Shipped");
        }
        public void DeliverOrder(int orderId)
        {
            adminDataAccess.UpdateOrderStatus(orderId, "Delivered");
        }
        public string CheckOrderStatus(int orderId)
        {
            return adminDataAccess.CheckStatus(orderId);
        }
    }
}
