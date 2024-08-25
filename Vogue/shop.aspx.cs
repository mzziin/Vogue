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
    public partial class shop : System.Web.UI.Page
    {
        ProductService obj = new ProductService();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                List<ProductEntity> products =  obj.ListAllProducts();
                repeat_product.DataSource = products;
                repeat_product.DataBind();

            }

        }
    }
}