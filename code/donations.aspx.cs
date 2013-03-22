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
            // Taking the input from the ui panel and temporarily storing it in properties (make into a fucntion)
            
            objDonate.uifirstName = txt_fname.Text.ToString();
            objDonate.uilastName = txt_lname.Text.ToString();
            objDonate.uiEmail = txt_email.Text.ToString();
            objDonate.uiEmail = txt_mem.Text.ToString();
            objDonate.uiDonate = txt_donate.Text.ToString();
            objDonate.uiAddress = txt_address.Text.ToString();
            objDonate.uiCity = txt_city.Text.ToString();
            objDonate.uiCountry = ddl_country.SelectedItem.Value.ToString();
            objDonate.uiProvState = ddl_provstate.SelectedItem.Value.ToString();
            objDonate.uiPostZip = txt_postzip.Text.ToString();
            objDonate.uiComments = txt_comments.Text.ToString();

            // hdiding user info panel, revealing credit info panel (make into a function)
            pnl_uinfo.Visible = false;
            pnl_credit.Visible = true;
        }
            // this will be triggered when clicking on CreditNext button
        else if (e.CommandName == "CreditNext")
        {
            // Taking the input from the credit panel and temporarily storing it in properties (make into a fucntion)
            
            objDonate.credName = txt_credname.Text.ToString();
            objDonate.credAddress = txt_credaddress.Text.ToString();
            objDonate.credCity = txt_credcity.Text.ToString();
            objDonate.credCountry = ddl_credcountry.SelectedItem.Value.ToString();
            objDonate.credProvState = ddl_credprovstate.SelectedItem.Value.ToString();
            objDonate.credPostZip = txt_credpostzip.Text.ToString();
            objDonate.credNumber = txt_crednumber.Text.ToString();
            objDonate.credCode = txt_credcode.Text.ToString();
            
            // hiding credit info panel, showing confirmation panel (make into a function)
            pnl_credit.Visible = false;
            pnl_confirm.Visible = true;

            // add code for taking information from both arrays to display on confirmation page
        }
    }

    // gotta have a subRoutine that when you click on the button loads info from user Array into the credit form.

    // This routine will transfer info over from mailing address form to credit card billing form
    protected void subTransferInfo(object sender, EventArgs e)
    {
        // this should use some of the information from the user array and transfer it over to the credit info view
    }


    // this subroutine will bind the ddl to the list of countries and set the value field and text field
    private void subCountryBind()
    {
        ddl_country.DataSource = objDonate.getAllCountries();
        ddl_country.DataValueField = "country_id";
        ddl_country.DataTextField = "name_en";
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
        
        // I think this represents the country, rather than the country id - not sure what value is.
        var countryChoice = ddl_country.SelectedValue.ToString();

        if (countryChoice == "Canada" || countryChoice == "United States")
        {
            // Show provstate dropdown list - this should be by AJAX
            // call getAllStatesorProvinces

            // show label and text box for postal code/ZIP
            if (countryChoice == "Canada")
            {
                //postal code validation - ajax
                // set label text to say Postal code -ajax
            }
            else
            {
                //zip code validation - ajax
                // set label text to say ZIP code -ajax
            }

        }
        // might need an else here to do nothing to make this work, not sure

    }

}