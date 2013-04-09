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
    protected void subEditView(object sender, CommandEventArgs e)
    {
        pnl_main.Visible = false;
        pnl_edit.Visible = true;
        // put in binding to getDonationsByID ... passing in CommandArgument
        rpt_edit.DataSource = objDonAd.getDonByID(int.Parse(e.CommandArgument.ToString()));
        rpt_edit.DataBind();
    }

    // routine for insert view appearing
    protected void subInsertView(object sender, CommandEventArgs e)
    {
        pnl_main.Visible = false;
        pnl_insert.Visible = true;

    }

    // routine for when the button for deleting gets hit
    protected void subItemDelete(object sender, CommandEventArgs e)
    {
        int idval = int.Parse(e.CommandArgument.ToString());
        _strMessage(objDonAd.deleteDonation(idval), "Delete");

    }

    // actions from within insert view - Create and Cancel
    protected void subInsertAction(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Create":
                // set variables for each of the inputs in the insert view
                string _d_fname = txt_imfname.Text;
                string _d_lname = txt_imlname.Text;
                string _d_in_memory_of = txt_imemory.Text;
                decimal _d_amount = decimal.Parse(txt_idonamnt.Text.ToString());
                string _d_email = txt_iemail.Text;
                string _d_address_mailing = txt_imaddress.Text;
                string _d_city_mailing = txt_imcity.Text;
                string _d_provstate_mailing = txt_improvst.Text;
                string _d_postalzip_mailing = txt_impostzip.Text;
                string _d_name_billing = txt_ibname.Text;
                string _d_credit_number = txt_iccnumber.Text;
                string _d_credit_expiry = txt_iccedpiry.Text;
                string _d_address_billing = txt_ibaddress.Text;
                string _d_city_billing = txt_ibcity.Text;
                string _d_provstate_billing = txt_ibprovstate.Text;
                string _d_country_billing = txt_ibcountry.Text;
                



                _strMessage(objDonAd.insertDonation(_d_fname, _d_lname, _d_in_memory_of, _d_amount, _d_email,
        _d_address_mailing, _d_city_mailing, _d_provstate_mailing, _d_postalzip_mailing,
        _d_name_billing, _d_credit_number, _d_credit_expiry, _d_address_billing, _d_city_billing, 
        _d_provstate_billing, _d_country_billing), "Create New");
                break;

            case "Cancel":
                pnl_insert.Visible = false;
                pnl_main.Visible = true;
                break;
        }
    }

    // routine for command events from the edit repeater
    protected void subEditAction(object sender, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Update":
                // set objects to edit repeater controls

                TextBox txtEFname = (TextBox)e.Item.FindControl("txt_emfname");
                TextBox txtELname = (TextBox)e.Item.FindControl("txt_emlname");
                TextBox txtEMem = (TextBox)e.Item.FindControl("txt_ememory");
                TextBox txtEAmount = (TextBox)e.Item.FindControl("txt_edonamnt");
                TextBox txtEEmail = (TextBox)e.Item.FindControl("txt_eemail");
                TextBox txtEMaddress = (TextBox)e.Item.FindControl("txt_emaddress");
                TextBox txtEMcity = (TextBox)e.Item.FindControl("txt_emcity");
                TextBox txtEMProvst = (TextBox)e.Item.FindControl("txt_emprovst");
                TextBox txtEMPostzip = (TextBox)e.Item.FindControl("txt_empostzip");
                TextBox txtEBname = (TextBox)e.Item.FindControl("txt_ebname");
                TextBox txtECcnumber = (TextBox)e.Item.FindControl("txt_eccnumber");
                TextBox txtEExpiry = (TextBox)e.Item.FindControl("txt_eccedpiry");
                TextBox txtEBaddress = (TextBox)e.Item.FindControl("txt_ebaddress");
                TextBox txtEBcity = (TextBox)e.Item.FindControl("txt_ebcity");
                TextBox txtEBprovstate = (TextBox)e.Item.FindControl("txt_ebprovstate");
                TextBox txtEBcountry = (TextBox)e.Item.FindControl("txt_ebcountry");

                // set variables for each of the inputs in the edit view
                int _d_id = int.Parse(e.CommandArgument.ToString());
                string _d_fname = txtEFname.Text;
                string _d_lname = txtELname.Text;
                string _d_in_memory_of = txtEMem.Text;
                decimal _d_amount = decimal.Parse(txtEAmount.Text.ToString());
                string _d_email = txtEEmail.Text;
                string _d_address_mailing = txtEMaddress.Text;
                string _d_city_mailing = txtEMcity.Text;
                string _d_provstate_mailing = txtEMProvst.Text;
                string _d_postalzip_mailing = txtEMPostzip.Text;
                string _d_name_billing = txtEBname.Text;
                string _d_credit_number = txtECcnumber.Text;
                string _d_credit_expiry = txtEExpiry.Text;
                string _d_address_billing = txtEBaddress.Text;
                string _d_city_billing = txtEBcity.Text;
                string _d_provstate_billing = txtEBprovstate.Text;
                string _d_country_billing = txtEBcountry.Text;




                _strMessage(objDonAd.updateDons(_d_id, _d_fname, _d_lname, _d_in_memory_of, _d_amount, _d_email,
        _d_address_mailing, _d_city_mailing, _d_provstate_mailing, _d_postalzip_mailing,
        _d_name_billing, _d_credit_number, _d_credit_expiry, _d_address_billing, _d_city_billing,
        _d_provstate_billing, _d_country_billing), "Update");
                pnl_edit.Visible = false;
                pnl_main.Visible = true;
                break;

            case "Cancel":
                pnl_edit.Visible = false;
                pnl_main.Visible = true;
                break;
        }
    }

    
    // binds donations data to main listview control
    private void bindAllDonations()
    {
        lsv_main.DataSource = objDonAd.getAllDonRecords();
        lsv_main.DataBind();
    }

    // this is a method that will be run when an insert, update or delete is performed to guage success.

    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_execmess.Text = "Donation Record " + str + " was successfully executed.";
        else
            lbl_execmess.Text = "Sorry, the donation record " + str + " did not occur.";
    }

}