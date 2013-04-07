using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admindonations : System.Web.UI.Page
{
    // instance of admin donations class
    donationsAdminClass objDonAd = new donationsAdminClass();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            // binds donations data to main listiview control
            bindAllDonations();
        }

    }

    // routine for when the button for editing gets hit
    protected void subItemEdit(object sender, ListViewEditEventArgs e)
    {
        
    
    }

    // routine for when the button for inserting gets hit
    protected void subItemInsert(object sender, ListViewInsertEventArgs e)
    {


    }

    // routine for when the button for deleting gets hit
    protected void subItemDelete(object sender, ListViewDeleteEventArgs e)
    {


    }



    
    // binds donations data to main listview control
    private void bindAllDonations()
    {
        lsv_main.DataSource = objDonAd.getAllDonRecords();
        lsv_main.DataBind();
    }

}