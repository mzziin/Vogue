using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Vogue
{
    public partial class AdminAddProduct : System.Web.UI.Page
    {
        AdminServices obj = new AdminServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vendor"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            DropDownList1.DataSource = obj.GetCategoryItems();
            DropDownList1.DataTextField = "CategoryName";
            DropDownList1.DataValueField = "CategoryId";
            DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Productname = pname.Text;
            string Desc = description.Text;
            string Price = price.Text;
            string Stock = stock.Text;
            string category = DropDownList1.SelectedValue;
            string imageurl = "~/Images/" + FileUpload1.FileName;

            FileUpload1.SaveAs(MapPath(imageurl));
            obj.AddProduct(Productname, Desc, Price, Stock, imageurl, category);

            Response.Redirect("AdminPanel.aspx");
        }
    }
}