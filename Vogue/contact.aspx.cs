using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vogue
{
    public partial class Contact : System.Web.UI.Page
    {
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
                loginlabel.Visible = true;
                registerlabel.Visible = true;
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {

            
        }
    }
}