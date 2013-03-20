using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();

            ddl_jobs.DataSource = jobObj.getItems();
            ddl_jobs.DataValueField = "j_id";
            ddl_jobs.DataTextField = "j_title";
            ddl_jobs.DataBind();
            //what the fudge 

            rpt_jobs.DataSource = jobObj.getItemByID(ddl_jobs.SelectedIndex + 1);
            rpt_jobs.DataBind();
        }
    }

    protected void subSubmit(object sender, EventArgs e)
    {
        if (fu_main.HasFile)
        {
           
        }
    }

    protected void subChangeDesc(object sender, EventArgs e)
    {
        LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();
        rpt_jobs.DataSource = jobObj.getItemByID(ddl_jobs.SelectedIndex +1);
        rpt_jobs.DataBind();

        pnl_form.Visible = false;
        pnl_description.Visible = true;
    }

    protected void showPanel()
    {
        pnl_description.Visible = true;
    }

    protected void subShow(object sender, EventArgs e)
    {
        pnl_form.Visible = true;
        pnl_description.Visible = false;
    }
}