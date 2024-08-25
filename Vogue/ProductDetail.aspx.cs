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
;               }
            }
           
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string i = AddtoCart(productId.Text);
        }
    }
}