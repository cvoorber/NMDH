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
            _rebind();
        }
    }

    //delete object based on hiddenfield's j_id
    protected void subDelete(object sender, EventArgs e)
    {
        int jid = Int32.Parse((((Button)sender).CommandArgument));
        if (jobObj.Delete(m => m.j_id == jid))
            _rebind();
        else
            lbl_result.Text = "Update was not successful.";
    }

    //datalistcommand handler
    protected void subUpdate(object sender, DataListCommandEventArgs e)
    {
        //cancel command invoked then just rebind to main page
        if (e.CommandName == "cancel")
            _rebind();
        else
        {
            //else update button was invoked
            int jid = Int32.Parse(((HiddenField)e.Item.FindControl("hdf_jid")).Value);

            //create new job post record to represent update of old record
            ndmh_job newJobOjb = new ndmh_job()
            {
                j_id = jid,
                j_title = ((TextBox)e.Item.FindControl("txt_titleU")).Text,
                j_description = ((TextBox)e.Item.FindControl("txt_descU")).Text,
                j_requirements = ((TextBox)e.Item.FindControl("txt_reqU")).Text,
                j_posted_date = DateTime.Parse(((TextBox)e.Item.FindControl("txt_postU")).Text),
                j_category_id = Int32.Parse(((TextBox)e.Item.FindControl("txt_jcatU")).Text),
                j_expires = DateTime.Parse(((TextBox)e.Item.FindControl("txt_expiresU")).Text)
            };

            //update record
            if (jobObj.Update(newJobOjb))
                lbl_result.Text = "Update was successful.";
            else
                lbl_result.Text = "Update was not successful.";
        }
    }

    //insert new job post based on textboxes
    protected void subInsert(object sender, EventArgs e)
    {
        ndmh_job newJobObj = new ndmh_job()
        {
            j_title = txt_titleI.Text,
            j_description = txt_descI.Text,
            j_requirements = txt_reqI.Text,
            j_posted_date = DateTime.Parse(txt_postI.Text),
            j_expires = DateTime.Parse(txt_expiresI.Text),
            j_category_id = Int32.Parse(txt_jcatI.Text)
        };
        
        if (jobObj.Insert(newJobObj))
            _rebind();
        else
            lbl_result.Text = "Inserting was not successfull.";
         
    }

    //show update panel and bind datalist to that one job post
    protected void subEdit(object sender, EventArgs e)
    {
        int jid = Int32.Parse((((Button)sender).CommandArgument));
        dtl_update.DataSource = jobObj.getResultByColumn(m => m.j_id == jid);
        dtl_update.DataBind();
        _showPanel(pnl_update);
    }

    private void _rebind()
    {
        dtl_jobs.DataSource = jobObj.getItems();
        dtl_jobs.DataBind();
        lbl_result.Text = "";
        _showPanel(pnl_jobs);
    }

    private void _showPanel(Panel p)
    {
        pnl_jobs.Visible = false;
        pnl_update.Visible = false;
        p.Visible = true;
    }
}