using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_careersAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void subShowSection(object sender, EventArgs e)
    {
        string selected = mnu_career.SelectedItem.Value;
        if (selected == "1")
        {
            LinqClass<ndmh_job_category> catObj = new LinqClass<ndmh_job_category>();
            dtl_cats.DataSource = catObj.getItems();
            dtl_cats.DataBind();
            showPanel(pnl_cats);
        }
        else if (selected == "2")
        {
            LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();
            dtl_jobs.DataSource = jobObj.getItems();
            dtl_jobs.DataBind();
            showPanel(pnl_jobs);
        }
        else
        {
            LinqClass<ndmh_job_application> appObj = new LinqClass<ndmh_job_application>();
            dtl_apps.DataSource = appObj.getItems();
            dtl_apps.DataBind();
            showPanel(pnl_apps);
        }
        
    }

    private void showPanel(Panel p)
    {
        pnl_apps.Visible = false;
        pnl_cats.Visible = false;
        pnl_jobs.Visible = false;
        p.Visible = true;
    }
}