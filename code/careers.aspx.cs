using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

    }

    protected void subSubmit(object sender, EventArgs e)
    {

    }
}