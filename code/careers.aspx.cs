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
        if (!Page.IsPostBack)
        {
            LinqClass<ndmh_job_category> catObj = new LinqClass<ndmh_job_category>();
            LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();

            bl_cat.DataSource = catObj.getItems();
            bl_cat.DataTextField = "j_category_name";
            bl_cat.DataValueField = "j_category_id";
            bl_cat.DataBind();

            
            bl_jobs.DataSource = jobObj.getItem(m => m.j_category_id == 1);
            bl_jobs.DataTextField = "j_title";
            bl_jobs.DataValueField = "j_id";
            bl_jobs.DataBind();

            showPanel(pnl_jobs);

        }
    }

    protected void subGetJobs(object sender, EventArgs e)
    {
    }

    protected void subSubmit(object sender, EventArgs e)
    {
       
    }


    private void showPanel(Panel p)
    {
        pnl_description.Visible = false;
        pnl_form.Visible = false;
        pnl_jobs.Visible = false;
        p.Visible = true;
    }
}