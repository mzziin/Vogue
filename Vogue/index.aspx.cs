using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Vogue
{
    public partial class index : System.Web.UI.Page
    {
        ProductService productService = new ProductService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            }
            repeat_category.DataSource = productService.GetCategory();
            repeat_category.DataBind();
        }
    }
}