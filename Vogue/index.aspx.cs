﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Vogue
{
    public partial class index : System.Web.UI.Page
    {
        ProductService obj = new ProductService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["customer"] != null)
                {
                    loginlabel.Visible = false;
                    registerlabel.Visible = false;
                }
                else
                {
                    loginlabel.Visible = true;
                    registerlabel.Visible = true;
                }
            }
            repeat_category.DataSource = obj.GetCategory();
            repeat_category.DataBind();
        }
    }
}