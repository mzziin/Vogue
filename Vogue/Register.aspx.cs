using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Vogue
{
    public partial class Register : System.Web.UI.Page
    {
        UserService obj = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            string Name = fullname.Text;
            string Username = uname.Text;
            string Email = email.Text;
            string Pwd = pwd.Text;
            string Role = role.SelectedValue;
            string Phone = phone.Text;
            string Address = address.Text;
            string Zip = zip.Text;

            bool status = obj.InsertUser(Name, Username, Email, Pwd, Role, Phone, Address, Zip);
            if(status == true)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                error_msg.Text = "An error Occurred";
            }
        }
    }
}