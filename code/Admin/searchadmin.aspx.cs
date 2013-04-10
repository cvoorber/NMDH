using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    LinqClass<ndmh_keyword> kwObj = new LinqClass<ndmh_keyword>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _rebind();
        }
    }

    protected void subUpdate(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cancel")
        {
            _rebind();
        }
        else
        {
            int kID = Int32.Parse(((HiddenField)e.Item.FindControl("hdf_keywordID")).Value);

            ndmh_keyword newKeywords = new ndmh_keyword();
            newKeywords.keyword_id = kID;
            newKeywords.page_title = ((TextBox)e.Item.FindControl("txt_pagetitleU")).Text;
            newKeywords.keywords = ((TextBox)e.Item.FindControl("txt_keywordsU")).Text;
            newKeywords.url = ((TextBox)e.Item.FindControl("txt_pagetitleU")).Text;
            if (kwObj.Update(newKeywords))
                lbl_result.Text = "Update was successful.";
            else
                lbl_result.Text = "Update was not successful.";
        }
    }

    protected void subEdit(object sender, EventArgs e)
    {
        int kID = Int32.Parse(((Button)sender).CommandArgument);
        rpt_update.DataSource = kwObj.getResultByColumn(m => m.keyword_id == kID);
        rpt_update.DataBind();
        _showPanel(pnl_update);
    }

    protected void subInsert(object sender, EventArgs e)
    {
        ndmh_keyword kObj = new ndmh_keyword();
        kObj.page_title = txt_pagetitleI.Text;
        kObj.keywords = txt_keywordsI.Text;
        kObj.url = txt_urlI.Text;

        if (kwObj.Insert(kObj))
            _rebind();
        else
            lbl_result.Text = "Insert failed.";
    }

    protected void subDelete(object sender, EventArgs e)
    {
        int kID = Int32.Parse((((Button)sender).CommandArgument));
       
        if (kwObj.Delete(m => m.keyword_id == kID))
        {
            _rebind();
        }
        else
            lbl_result.Text = "Update was not successful.";
    }

    private void _showPanel(Panel pnl)
    {
        pnl_keys.Visible = false;
        pnl_insert.Visible = false;
        pnl_update.Visible = false;
        pnl.Visible = true;
    }

    private void _rebind()
    {
        rpt_keys.DataSource = kwObj.getItems();
        rpt_keys.DataBind();
        lbl_result.Text = "";
        _showPanel(pnl_keys);
    }
}