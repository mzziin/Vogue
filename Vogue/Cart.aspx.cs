using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL.Entities;

namespace Vogue
{
    public partial class Cart : System.Web.UI.Page
    {
        CartService obj = new CartService();
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Session["customer"]);
            if (Session["customer"] != null)
            {
                loginlabel.Visible = false;
                registerlabel.Visible = false;
            }
            else
            {
                Response.Redirect("Login.aspx");
                
            }
            if (!IsPostBack)
            {
                List<CartEntity> cart = obj.ListAllProducts(uid);
                repeat_cart_product.DataSource = cart;
                repeat_cart_product.DataBind();
                decimal sumprice = obj.GetTotalPrice(uid);
                totalsum.Text = sumprice.ToString();
                totalsum1.Text = sumprice.ToString();
            }
        }

        protected void repeat_cart_product_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int uId = Convert.ToInt32(Session["Customer"]);
            int pId = Convert.ToInt32(e.CommandArgument.ToString());
            int Qty = obj.QtyOfCartProducts(uId, pId);

            Label unitlbl = (Label)e.Item.FindControl("unitlabel");
            decimal unitprice = Convert.ToDecimal(unitlbl.Text);
            decimal totalprice;

            switch (e.CommandName)
            {
                case "plus":
                    Qty++;
                    totalprice = Qty * unitprice;
                    obj.UpdateCartByProductAndUser(pId, Qty, uId, totalprice);
                    break;

                case "minus":
                    Qty--;
                    if(Qty < 1)
                    {
                        obj.DeleteFromCartByProductAndUser(pId, uId);
                    }
                    else
                    {
                        totalprice = Qty * unitprice;
                        obj.UpdateCartByProductAndUser(pId, Qty, uId, totalprice);
                    }
                    break;

                case "remove":
                    obj.DeleteFromCartByProductAndUser(pId, uId);
                    break;
            }
            Response.Redirect("Cart.aspx");
        }

        protected void checkoutbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}