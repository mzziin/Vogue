using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace Vogue
{
    public partial class AdminPanal : System.Web.UI.Page
    {
        AdminServices obj = new AdminServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vendor"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            BindData();
        }

        public void BindData()
        {
            DataSet ds = obj.Gridbind();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            obj.DeleteProduct(getid);
            BindData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ActionCommand")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];

                Session["Pid"] = row.Cells[3].Text; // Data from the first column

                Response.Redirect("AdminProductUpdate.aspx");
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["vendor"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}