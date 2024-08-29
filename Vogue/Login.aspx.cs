using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;

namespace Vogue
{
    public partial class Login : System.Web.UI.Page
    {
        UserService obj = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            string uname = username.Text;
            string password = pwd.Text;
            if(obj.ValidateUser(uname, password))
            {
                int UserId = obj.GetUserId(uname, password);
                string UserRole = obj.GetUserRole(uname, password);
                FormsAuthentication.SetAuthCookie(uname, true);
                if (UserRole == "Customer")
                {
                    Session["customer"] = UserId;
                    Response.Redirect("index.aspx");
                }
                else if(UserRole == "Vendor")
                {
                    Session["vendor"] = UserId;
                    Response.Redirect("AdminPanel.aspx");
                }

            }
            else
            {
                errorMsg.Visible = true;
                errorMsg.Text = "Invalid Username or Password";
            }
        }
    }
}