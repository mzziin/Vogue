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
        ProductService productService = new ProductService();
        CartService cartService = new CartService();
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
                Button logoutBtn = (Button)Master.FindControl("logoutBtn");
                logoutBtn.Visible = false;
                loginlabel.Visible = true;
                registerlabel.Visible = true;
            }
            if (!IsPostBack)
            {
                if (pid != null)
                {
                    int id = Convert.ToInt32(pid);
                    ProductEntity product = productService.ListProduct(id);
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
                int uId = Convert.ToInt32(Session["Customer"]);
                int pId = Convert.ToInt32(Request.QueryString["ProductId"]);
                
                cartService.AddToCart(uId, pId);

                Response.Redirect("Cart.aspx");
            }
        }
            
    }
}