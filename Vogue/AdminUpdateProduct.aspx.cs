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
    public partial class AdminUpdateProduct : System.Web.UI.Page
    {
        ProductService productService = new ProductService();
        AdminServices adminService = new AdminServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vendor"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                int pid = Convert.ToInt32(Session["Pid"]);
                ProductEntity product = productService.ListProduct(pid);

                pname.Text = product.Name;
                description.Text = product.Description;
                stock.Text = (product.Stock).ToString();
                price.Text = (product.Price).ToString();

                categoryDropDown.DataSource = adminService.GetCategoryItems();
                categoryDropDown.DataTextField = "CategoryName";
                categoryDropDown.DataValueField = "CategoryId";
                categoryDropDown.SelectedValue = product.CategoryId.ToString();
                categoryDropDown.DataBind();
            }

        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(Session["Pid"]);
            ProductEntity product = productService.ListProduct(pid);
            string imageUrl = product.ImageUrl;

            if (imgUpload.HasFile)
            {
                imageUrl = "/Images/" + imgUpload.FileName;
                imgUpload.SaveAs(MapPath(imageUrl));
            }

            adminService.UpdateProduct(pname.Text, description.Text, price.Text, stock.Text, imageUrl, categoryDropDown.SelectedValue, pid);

            Response.Redirect("AdminPanel.aspx");
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }
    }
}