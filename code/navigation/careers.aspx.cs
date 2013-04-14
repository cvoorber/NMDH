using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO; //to use file operation

using System.Text.RegularExpressions; //to use regular expressions

public partial class careers : System.Web.UI.Page
{
    LinqClass<ndmh_job_category> catObj = new LinqClass<ndmh_job_category>();
    LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _showPanel(pnl_careers);
            lbl_result.Text = "";

            //populates the category repeater with linq datasource
            
            rpt_careers.DataSource = catObj.getItems();
            rpt_careers.DataBind();

            //check querystring to see if catID is set
            if(Request.QueryString["catID"]!=null)
            {
                //if set populate the job postings repeater based on catID
                int catVal = Int32.Parse(Request.QueryString["catID"]);
                lbl_jCat.Text = (catObj.getResultByColumn(m => m.j_category_id == catVal).Single()).j_category_name.ToString() + " Job Posts";

                var catJobs = jobObj.getResultByColumn(m => m.j_category_id == catVal);

                rpt_joblist.DataSource = catJobs;
                rpt_joblist.DataBind();


                if (!catJobs.Any())
                    lbl_result.Text = "Sorry.  Currently there are not postings.";
                //show the job postings panel
                _showPanel(pnl_jobs);
            }

            //check querystring to see if jobID is set but apply is not
            //this refers to the condition where the user is looking at a job post
            if (Request.QueryString["jobID"] != null && Request.QueryString["apply"]==null)
            {
                _showPost(Int32.Parse(Request.QueryString["jobID"]));
            }

            //check querystring to see if jobID is set and apply=y
            //the user is accessing the job application based on jobID
            if (Request.QueryString["jobID"] != null && Request.QueryString["apply"]=="y")
            {
                _showApplication(Int32.Parse(Request.QueryString["jobID"]));
            }
        }
    }


    //show individual jobposts
    private void _showPost(int jobID)
    {
        rpt_post.DataSource = jobObj.getResultByColumn(m => m.j_id == jobID);
        rpt_post.DataBind();

        _showPanel(pnl_viewpost);
    }

    //switch between active panels
    private void _showPanel(Panel p)
    {
        pnl_viewpost.Visible = false;
        pnl_form.Visible = false;
        pnl_jobs.Visible = false;
        pnl_thankyou.Visible = false;
        pnl_careers.Visible = false;
        p.Visible = true;
    }

    //show the application form based on jobID
    private void _showApplication(int jobID)
    {
        //just sets the jobID on the application form form
        lbl_jID.Text = jobID.ToString();
        
        //make application form panel active
        _showPanel(pnl_form);
        
    }

    //button handler that posts to the page with jobID and apply=y to access applicaton form
    protected void subApply(object sender, EventArgs e)
    {
        //jobID was sent through commandargument of the button
        string url = "~/navigation/careers.aspx?apply=y&jobID=" + ((Button)sender).CommandArgument;
        Response.Redirect(url);
    }

    //custom validator for all dropdownlists
    protected void subDDLValidate(object sender, ServerValidateEventArgs e)
    {
        //checks to see if the first element (instructional) was selected
        if (ddl_prov.SelectedValue == "")
            e.IsValid = false;
    }

    //custom validation for optional alternate phone number
    //only kicks in when something is field is filled in
    protected void subValidPhone(object sender, ServerValidateEventArgs e)
    {
        if (txt_altphone.Text != "")
        {
            if (!Regex.IsMatch(txt_altphone.Text, "^[2-9]\\d{2}(\\s|-)?\\d{3}(\\s|-)?\\d{4}$"))
                e.IsValid = false;
            else
                e.IsValid = true;
        }
        else
        {
            e.IsValid = true;
        }
    }

    //handers form submission
    protected void subSubmit(object sender, EventArgs e)
    {
        LinqClass<ndmh_job_application> jobDB = new LinqClass<ndmh_job_application>();
        ndmh_job_application jobObj = new ndmh_job_application();

        //creates new job application database object
        jobObj.j_first_name = txt_fname.Text;
        jobObj.j_last_name = txt_lname.Text;
        jobObj.j_address = txt_address.Text;
        jobObj.j_city = txt_city.Text;
        jobObj.j_province = ddl_prov.SelectedValue;
        jobObj.j_postal = txt_pcode.Text;
        jobObj.j_date_applied = DateTime.Now.Date;

        //strips spaces and dashes in phone number before setting the object's property
        jobObj.j_phone = Regex.Replace(txt_phone.Text,"^(\\s|-)$","");
        
        //if null then set, else strip all spaces and dashes before setting the object's property
        jobObj.j_alt_phone = (txt_altphone.Text == "" ? txt_altphone.Text : Regex.Replace(txt_altphone.Text, "^(\\s|-)$", ""));
        
        jobObj.j_email = txt_email.Text;

        //set properties based on radiobutton selections
        jobObj.j_was_employee = char.Parse(rbl_cur_emp.SelectedValue);
        jobObj.j_is_eligible = char.Parse(rbl_elig.SelectedValue);
        jobObj.j_of_age = char.Parse(rbl_legal.SelectedValue);
        jobObj.j_was_convicted = char.Parse(rbl_convict.SelectedValue);
        
        //set jobID for the object to tell which job they're applying to
        jobObj.j_id = Int32.Parse(lbl_jID.Text);

        //rename the uploaded resume based on firstname, lastname and jobID
        string newfile = jobObj.j_first_name + "_" + jobObj.j_last_name + "_" + jobObj.j_id.ToString() + "_" + jobObj.j_phone 
                    + Path.GetExtension(fu_main.PostedFile.FileName).ToLower();
        jobObj.j_resume = newfile;

        fu_main.SaveAs(Path.Combine(Server.MapPath("~/resumes"),newfile));

        //insert the job application record object to the database
        if (!jobDB.Insert(jobObj))
            throw new Exception("Failed to apply for job.");
        else
        {
            //show thank you message upon success
            _showPanel(pnl_thankyou);
        }

    }

    //email function soon to come
    private bool _sendEmail(string name, string email)
    {
        return true;
    }
}