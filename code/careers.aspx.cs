using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using System.Text.RegularExpressions; //to use regular expressions

public partial class careers : System.Web.UI.Page
{
    LinqClass<ndmh_job_category> catObj = new LinqClass<ndmh_job_category>();
    LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rpt_careers.DataSource = catObj.getItems();
            rpt_careers.DataBind();

            if(Request.QueryString["catID"]!=null)
            {
                int catVal = Int32.Parse(Request.QueryString["catID"]);
                lbl_jCat.Text = (catObj.getResultByColumn(m => m.j_category_id == catVal).Single()).j_category_name.ToString() + " Job Posts";
                rpt_joblist.DataSource = jobObj.getResultByColumn(m => m.j_category_id == catVal);
                rpt_joblist.DataBind();
                showPanel(pnl_jobs);
            }

            if (Request.QueryString["jobID"] != null && Request.QueryString["apply"]==null)
            {
                showPost(Int32.Parse(Request.QueryString["jobID"]));
            }

            if (Request.QueryString["jobID"] != null && Request.QueryString["apply"]=="y")
            {
                showApplication(Int32.Parse(Request.QueryString["jobID"]));
            }
        }
    }


    //show individual jobposts
    private void showPost(int jobID)
    {
        rpt_post.DataSource = jobObj.getResultByColumn(m => m.j_id == jobID);
        rpt_post.DataBind();

        showPanel(pnl_viewpost);
    }


    public void showPanel(Panel p)
    {
        pnl_viewpost.Visible = false;
        pnl_form.Visible = false;
        pnl_jobs.Visible = false;
        pnl_thankyou.Visible = false;
        p.Visible = true;
    }

    private void showApplication(int jobID)
    {
        HiddenField hdf = new HiddenField();
        hdf.ID = "hdf_jobID";
        hdf.Value = jobID.ToString();

        pnl_form.Controls.Add(hdf);
        lbl_jID.Text = hdf.Value;
        showPanel(pnl_form);
        
    }

    protected void subApply(object sender, EventArgs e)
    {
        string url = "~/careers.aspx?apply=y&jobID=" + ((Button)sender).CommandArgument;
        Response.Redirect(url);
    }

    protected void subUpload(object sender, EventArgs e)
    {
        if (fu_main.HasFile)
        {
            string fExt = Path.GetExtension(fu_main.FileName).ToLower();
            if (fExt == ".doc" || fExt == ".docx" || fExt == ".pdf")
            {
                string filename = Path.Combine(Server.MapPath("~/resumes/"), fu_main.FileName);
                fu_main.SaveAs(filename);
                lbl_status.Text = fu_main.FileName;
            }
            else
                lbl_status.Text = "Requires filetype: doc/docx/pdf";
        }
        else
        {
            lbl_status.Text = "error.";
        }
    }

    protected void subDDLValidate(object sender, ServerValidateEventArgs e)
    {
        if (ddl_prov.SelectedValue == "")
            e.IsValid = false;
    }

    protected void subValidPhone(object sender, ServerValidateEventArgs e)
    {
        if(!Regex.IsMatch(txt_altphone.Text,"^[2-9]\\d{2}(\\s|-)?\\d{3}(\\s|-)?\\d{4}$"))
            e.IsValid = false;
    }

    protected void subSubmit(object sender, EventArgs e)
    {
        LinqClass<ndmh_job_application> jobDB = new LinqClass<ndmh_job_application>();
        ndmh_job_application jobObj = new ndmh_job_application();

        jobObj.j_first_name = txt_fname.Text;
        jobObj.j_last_name = txt_lname.Text;
        jobObj.j_address = txt_address.Text;
        jobObj.j_city = txt_city.Text;
        jobObj.j_province = ddl_prov.SelectedValue;
        jobObj.j_postal = txt_pcode.Text;
        jobObj.j_phone = Regex.Replace(txt_phone.Text,"^(\\s|-)$","");
        jobObj.j_alt_phone = (txt_altphone.Text == "" ? txt_altphone.Text : Regex.Replace(txt_altphone.Text, "^(\\s|-)$", ""));
        jobObj.j_email = txt_email.Text;
        jobObj.j_was_employee = char.Parse(rbl_cur_emp.SelectedValue);
        jobObj.j_is_eligible = char.Parse(rbl_elig.SelectedValue);
        jobObj.j_of_age = char.Parse(rbl_legal.SelectedValue);
        jobObj.j_was_convicted = char.Parse(rbl_convict.SelectedValue);
        
        jobObj.j_id = Int32.Parse(lbl_jID.Text);

        string newfile = jobObj.j_first_name + "_" + jobObj.j_last_name + "_" + jobObj.j_id.ToString() + Path.GetExtension(lbl_status.Text);
        jobObj.j_resume = newfile;

        //renaming file
        if (!File.Exists("~/resumes/" + newfile))
        {
            //must check if a file was chosen--will be done later
            File.Move(
                Path.Combine(Server.MapPath("~/resumes/"), lbl_status.Text),
                Path.Combine(Server.MapPath("~/resumes/"), newfile)
                );
        }

        if (!jobDB.Insert(jobObj))
            throw new Exception("Failed to apply for job.");
        else
        {
            showPanel(pnl_thankyou);
        }

    }

    private bool sendEmail(string name, string email)
    {
        return true;
    }
}