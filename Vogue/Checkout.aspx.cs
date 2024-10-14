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
        EmailService emailService = new EmailService();
        UserService userService = new UserService();
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
            //var user = userService.GetUserNameAndEmail(uid);
            //string body = @"your order has been placed, will arrive within 2-3 working days";
            //emailService.SendEmail2("Vogue", "vogue5981@gmail.com", "5981@vogue", user.FullName, user.Email, "Your order has been placed", body);
            Response.Redirect("index.aspx");
        }
    }
}