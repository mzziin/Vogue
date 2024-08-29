using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Entities;
using BLL;

namespace Vogue
{
    public partial class AdminProductUpdate : System.Web.UI.Page
    {
        ProductService obj = new ProductService();
        AdminServices obj1 = new AdminServices();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["vendor"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                int pid = Convert.ToInt32(Session["Pid"]);
                ProductEntity product = obj.ListProduct(pid);

                pname.Text = product.Name;
                description.Text = product.Description;
                stock.Text = (product.Stock).ToString();
                price.Text = (product.Price).ToString();

                DropDownList1.DataSource = obj1.GetCategoryItems();
                DropDownList1.DataTextField = "CategoryName";
                DropDownList1.DataValueField = "CategoryId";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string imageUrl = "~/Images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(imageUrl));
            int pid = Convert.ToInt32(Session["Pid"]);

            obj1.UpdateProduct(pname.Text, description.Text, price.Text, stock.Text, imageUrl, DropDownList1.SelectedValue, pid);

            Response.Redirect("AdminPanel.aspx");
        }
    }
}