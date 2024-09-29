using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Vogue
{
    public partial class AdminP : System.Web.UI.Page
    {
        AdminServices adminServices = new AdminServices();
        ProductService productService = new ProductService();
        public void BindData()
        {
            productRepeater.DataSource = adminServices.Gridbind();
            productRepeater.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["vendor"] == null)
            {
                Response.Redirect("Login.aspx");
            }*/
            BindData();
            
        }

        protected void editBtn_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "Edit")
            {
                string pId = e.CommandArgument.ToString();
                Session["Pid"] = pId;
                Response.Redirect("AdminProductUpdate.aspx");
            }
        }

        protected void deleteBtn_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int pId = Convert.ToInt32(e.CommandArgument.ToString());
                productService.UpdateProductStock(Convert.ToInt32(pId), 0);
                adminServices.MarkAsOutOfStock(Convert.ToInt32(pId));

                //deleting product causes issue in other tables that references it
                /*adminServices.DeleteProduct(Convert.ToInt32(pId));*/
                BindData();
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["vendor"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddProduct.aspx");
        }
    }
}