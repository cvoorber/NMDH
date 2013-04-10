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
            _rebind();
        }
    }

    //get j_category_id that is passed to the button's commandargument
    //delete the object based on said id
    protected void subDelete(object sender, EventArgs e)
    {
        int jid = Int32.Parse((((Button)sender).CommandArgument));
        if (catObj.Delete(m => m.j_category_id == jid))
            _rebind();
        else
            lbl_result.Text = "Update was not successful.";
    }

    protected void subUpdate(object sender, DataListCommandEventArgs e)
    {
        //if the command that invoked the datalist command is cancel
        //rebind to go back to main page
        if (e.CommandName == "cancel")
            _rebind();
        else
        {
            //else it was the update command invoked
            //grab the j_category_id
            int jid = Int32.Parse(((HiddenField)e.Item.FindControl("hdf_jcatID")).Value);
            TextBox txtCatName = (TextBox)e.Item.FindControl("txt_update");

            ndmh_job_category newCatOjb = new ndmh_job_category();
            newCatOjb.j_category_id = jid;
            newCatOjb.j_category_name = txtCatName.Text;

            if (catObj.Update(newCatOjb))
                lbl_result.Text = "Update was successful.";
            else
                lbl_result.Text = "Update was not successful.";
        }

    }

    //insert new job category based on textboxes
    protected void subInsert(object sender, EventArgs e)
    {
        //create new object and pass it to linkclass's insert
        ndmh_job_category newCatObj = new ndmh_job_category();
        newCatObj.j_category_name = txt_catNameI.Text;
        if (catObj.Insert(newCatObj))
            _rebind();
        else
            lbl_result.Text = "Inserting was not successful.";
    }

    //when edit button click based on category item
    //update panel shows up and the datalist inside is bound to that specific item
    //for update
    protected void subEdit(object sender, EventArgs e)
    {
        int jid = Int32.Parse((((Button)sender).CommandArgument));
        dtl_update.DataSource = catObj.getResultByColumn(m => m.j_category_id == jid);
        dtl_update.DataBind();
        _showPanel(pnl_update);
    }

    private void _rebind()
    {
        LinqClass<ndmh_job_category> catObj = new LinqClass<ndmh_job_category>();
        dtl_cats.DataSource = catObj.getItems();
        dtl_cats.DataBind();
        lbl_result.Text = "";
        _showPanel(pnl_cats);
    }

    private void _showPanel(Panel p)
    {
        pnl_cats.Visible = false;
        pnl_update.Visible = false;
        p.Visible = true;
    }
}