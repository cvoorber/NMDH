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
            LinqClass<ndmh_job_category> catObj = new LinqClass<ndmh_job_category>();
            LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();

            bl_cat.DataSource = catObj.getItems();
            bl_cat.DataTextField = "j_category_name";
            bl_cat.DataValueField = "j_category_id";
            bl_cat.DataBind();

            lbl_jCat.Text = "Allied Health Job Posts";
            int catVal = Int32.Parse(bl_cat.Items.FindByText("Allied Health").Value);
            rpt_joblist.DataSource = jobObj.getResultByColumn(m => m.j_category_id == catVal);
            rpt_joblist.DataBind();
            showPanel(pnl_jobs);
        }
    }

    protected void subShowPost(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        int jobID = Int32.Parse(btn.CommandArgument);
        rpt_post.DataSource = jobObj.getResultByColumn(m => m.j_id == jobID);
        rpt_post.DataBind();

        showPanel(pnl_viewpost);
    }

    protected void subGetJobs(object sender, BulletedListEventArgs b)
    {
        var item = bl_cat.Items[b.Index];
        int catVal = Int32.Parse(item.Value);
        lbl_jCat.Text = item.Text + " Job Posts";
        rpt_joblist.DataSource = jobObj.getResultByColumn(m => m.j_category_id == catVal); 
        rpt_joblist.DataBind();
        showPanel(pnl_jobs);
    }


    private void showPanel(Panel p)
    {
        pnl_viewpost.Visible = false;
        pnl_form.Visible = false;
        pnl_jobs.Visible = false;
        p.Visible = true;
    }

    protected void subShowApp(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        HiddenField hdf = new HiddenField();
        hdf.ID = "hdf_jobID";
        hdf.Value = btn.CommandArgument;

        pnl_form.Controls.Add(hdf);
        lbl_jID.Text = "Job ID: " + hdf.Value + "<br />";
        showPanel(pnl_form);
        
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
        if(!Regex.IsMatch(txt_altphone.Text,"^[2-9]\\d{2}$(\\s|-)?\\d{3}(\\s|-)?\\d{4}$"))
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
        jobObj.j_resume = lbl_status.Text;
        jobObj.j_id = Int32.Parse(lbl_jID.Text);

        if (!jobDB.Insert(jobObj))
            throw new Exception("Failed to apply for job.");


    }
}