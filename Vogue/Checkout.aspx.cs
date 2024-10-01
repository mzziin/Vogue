using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Vogue
{
    public partial class Checkout : System.Web.UI.Page
    {
        CheckoutService checkoutService = new CheckoutService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                loginlabel.Visible = false;
                registerlabel.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }            
        }

        protected void orderbtn_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Session["customer"]);
            string paymentMethod = payment.SelectedValue;
            string address = fname.Text + " " + lname.Text + ", " + address1.Text + ", " + address2.Text + ", " +
                city.Text + ", " + state.Text + ", " + country.SelectedItem.Text + ", " + zipcode.Text;

            checkoutService.Checkout(uid, paymentMethod, address);            
            Response.Redirect("index.aspx");
        }
    }
}