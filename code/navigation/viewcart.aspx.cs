using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class navigation_viewcart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Binding the items on initial page load
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    protected void BindData()
    {
        // Displays the current items in the cart
        cartClass cart = cartClass.GetShoppingCart();
        gridCart.DataSource = cart.Items;
        gridCart.DataBind();
        //shows only the order panel
        PanelControl(pnl_order);
    }

    //using bound fields to determine subTotal
    protected void gridCart_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Displaying the subtotal of all the products in the gridview footer
        if (e.Row.RowType == DataControlRowType.Footer) 
        {
            cartClass cart = cartClass.GetShoppingCart();
            e.Row.Cells[3].Text = "Total: $" + cart.GetSubTotal().ToString(); 
        }
    }

    // Subroutine for removing items from the cart
    protected void gridCart_RowCommand(object sender, GridViewCommandEventArgs e) {
        if (e.CommandName == "Remove") 
        {
            int productId = Convert.ToInt32(e.CommandArgument);
            cartClass cart = cartClass.GetShoppingCart();
            cart.RemoveItem(productId);
        }

        // Resetting with the new data in the cart
        BindData();
    }

    // Updating the Cart based on textbox value
    protected void btnSubUpdate(object sender, EventArgs e) {
        foreach (GridViewRow row in gridCart.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow) {
                try
                {
                    // Get the productId from the cart
                    int productId = Convert.ToInt32(gridCart.DataKeys[row.RowIndex].Value);
                    // Find the quantity TextBox and use the value to set the new quantity
                    int quantity = int.Parse(((TextBox)row.Cells[1].FindControl("txt_quantity")).Text);
                    cartClass cart = cartClass.GetShoppingCart();
                    cart.SetItemQuantity(productId, quantity);
                }
                catch (FormatException) 
                {
                }
            }
        }

        BindData();
    }

    //clears the submission form data
    protected void clearForm(object sender, EventArgs e)
    {
        txt_name.Text = string.Empty;
        txt_address.Text = string.Empty;
        txt_city.Text = string.Empty;
        txt_postal.Text = string.Empty;
        ddl_province.SelectedValue = "0";
        txt_email.Text = string.Empty;
        txt_emailrepeat.Text = string.Empty;
    }

    // displays the checkout panel
    protected void btnSubCheckout(object sender, EventArgs e)
    {
        PanelControl(pnl_checkout);
    }

    //simple return from checkout panel to order view *does NOT destroy cart in session*
    protected void backtocart(object sender, EventArgs e)
    {
        BindData();
    }

    // sends email with order information
    protected void subOrder(object sender, EventArgs e)
    {
        //instantiating the class
        cartClass cart = cartClass.GetShoppingCart();
        //getting subtotal value for the email message
        string Details = "Details ~ " + cart.GetDetails().ToString();
        string SubTotal = "Total ~ $" + cart.GetSubTotal().ToString();

        //setting the content/data for the email
        string emaildata = "Name: " + txt_name.Text + ", Address: " + txt_address.Text + ", " + txt_city.Text + ", " + txt_postal.Text + ", " + ddl_province.Text.ToString() + ", Order: " + SubTotal + " ~ " + Details + " ~ THANK-YOU";
        //specifying the object and contents of the message
        MailMessage objMailOrder = new MailMessage("giftshop@ndmh.ca", "chris.voorberg@gmail.com", "New NDMH Giftshop Order", emaildata);
            
        //carrying out the mail procedure
        SmtpClient server = new SmtpClient();
        server.Host = "localhost";
        server.Port = 25;
        server.Send(objMailOrder);

        //alert to the client confirming their order
        Response.Write("<script>alert('Thanks for your Order! You will be contacted regarding payment and invoicing.');</script>");

        //killing the shopping cart session
        Session.Abandon();

        //clearing the form
        txt_name.Text = string.Empty;
        txt_address.Text = string.Empty;
        txt_city.Text = string.Empty;
        txt_postal.Text = string.Empty;
        ddl_province.SelectedValue = "0";
        txt_email.Text = string.Empty;
        txt_emailrepeat.Text = string.Empty;
    }

    // control panel visibility for order/checkout details
    protected void PanelControl(Panel pnl)
    {
        pnl_order.Visible = false;
        pnl_checkout.Visible = false;
        pnl.Visible = true;
    }
}