using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class giftshop : System.Web.UI.Page
{
    productsClass objLinq = new productsClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }

    private void _subRebind()
    {
        listProducts.DataSource = objLinq.getProducts();
        listProducts.DataBind();
    }
}