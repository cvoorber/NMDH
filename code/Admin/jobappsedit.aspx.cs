using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO; //namespace to perform file operation

using System.Text.RegularExpressions; //namespace to use regular expressions

public partial class Admin_jobappsedit : System.Web.UI.Page
{
    LinqClass<ndmh_job_application> appsObj = new LinqClass<ndmh_job_application>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _rebind();
        }
    }

    //delete function
    //deletes data as well as the actual physical resume file
    protected void subDelete(object sender, EventArgs e)
    {
        int appID = Int32.Parse((((Button)sender).CommandArgument));
        ndmh_job_application currJobApp = (ndmh_job_application)appsObj.getResultByColumn(m=>m.j_application_id == appID).Single();
        File.Delete(Server.MapPath("~/resumes/" + currJobApp.j_resume));
        if (appsObj.Delete(m => m.j_application_id == appID))
        {
            _rebind();
        }
        else
            lbl_result.Text = "Update was not successful.";
    } 


    //update command that handles datalist itemcommand
    protected void subUpdate(object sender, DataListCommandEventArgs e)
    {
        //if cancel button, go back to main page
        if (e.CommandName == "cancel")
        {
            _rebind();
        }
        else
        {
            //else update record via textbox input and hidden field with j_application_id
            int appID = Int32.Parse(((HiddenField)e.Item.FindControl("hdf_jappID")).Value);

            ndmh_job_application newJobApp = new ndmh_job_application()
            {
                j_application_id = appID,
                j_first_name = ((TextBox)e.Item.FindControl("txt_fnameU")).Text,
                j_last_name = ((TextBox)e.Item.FindControl("txt_lnameU")).Text,
                j_address = ((TextBox)e.Item.FindControl("txt_addressU")).Text,
                j_city = ((TextBox)e.Item.FindControl("txt_cityU")).Text,
                j_province = ((TextBox)e.Item.FindControl("txt_provinceU")).Text,
                j_phone = ((TextBox)e.Item.FindControl("txt_phoneU")).Text,
                j_postal = ((TextBox)e.Item.FindControl("txt_postalU")).Text,
                j_alt_phone = ((TextBox)e.Item.FindControl("txt_altphoneU")).Text,
                j_email = ((TextBox)e.Item.FindControl("txt_emailU")).Text,
                j_was_employee = char.Parse(((DropDownList)e.Item.FindControl("ddl_employeeU")).SelectedValue),
                j_is_eligible = char.Parse(((DropDownList)e.Item.FindControl("ddl_eligibleU")).SelectedValue),
                j_was_convicted = char.Parse(((DropDownList)e.Item.FindControl("ddl_convictU")).SelectedValue),
                j_of_age = char.Parse(((DropDownList)e.Item.FindControl("ddl_ageU")).SelectedValue),
                j_id = Int32.Parse(((TextBox)e.Item.FindControl("txt_jobIDU")).Text),
                j_resume = ((TextBox)e.Item.FindControl("txt_resumeU")).Text,
                j_date_applied = DateTime.Parse(((TextBox)e.Item.FindControl("txt_dateU")).Text)
            };

            if (appsObj.Update(newJobApp))
                lbl_result.Text = "Update was successful.";
            else
                lbl_result.Text = "Update was not successful.";
        }
    }

    //show updatepanel, datalist bound to that single item
    protected void subEdit(object sender, EventArgs e)
    {
        int appID = Int32.Parse((((Button)sender).CommandArgument));
       
        dtl_update.DataSource = appsObj.getResultByColumn(m => m.j_application_id == appID);
        dtl_update.DataBind();
        _showPanel(pnl_update);
        
    }

    //rebinds the job application list
    private void _rebind()
    {
        LinqClass<ndmh_job_application> appsOjb = new LinqClass<ndmh_job_application>();
        dtl_apps.DataSource = appsObj.getItems();
        dtl_apps.DataBind();
        lbl_result.Text = "";
        _showPanel(pnl_apps);
    }

    private void _showPanel(Panel p)
    {
        pnl_apps.Visible = false;
        pnl_update.Visible = false;
        p.Visible = true;
    }

    //custom validator handler that handles empty or non-empty phone numbers
    //for non-required alt phone number
    protected void subValidPhone(object sender, ServerValidateEventArgs e)
    {
        TextBox txt = (TextBox)this.Page.FindControl("txt_altphoneU");
        if (!Regex.IsMatch(txt.Text, "^[2-9]\\d{2}(\\s|-)?\\d{3}(\\s|-)?\\d{4}$"))
            e.IsValid = false;
    }
}