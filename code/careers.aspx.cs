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

            foreach(ndmh_job_category x in catObj.getItems())
            {
                ListItem item = new ListItem
                {
                    Text = x.j_category_name,
                    Value = x.j_category_id + ""
                };
                bl_cat.Items.Add(item);
                bl_cat.Click += subGetJobs;
            }
           

            rpt_jobs.DataSource = jobObj.getItemByID(ddl_jobs.SelectedIndex + 1);
            rpt_jobs.DataBind();
        }
    }

    protected void subGetJobs(object sender, EventArgs e)
    {

    }

    protected void subSubmit(object sender, EventArgs e)
    {
        if (fu_main.HasFile)
        {
           
        }
    }

    protected void subChangeDesc(object sender, EventArgs e)
    {
        /*LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();
        rpt_jobs.DataSource = jobObj.getItemByID(ddl_jobs.SelectedIndex +1);
        rpt_jobs.DataBind();
        */
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