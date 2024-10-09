using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Vogue
{
    public partial class AdminOrders : System.Web.UI.Page
    {
        AdminServices adminServices = new AdminServices();

        public void BindData()
        {
            orderRepeater.DataSource = adminServices.GetOrders();
            orderRepeater.DataBind();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vendor"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            BindData();
           
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["vendor"] = null;
            Response.Redirect("Login.aspx");
        }

        
        protected void packBtn_Command(object sender, CommandEventArgs e)
        {
            adminServices.PackOrder(Convert.ToInt32(e.CommandArgument));
            BindData();
        }

        protected void shipBtn_Command(object sender, CommandEventArgs e)
        {
            adminServices.ShipOrder(Convert.ToInt32(e.CommandArgument));
            BindData();
        }

        protected void deliverBtn_Command(object sender, CommandEventArgs e)
        {
            adminServices.DeliverOrder(Convert.ToInt32(e.CommandArgument));
            BindData();
        }
    }
}