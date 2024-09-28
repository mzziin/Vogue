using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL.Entities;

namespace Vogue
{
    public partial class Checkout : System.Web.UI.Page
    {
        CartService cartService = new CartService();
        OrderService orderService = new OrderService();
        ProductService productService = new ProductService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                loginlabel.Visible = false;
                registerlabel.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }            
        }

        protected void orderbtn_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Session["customer"]);
            decimal sumprice = cartService.GetTotalPrice(uid);
            DateTime date = DateTime.Now;
            string paymentMethod = payment.SelectedValue;
            string address = fname.Text + " " + lname.Text + ", " + address1.Text + ", " + address2.Text + ", " +
                city.Text + ", " + state.Text + ", " + country.SelectedItem.Text + ", " + zipcode.Text;

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

            cartService.DeleteCartOfUser(uid);
            
            Response.Redirect("index.aspx");
        }
    }
}