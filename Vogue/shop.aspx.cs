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
        ProductService productService = new ProductService();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Cid = Request.QueryString["CategoryId"];

            repeat_category.DataSource = productService.GetCategory();
            repeat_category.DataBind();

            if (Session["customer"] != null)
            {
                loginlabel.Visible = false;
                registerlabel.Visible = false;
            }
            else
            {
                Button logoutbtn = (Button)Master.FindControl("logoutBtn");
                logoutbtn.Visible = false;
                loginlabel.Visible = true;
                registerlabel.Visible = true;
            }

            if (!IsPostBack)
            {
                if(Cid != null)
                {
                    List<ProductEntity> products = productService.ListAllProducts(Cid);
                    repeat_product.DataSource = products;
                    repeat_product.DataBind();
                }
                else
                {
                    List<ProductEntity> products = productService.ListAllProducts();
                    repeat_product.DataSource = products;
                    repeat_product.DataBind();
                }
            }

        }
    }
}