using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL
{
    public class CheckoutService
    {
        CartService cartService = new CartService();
        OrderService orderService = new OrderService();
        ProductService productService = new ProductService();

        public void Checkout(int uid, string paymentMethod, string address)
        {            
            decimal sumprice = cartService.GetTotalPrice(uid);
            DateTime date = DateTime.Now;
            bool paymentStatus = true;
            string orderStatus = "";

            if (paymentStatus)
            {
                orderStatus = "Confirmed";
            }
            else
            {
                orderStatus = "Pending";
            }

            int orderId = orderService.AddOrder(uid, date.ToString("dd-MM-yyyy"), sumprice, orderStatus, paymentMethod, address);

            List<CartEntity> cartList = cartService.ListAllProducts(uid);
            foreach (var cartItem in cartList)
            {
                orderService.AddOrderDetails(orderId, cartItem.ProductId, cartItem.Quantity, cartItem.UnitPrice, cartItem.TotalPrice);
                productService.UpdateProductStock(cartItem.ProductId, cartItem.Quantity);
            }
            // deleting product from table will cause error in orderdetail table since it contain foreign key to productid
            /* List<ProductEntity> products = productService.ListAllProducts();
             foreach(var product in products)
             {
                 if(product.Stock == 0)
                 {
                     productService.DeleteProduct(product.ProductId);
                 }
             }*/
            cartService.DeleteCartOfUser(uid);
        }
    }
}
