using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class donations : System.Web.UI.Page
{
    donationsClass objDonate = new donationsClass();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // event caused by clicking on either of the two next buttons
    // pass command name as parameter
    protected void subNextClick(object sender, CommandEventArgs e)
    {
        // this will be triggered when clicking on the UiNext button
        if (e.CommandName == "UiNext")
        {
            // Taking the input from the ui panel and temporarily storing it in an array (make into a fucntion)
            string[] userArray = new string[11];
            userArray[0] = txt_fname.Text.ToString();
            userArray[1] = txt_lname.Text.ToString();
            userArray[2] = txt_email.Text.ToString();
            userArray[3] = txt_mem.Text.ToString();
            userArray[4] = txt_donate.Text.ToString();
            userArray[5] = txt_address.Text.ToString();
            userArray[6] = txt_city.Text.ToString();
            userArray[7] = ddl_country.SelectedItem.Value.ToString();
            userArray[8] = ddl_provstate.SelectedItem.Value.ToString();
            userArray[9] = txt_postzip.Text.ToString();
            userArray[10] = txt_comments.Text.ToString();

            // hdiding user info panel, revealing credit info panel (make into a function)
            pnl_uinfo.Visible = false;
            pnl_credit.Visible = true;
        }
            // this will be triggered when clicking on CreditNext button
        else if (e.CommandName == "CreditNext")
        {
            // Taking the input from the credit panel and temporarily storing it in an array (make into a fucntion)
            string[] creditArray = new string[8];
            creditArray[0] = txt_credname.Text.ToString();
            creditArray[1] = txt_credaddress.Text.ToString();
            creditArray[2] = txt_credcity.Text.ToString();
            creditArray[3] = ddl_credcountry.SelectedItem.Value.ToString();
            creditArray[4] = ddl_credprovstate.SelectedItem.Value.ToString();
            creditArray[5] = txt_credpostzip.Text.ToString();
            creditArray[6] = txt_crednumber.Text.ToString();
            creditArray[7] = txt_credcode..Text.ToString();
            
            // hiding credit info panel, showing confirmation panel (make into a function)
            pnl_credit.Visible = false;
            pnl_confirm.Visible = true;
        }
    }

    // gotta have a subRoutine that when you click on the button loads info from user Array into the credit form.

    // This routine will transfer info over from mailing address form to credit card billing form
    protected void subTransferInfo(object sender, EventArgs e)
    {
        // this should use some of the information from the user array and transfer it over to the credit info view
    }


    // this subroutine will bind the ddl to the list of countries
    private void subDdlBind()
    {
        ddl_country.DataSource = objDonate.getAllCountries();
        ddl_country.DataBind();
    }

    // this subroutine after a country is selected, will reveal the prov/state ddl if country selected
    // is either canada or US and will specify eitehr postal code or zip (with label text and validation)
    // depending upon if it is Canada or US.
    protected void subCountryDisplayProvPost(object sender, EventArgs e)
    {
        // do a test based on the argument passed from the selectd country and if it is either 
        // canada or US then the prov/state list should appear and the ZIP/Postal Code
        // text box should appear, and the validation and label should be decided depeneding on 
        //which nAMerican country it is.
        // this should also happen Asynchronoously ... so might need to add another Trigger for this event
        // that would have the target control id as the DDL in question.activdirectopia/rmccoleman  
    }

}