using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Vogue
{
    public partial class AdminAddP : System.Web.UI.Page
    {
        AdminServices adminServices = new AdminServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vendor"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            categoryDropDown.DataSource = adminServices.GetCategoryItems();
            categoryDropDown.DataTextField = "CategoryName";
            categoryDropDown.DataValueField = "CategoryId";
            categoryDropDown.DataBind();
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            string category = categoryDropDown.SelectedValue;
            string imageurl = "/Images/" + imgUpload.FileName;

            imgUpload.SaveAs(MapPath(imageurl));
            adminServices.AddProduct(pname.Text, description.Text, price.Text, stock.Text, imageurl, category);

            Response.Redirect("AdminPanel.aspx");
        }
    }
}