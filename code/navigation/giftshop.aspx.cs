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

    private int getOrder(int customerID)
    {
        if (Session["OrderID"] != null && Session["OrderID"].ToString().Length > 0)
        {
            //set session and insert order
            return 1;
        }
        else
        {
            //use current session
            return int.Parse(Session["OrderID"].ToString());
        }
    }

    protected void subAdmin(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "addItem")
        {
            HiddenField hdfProd = (HiddenField)e.Item.FindControl("hdf_prod");
            int _id = int.Parse(hdfProd.Value.ToString());
            cartClass cart = cartClass.GetShoppingCart();
            cart.AddItem(_id);
            Response.Redirect("ViewCart.aspx");
        }
    }
}