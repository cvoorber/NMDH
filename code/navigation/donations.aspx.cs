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
        if (!Page.IsPostBack)
        {   
            // binding the list of the country and provinces for the mailing view
            subCountryBind();
            subProvStateBind();

            // setting default values for hidden fields for mailing post/zip and mailng prov/state
            txt_postzip.Text = "---";
            ddl_provstate.SelectedItem.Text = "---";
        }
    }

    // routine from clicking on mailing view (first view) next button
    protected void subNextUiClick(object sender, EventArgs e)
    {
       
       
            // Taking the input from the ui panel and temporarily storing it in properties (make into a fucntion)
            
            objDonate.uifirstName = txt_fname.Text.ToString();
            objDonate.uilastName = txt_lname.Text.ToString();
            objDonate.uiEmail = txt_email.Text.ToString();
            objDonate.uiMemory = txt_mem.Text.ToString();
            objDonate.uiDonate = txt_donate.Text.ToString();
            objDonate.uiAddress = txt_address.Text.ToString();
            objDonate.uiCity = txt_city.Text.ToString();
            objDonate.uiCountry = ddl_country.SelectedItem.Text;
            objDonate.uiProvState = ddl_provstate.SelectedItem.Text;
            objDonate.uiPostZip = txt_postzip.Text.ToString();
            

            // setting the values for the confirmation page
            lbl_confamount.Text = objDonate.uiDonate;
            lbl_maddress.Text = objDonate.uiAddress;
            lbl_mcountry.Text = objDonate.uiCountry;
            lbl_mprovstate.Text = objDonate.uiProvState;
            lbl_confemail.Text = objDonate.uiEmail;
            lbl_mfname.Text = objDonate.uifirstName;
            lbl_mlname.Text = objDonate.uilastName;
            lbl_mmemory.Text = objDonate.uiMemory;
            lbl_mcity.Text = objDonate.uiCity;
            lbl_mpostzip.Text = objDonate.uiPostZip;
            // hdiding user info panel, revealing credit info panel (make into a function)
            pnl_uinfo.Visible = false;
            pnl_credit.Visible = true;
            subCredCountryBind();
            subCredProvStateBind();
        }
            // this will be triggered when clicking on CreditNext button
    protected void subNextCredClick(object sender, EventArgs e)
        {
            // Taking the input from the credit panel and temporarily storing it in properties (make into a fucntion)
            
            objDonate.credName = txt_credname.Text.ToString();
            objDonate.credAddress = txt_credaddress.Text.ToString();
            objDonate.credCity = txt_credcity.Text.ToString();
            objDonate.credCountry = ddl_credcountry.SelectedItem.Text.ToString();
            objDonate.credProvState = ddl_credprovstate.SelectedItem.Text.ToString();
            //objDonate.credPostZip = txt_credpostzip.Text.ToString();
            objDonate.credNumber = txt_crednumber.Text.ToString();
            
            
            
            // hiding credit info panel, showing confirmation panel (make into a function)
            pnl_credit.Visible = false;
            pnl_confirm.Visible = true;

            // add code for taking information from both arrays to display on confirmation page
            lbl_billname.Text = objDonate.credName;
            lbl_confcnumber.Text = objDonate.credNumber;
            lbl_baddress.Text = objDonate.credAddress;
            lbl_bcity.Text = objDonate.credCity;
            lbl_bcountry.Text = objDonate.credCountry;
            lbl_bprovstate.Text = objDonate.credProvState;


            
    }

    // routine for confirmation view actions - submit and cancel
    protected void subConfPgAction(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Submit":
                // grabbing the values from the confirmation page labels to submit
                string _d_fname = lbl_mfname.Text;
                string _d_lname = lbl_mlname.Text;
                string _d_in_memory_of = lbl_mmemory.Text;
                string _d_amount = lbl_confamount.Text;
                string _d_email = lbl_confemail.Text;
                string _d_address_mailing = lbl_maddress.Text;
                string _d_city_mailing = lbl_mcity.Text;
                string _d_provstate_mailing = lbl_mprovstate.Text;
                string _d_postalzip_mailing = lbl_mpostzip.Text;
                string _d_name_billing = lbl_billname.Text;
                string _d_credit_number = lbl_confcnumber.Text;
                
                string _d_address_billing = lbl_baddress.Text;
                string _d_city_billing = lbl_bcity.Text;
                string _d_provstate_billing = lbl_bprovstate.Text;
                string _d_contry_billing = lbl_bcountry.Text;



                _strMessage(objDonate.insertDonation(_d_fname, _d_lname, _d_in_memory_of, _d_amount, _d_email,
        _d_address_mailing, _d_city_mailing, _d_provstate_mailing, _d_postalzip_mailing,
        _d_name_billing, _d_credit_number, _d_address_billing, _d_city_billing,
        _d_provstate_billing, _d_contry_billing), "Insert");
                pnl_confirm.Visible = false;
                pnl_uinfo.Visible = true;
                break;

            case "Cancel":
                pnl_confirm.Visible = false;
                pnl_uinfo.Visible = true;
                break;
        }
    }

    

    // This routine will transfer info over from mailing address form to credit card billing form
    protected void subTransferInfo(object sender, EventArgs e)
    {
        
        // this should use some of the information from the user array and transfer it over to the credit info view
        txt_credname.Text = lbl_mfname.Text + " " + lbl_mlname.Text;
        txt_credaddress.Text = lbl_maddress.Text;
        txt_credcity.Text = lbl_mcity.Text;
        ddl_credcountry.SelectedItem.Text = lbl_mcountry.Text;
        ddl_credprovstate.SelectedItem.Text = lbl_mprovstate.Text;
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
        var countryChoice = ddl_country.SelectedItem.Text;
       
        if (countryChoice == "Canada" || countryChoice == "United States")
        {
            
            // Show provstate dropdown list - this should be by AJAX
            lbl_provstate.Visible = true;
            ddl_provstate.Visible = true;
            // call getAllStatesorProvinces
            
            // show label and text box for postal code/ZIP
            lbl_postzip.Visible = true;
            txt_postzip.Visible = true;

            // enable required field validation for postzip
            rfv_postzip.Enabled = true;
            
            if (countryChoice == "Canada")
            {
                // enable postal code regex validator control
                rev_postzipcdn.Enabled = true;
                rev_postzipus.Enabled = false;
            }
            else
            {
                // enable zip code regex validator control

                rev_postzipus.Enabled = true;
                rev_postzipcdn.Enabled = false;
            }

        }
        // might need an else here to do nothing to make this work, not sure
        
    }
    // when called, will bind the ddl for prov and state do the relevant objDonate method
    private void subProvStateBind()
    {
        ddl_provstate.DataSource = objDonate.getAllStatesOrProvinces();
        ddl_provstate.DataValueField = "id";
        ddl_provstate.DataTextField = "name";
        ddl_provstate.DataBind();
    }

    // when called, will bind the ddl for credit prov and state do the relevant objDonate method
    // fix this later so these two sub routines are just one, with a parameter passed.
    private void subCredProvStateBind()
    {
        ddl_credprovstate.DataSource = objDonate.getAllStatesOrProvinces();
        ddl_credprovstate.DataValueField = "id";
        ddl_credprovstate.DataTextField = "name";
        ddl_credprovstate.DataBind();
    }

    // this binds credit country to objDonate object
    // come back and optimize this later.
    private void subCredCountryBind()
    {
        ddl_credcountry.DataSource = objDonate.getAllCountries();
        ddl_credcountry.DataValueField = "country_id";
        ddl_credcountry.DataTextField = "name_en";
        ddl_credcountry.DataBind();
    }

    // routine for submission message 
    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_execmess.Text = "Donation Record " + str + " was successfully executed.";
        else
            lbl_execmess.Text = "Sorry, the donation record " + str + " did not occur.";
    }
}