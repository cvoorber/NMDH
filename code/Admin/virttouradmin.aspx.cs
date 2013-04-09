using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminVirtTour : System.Web.UI.Page
{
    // instance of virt tour admin class
    virtourAdmClass objvirtAd = new virtourAdmClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // bind all department records to the datalist control
            bindAllDepList();
        }
    }

    // routine for button click to reveal edit template
    protected void subEditView(object sender, CommandEventArgs e)
    {
        pnl_main.Visible = false;
        pnl_edit.Visible = true;
        int idval = int.Parse(e.CommandArgument.ToString());
        rpt_edit.DataSource = objvirtAd.getDepartmentByID(idval);
        rpt_edit.DataBind();
        
        
    }

    // routine that displays the insert view
    protected void subInsertView(object sender, CommandEventArgs e)
    {
        pnl_main.Visible = false;
        pnl_insert.Visible = true;
        
    }

    // routine for save and cancel actions from insert view
    protected void subInsertAction(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Save":
                // get values from the insert textboxes
                string txtname = txt_iname.Text;
                
                int txtexte = int.Parse(txt_iexten.Text.ToString());

                string txtdaopen = txt_idyopen.Text;
                int txtflnum = int.Parse(txt_iflnum.Text.ToString());
                int txtrmnum = int.Parse(txt_irmnum.Text.ToString());
                string txtdepdesc = txt_idepdesc.Text;
                string txtimgurl = txt_iimgurl.Text;
                string txtimgalt = txt_iimgalt.Text;
                string txtimgdesc = txt_iimgdesc.Text;
                int txtimgwid = int.Parse(txt_iimgwid.Text.ToString());
                int txtimgheig = int.Parse(txt_iimgheig.Text.ToString());

                _strMessage(objvirtAd.insertDepartment(txtname, txtexte, txtdaopen, txtflnum, txtrmnum,
                txtdepdesc, txtimgurl, txtimgalt, txtimgdesc, txtimgwid, txtimgheig), "Insert New");
                
                pnl_insert.Visible = false;
                pnl_main.Visible = true;
                
                break;

            case "Cancel":
                
                pnl_insert.Visible = false;
                pnl_main.Visible = true;
                
                break;
        }
    }
   

    // routine for delete button click
    protected void subDelete(object sender, CommandEventArgs e)
    {
        int idval = int.Parse(e.CommandArgument.ToString());
        _strMessage(objvirtAd.deleteDepartment(idval), "Delete");
        
    }

    // routine for events within edit view
    protected void subEditViewCommand(object sender, RepeaterCommandEventArgs e)
    {
         switch (e.CommandName)
        {

                
            case "Update":
                // create textbox objects to find controls within the formview
                TextBox txtName = (TextBox)e.Item.FindControl("txt_ename");
                TextBox txtID = (TextBox)e.Item.FindControl("txt_eid");
                TextBox txtExte = (TextBox)e.Item.FindControl("txt_eexten");

                TextBox txtDaOpen = (TextBox)e.Item.FindControl("txt_edyopen");
                TextBox txtFlNum = (TextBox)e.Item.FindControl("txt_eflnum");
                TextBox txtRmNum = (TextBox)e.Item.FindControl("txt_ermnum");
                TextBox txtDepDesc = (TextBox)e.Item.FindControl("txt_edepdesc");
                TextBox txtImgUrl = (TextBox)e.Item.FindControl("txt_eimgurl");
                TextBox txtImgAlt = (TextBox)e.Item.FindControl("txt_eimgalt");
                TextBox txtImgDesc = (TextBox)e.Item.FindControl("txt_eimgdesc");
                TextBox txtImgWid = (TextBox)e.Item.FindControl("txt_eimgwid");
                TextBox txtImgHeig = (TextBox)e.Item.FindControl("txt_eimgheig");

                // get values for each textbox object to do update from
                string txtname = txtName.Text;
                int txtid = int.Parse(txtID.Text.ToString());
                int txtexte = int.Parse(txtExte.Text.ToString());

                string txtdaopen = txtDaOpen.Text;
                int txtflnum = int.Parse(txtFlNum.Text.ToString());
                int txtrmnum = int.Parse(txtRmNum.Text.ToString());
                string txtdepdesc = txtDepDesc.Text;
                string txtimgurl = txtImgUrl.Text;
                string txtimgalt = txtImgAlt.Text;
                string txtimgdesc = txtImgDesc.Text;
                int txtimgwid = int.Parse(txtImgWid.Text.ToString());
                int txtimgheig = int.Parse(txtImgHeig.Text.ToString());
                _strMessage(objvirtAd.updateDepts(txtid, txtname, txtexte, txtdaopen, txtflnum, txtrmnum, 
                txtdepdesc, txtimgurl, txtimgalt, txtimgdesc, txtimgwid, txtimgheig), "Update");
                pnl_edit.Visible = false;
                pnl_main.Visible = true;
                
                break;

            case "Cancel":
                
                pnl_edit.Visible = false;
                pnl_main.Visible = true;
                
                break;
        }
    }

    







    // this routine binds the list of all departments to the the main datalist.
    private void bindAllDepList()
    {
        dtl_main.DataSource = objvirtAd.getDepartments();
        dtl_main.DataBind();
    }

    // this is a method that will be run when an insert, update or delete is performed to guage success.

    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_execmess.Text = "Department Record " + str + " was successfully executed.";
        else
            lbl_execmess.Text = "Sorry, the record " + str + " did not occur.";
    }

}