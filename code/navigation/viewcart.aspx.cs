using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class navigation_viewcart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
        {
            // Binding the items
            if (!IsPostBack)
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
        }

        protected void gridCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Displaying the subtotal of all the products in the gridview footer
            if (e.Row.RowType == DataControlRowType.Footer) 
            {
                cartClass cart = cartClass.GetShoppingCart();
                e.Row.Cells[3].Text = "Total: " + cart.GetSubTotal().ToString("C"); 
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

        protected void subOrder(object sender, EventArgs e)
        {

        }

        protected void btnSubCheckout(object sender, EventArgs e)
        {

        }
}