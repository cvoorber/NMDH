using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_careersAdmin : System.Web.UI.Page
{
    LinqClass<ndmh_job_category> catObj = new LinqClass<ndmh_job_category>();

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
        if (catObj.Delete(m => m.j_category_id == jid))
            rebind();
        else
            lbl_result.Text = "Update was not successful.";
    }

    protected void subUpdate(object sender, EventArgs e)
    {
        int jid = Int32.Parse((((Button)sender).CommandArgument));
        TextBox txtCatName = (TextBox)dtl_update.Controls[0].Controls[1].FindControl("txt_update");

        ndmh_job_category newCatOjb = new ndmh_job_category();
        newCatOjb.j_category_id = jid;
        newCatOjb.j_category_name = txtCatName.Text;
        Label lbl = (Label)dtl_update.Controls[0].Controls[1].FindControl("lbl_result");

        if (catObj.Update(newCatOjb))
            lbl.Text = "Update was successful.";
        else
            lbl.Text = "Update was not successful.";
        
    }

    protected void subInsert(object sender, EventArgs e)
    {
        ndmh_job_category newCatObj = new ndmh_job_category();
        newCatObj.j_category_name = txt_catNameI.Text;
        if (catObj.Insert(newCatObj))
            rebind();
        else
            lbl_result.Text = "Inserting was not successfull.";
    }

    protected void subEdit(object sender, EventArgs e)
    {
        int jid = Int32.Parse((((Button)sender).CommandArgument));
        dtl_update.DataSource = catObj.getResultByColumn(m => m.j_category_id == jid);
        dtl_update.DataBind();
        showPanel(pnl_update);
    }

    protected void subCancel(object sender, EventArgs e)
    {
        rebind();
    }

    private void rebind()
    {
        LinqClass<ndmh_job_category> catObj = new LinqClass<ndmh_job_category>();
        dtl_cats.DataSource = catObj.getItems();
        dtl_cats.DataBind();
        lbl_result.Text = "";
        showPanel(pnl_cats);
    }

    private void showPanel(Panel p)
    {
        pnl_cats.Visible = false;
        pnl_update.Visible = false;
        p.Visible = true;
    }
}