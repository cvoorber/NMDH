using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_jobpostsedit : System.Web.UI.Page
{
   
    LinqClass<ndmh_job> jobObj = new LinqClass<ndmh_job>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rebind();
        }
    }

    protected void subDelete(object sender, EventArgs e)
    {
        int jid = Int32.Parse((((Button)sender).CommandArgument));
        if (jobObj.Delete(m => m.j_id == jid))
            rebind();
        else
            lbl_result.Text = "Update was not successful.";
    }

    protected void subUpdate(object sender, EventArgs e)
    {
        int jid = Int32.Parse((((Button)sender).CommandArgument));

        ndmh_job newJobOjb = new ndmh_job()
        {
            j_id = jid,
            j_title = ((TextBox)dtl_update.Controls[0].Controls[1].FindControl("txt_titleU")).Text,
            j_description = ((TextBox)dtl_update.Controls[0].Controls[1].FindControl("txt_descU")).Text,
            j_requirements = ((TextBox)dtl_update.Controls[0].Controls[1].FindControl("txt_reqU")).Text,
            j_posted_date = DateTime.Parse(((TextBox)dtl_update.Controls[0].Controls[1].FindControl("txt_postU")).Text),
            j_category_id = Int32.Parse (((TextBox)dtl_update.Controls[0].Controls[1].FindControl("txt_jcatU")).Text),
            j_expires = DateTime.Parse(((TextBox)dtl_update.Controls[0].Controls[1].FindControl("txt_expiresU")).Text)
        };
        Label lbl = (Label)dtl_update.Controls[0].Controls[1].FindControl("lbl_result");

        if (jobObj.Update(newJobOjb))
            lbl.Text = "Update was successful.";
        else
            lbl.Text = "Update was not successful.";
        
    }

    protected void subInsert(object sender, EventArgs e)
    {
        ndmh_job newJobObj = new ndmh_job()
        {
            j_title = txt_titleU.Text,
            j_description = txt_descU.Text,
            j_requirements = txt_reqU.Text,
            j_posted_date = DateTime.Parse(txt_postU.Text),
            j_expires = DateTime.Parse(txt_expiresU.Text),
            j_category_id = Int32.Parse(txt_jcatU.Text)
        };
        
        if (jobObj.Insert(newJobObj))
            rebind();
        else
            lbl_result.Text = "Inserting was not successfull.";
         
    }

    protected void subEdit(object sender, EventArgs e)
    {
        int jid = Int32.Parse((((Button)sender).CommandArgument));
        dtl_update.DataSource = jobObj.getResultByColumn(m => m.j_id == jid);
        dtl_update.DataBind();
        showPanel(pnl_update);
    }

    protected void subCancel(object sender, EventArgs e)
    {
        rebind();
    }

    private void rebind()
    {
        dtl_jobs.DataSource = jobObj.getItems();
        dtl_jobs.DataBind();
        lbl_result.Text = "";
        showPanel(pnl_jobs);
    }

    private void showPanel(Panel p)
    {
        pnl_jobs.Visible = false;
        pnl_update.Visible = false;
        p.Visible = true;
    }
}