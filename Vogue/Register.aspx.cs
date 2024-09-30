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
        UserService userService = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace( Request.QueryString["error"]))
            {
                
                error_msg.Visible = true;
                error_msg.Text = Request.QueryString["error"];
            }
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

            List<string> labels = new List<string> {Name, Username, Email, Pwd, Role, Phone, Address, Zip };
            foreach(string i in labels){
                if (string.IsNullOrWhiteSpace(i))
                {
                    error_msg.Text = "Enter all details correctly";
                    Response.Redirect("Register.aspx?error=Enter all details correctly");
                }
            }

            bool status = userService.InsertUser(Name, Username, Email, Pwd, Role, Phone, Address, Zip);
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