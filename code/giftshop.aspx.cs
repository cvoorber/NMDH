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

    protected void btnAddShoes_Click(object sender, EventArgs e) {  
        // Add product 1 to the shopping cart  
        cartClass.Instance.AddItem(1);  
  
        // Redirect the user to view their shopping cart  
        Response.Redirect("ViewCart.aspx");  
    }  
  
    protected void btnAddShirt_Click(object sender, EventArgs e) {  
        cartClass.Instance.AddItem(2);  
        Response.Redirect("ViewCart.aspx");  
    }

    protected void btnAddPants_Click(object sender, EventArgs e) {
        cartClass.Instance.AddItem(3);
        Response.Redirect("ViewCart.aspx");
    }
}