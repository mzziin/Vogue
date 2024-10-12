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
        void DisableButton(LinkButton btn)
        {
            btn.CssClass += " disabled btn-outline-primary";
            btn.Enabled = false;
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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // Check if the item is not a header or footer row
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Get the order status from the data item
                string orderStatus = DataBinder.Eval(e.Item.DataItem, "OrderStatus").ToString();

                LinkButton packBtn = (LinkButton)e.Item.FindControl("packBtn");
                LinkButton shipBtn = (LinkButton)e.Item.FindControl("shipBtn");
                LinkButton deliverBtn = (LinkButton)e.Item.FindControl("deliverBtn");

                if (orderStatus == "Pending")
                {
                    packBtn.Enabled = true;
                    DisableButton(shipBtn);
                    DisableButton(deliverBtn);
                }
                else if (orderStatus == "Packed")
                {
                    DisableButton(packBtn);
                    shipBtn.Enabled = true;
                    DisableButton(deliverBtn);
                }
                else if (orderStatus == "Shipped")
                {
                    DisableButton(packBtn);
                    DisableButton(shipBtn);
                    deliverBtn.Enabled = true;
                }
                else if (orderStatus == "Delivered")
                {
                    DisableButton(packBtn);
                    DisableButton(shipBtn);
                    DisableButton(deliverBtn);
                }
            }
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