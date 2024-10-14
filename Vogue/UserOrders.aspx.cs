using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Vogue
{
    public partial class UserOrders : System.Web.UI.Page
    {
        OrderService orderService = new OrderService();
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Session["customer"]);

            if (Session["customer"] != null)
            {
                loginlabel.Visible = false;
                registerlabel.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                int pId = Convert.ToInt32(Session["customer"]);
                order_repeater.DataSource = orderService.GetOrdersOfUser(pId);
                order_repeater.DataBind();
            }
        }
        protected string GetStatusClass(string status)
        {
            switch (status.ToLower())
            {
                case "pending":
                    return "text-warning";  // Yellow color for pending status
                case "shipped":
                    return "text-info";  // Blue color for shipped status
                case "delivered":
                    return "text-success";  // Green color for delivered status
                default:
                    return "text-secondary"; // Default grey color
            }
        }

    }
}