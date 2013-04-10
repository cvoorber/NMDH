using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class giftshop : System.Web.UI.Page
{
    //instantiating the products class
    productsClass objLinq = new productsClass();

    //binding data on initial page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }

    //binding products to list
    private void _subRebind()
    {
        listProducts.DataSource = objLinq.getProducts();
        listProducts.DataBind();
    }

    //subroutine carried out to add item to shopping cart based on id
    protected void subAdmin(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "addItem")
        {
            HiddenField hdfProd = (HiddenField)e.Item.FindControl("hdf_prod");
            int _id = int.Parse(hdfProd.Value.ToString());
            //this is finding or creating the session variable
            cartClass cart = cartClass.GetShoppingCart();
            cart.AddItem(_id);
            Response.Redirect("ViewCart.aspx");
        }
    }
}