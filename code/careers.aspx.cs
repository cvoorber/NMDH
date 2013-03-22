using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class careers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            LinqClass<ndmh_job_category> catObj = new LinqClass<ndmh_job_category>();
            LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();

            bl_cat.DataSource = catObj.getItems();
            bl_cat.DataTextField = "j_category_name";
            bl_cat.DataValueField = "j_category_id";
            bl_cat.DataBind();


            lbl_category.Text = "Allied Health Postings";
            bl_jobs.DataSource = jobObj.getItem(m => m.j_category_id == 1);
            bl_jobs.DataTextField = "j_title";
            bl_jobs.DataValueField = "j_id";
            bl_jobs.DataBind();

            showPanel(pnl_jobs);

    }

    protected void subGetJobs(object sender, BulletedListEventArgs b)
    {
        LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();
        ListItem li = bl_cat.Items[b.Index];
        int catID = Int32.Parse(li.Value);
        lbl_category.Text = li.Text + " Postings";
        bl_jobs.DataSource = jobObj.getItem(m => m.j_category_id == catID);
        bl_jobs.DataTextField = "j_title";
        bl_jobs.DataValueField = "j_id";
        bl_jobs.DataBind();
    }

    protected void subGetPost(object sender, BulletedListEventArgs b)
    {
        LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();

        ListItem li = bl_jobs.Items[b.Index];
        int jID = Int32.Parse(li.Value);
        rpt_jobs.DataSource = jobObj.getItem(m => m.j_id == jID);
        bl_jobs.DataBind();

        showPanel(pnl_description);
    }

    protected void showApplication(object sender, EventArgs e)
    {
        lbl_jID.Text = "Job ID: " + ((HiddenField)(pnl_description.FindControl("hdf_jid"))).Value;
        showPanel(pnl_form);
    }

    private void showPanel(Panel p)
    {
        pnl_description.Visible = false;
        pnl_form.Visible = false;
        pnl_jobs.Visible = false;
        p.Visible = true;
    }

    protected void subSubmit(object sender, EventArgs e)
    {
    }
}