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
    public partial class ProductDetail : System.Web.UI.Page
    {
        ProductService obj = new ProductService();
        CartService obj2 = new CartService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string pid = Request.QueryString["ProductId"];
            if (Session["customer"] != null)
            {
                loginlabel.Visible = false;
                registerlabel.Visible = false;
            }
            else
            {
                loginlabel.Visible = true;
                registerlabel.Visible = true;
            }
            if (!IsPostBack)
            {
                if (pid != null)
                {
                    int id = Convert.ToInt32(pid);
                    ProductEntity product = obj.ListProduct(id);
                    name.Text = product.Name;
                    description.Text = product.Description;
                    price.Text = product.Price.ToString();
                    productId.Text = pid;
                    Image1.ImageUrl = product.ImageUrl;
;               }
            }
           
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if(Session["customer"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int qty=1;
                int uid = Convert.ToInt32(Session["Customer"]);
                int pid = Convert.ToInt32(Request.QueryString["ProductId"]);
                ProductEntity product = obj.ListProduct(pid);
                int count = obj2.QtyOfCartProducts( uid, pid);
                if(count == 0)
                {
                    obj2.AddToCart(uid, pid, qty, product.Price, product.Price, product.Name, product.ImageUrl);
                }
                else
                {
                    qty = count + 1;
                    decimal totalprice = qty * product.Price;
                    obj2.UpdateCartByProductAndUser(pid, qty, uid, totalprice);
                }
                Response.Redirect("Cart.aspx");
            }
        }
            
    }
}