using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    // instance of FaqsAdmin class
    faqsadminClass objFaqsAd = new faqsadminClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            subMaindBind();
            
        }
    }

    // event opens the edit panel
    protected void subEditView(object sender, CommandEventArgs e)
    {
        pnl_edit.Visible = true;
        pnl_faqadm.Visible = false;
        subEditViewBind(int.Parse(e.CommandArgument.ToString()));
        
    }

    // event opens the insert panel
    protected void subInsert(object sender, CommandEventArgs e)
    {
        pnl_insert.Visible = true;
        pnl_faqadm.Visible = false;
        txt_icontent.Text = "";
        txt_ititle.Text = "";
    }

    // brings about delete actions *** Remember to put in a pop-up
    protected void subDelete(object sender, CommandEventArgs e)
    {
        int _ndmh_faq_id = int.Parse(e.CommandArgument.ToString());
        _strMessage(objFaqsAd.deleteFaqs(_ndmh_faq_id), "Delete");
    }

    // onitem command passed here: two commands - SaveEdit and CancelEdit
    // save edit saves the changes made in the edit view, and cancel, cancels changes and returns to main view.
    // New key inserts a new keyword from the create new keyword textbox
    protected void subEdit(object sender, RepeaterCommandEventArgs e)
    {
        // hidden value that will be used in multiple cases below
        HiddenField hdfid = (HiddenField)e.Item.FindControl("hdf_eid");
        var faqidval = int.Parse(hdfid.Value.ToString());
        switch (e.CommandName)
        {
            case "SaveEdit":
        TextBox txt_edittitle = (TextBox)e.Item.FindControl("txt_etitle");
        TextBox txt_editcontent = (TextBox)e.Item.FindControl("txt_econtent");
        
        
        _strMessage(objFaqsAd.updateFaqs(faqidval, txt_edittitle.Text.ToString(), txt_editcontent.Text.ToString()), "Edit Save");
        break;
        
            case "CancelEdit":
        subMaindBind();
                break;

            case "NewKey":
        TextBox txtNewKey = (TextBox)e.Item.FindControl("txt_ekeysnew");
        string faqkeyw = txtNewKey.Text;
        _strMessage(objFaqsAd.insertFaqKeywordByFaqID(faqidval, faqkeyw), "Keyword Insert");        
        break;

    }
    }

    // these are actions that come from the insert panel - Create (insert) and Cancel
    protected void subInsPanel(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            // this is the command insert
            case "Create":
                string _ndmh_faq_title = txt_ititle.Text.ToString();
                string _ndmh_faq_content = txt_icontent.Text.ToString();
                _strMessage(objFaqsAd.insertFaqs(_ndmh_faq_title, _ndmh_faq_content), "Inserted");

                break;

            case "Cancel":
                subMaindBind();
                break;
        }
    }

    
    

    // this will do the edit and delete of keywords for the edit view
    protected void subEditKeys(object sender, RepeaterCommandEventArgs e)
    {
        // declare these values here so they can be used in both cases below if need be.
        TextBox txtEditKeys = (TextBox)e.Item.FindControl("txt_ekeys");
        HiddenField hdfEditKeys = (HiddenField)e.Item.FindControl("hdf_ekeys");
        int idval = int.Parse(hdfEditKeys.Value.ToString());
        // will have to create the child repeater like I did above then find the controls, and do the update function

        switch (e.CommandName)
        {

                // updates keyword in edit menu
            case "UpdateKeys":
                
                string keystring = txtEditKeys.Text;
                _strMessage(objFaqsAd.updateFaqKeyWordByID(idval, keystring), "Keyword Update");
                break;
                // deletes a keyword in edit menu
            case "DeleteKeys":
                _strMessage(objFaqsAd.deleteFaqKeyword(idval), "Keyword Delete");
                break;
        }
    }

    

  

   

    


    // routine will bind FAQ data to the repeater control

    private void subMaindBind()
    {
        pnl_faqadm.Visible = true;
        pnl_edit.Visible = false;
        pnl_insert.Visible = false;
        rpt_faqadm.DataSource = objFaqsAd.getAllFaqs();
        rpt_faqadm.DataBind();
    }

    // this is a routine that is binding the keylist "child" repeater on the ItemDataBound event of the parent repeater
    protected void keyListBind(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hdfChildID = (HiddenField)e.Item.FindControl("hdf_childid");
        
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater keylistrepeater = (Repeater)e.Item.FindControl("rpt_keylist");
            keylistrepeater.DataSource = objFaqsAd.getFaqKeysByID(int.Parse(hdfChildID.Value.ToString()));
            keylistrepeater.DataBind();
        }
    }

    // this will bind the keywords child repeater within the editview so that the list of keyword textboxes shows up
    protected void subEditKeysChildBind(object sender, RepeaterItemEventArgs e)
    {
        // will have to create a repeater using the method that I used above, and then do the databind to the
        // getFaqKeysByID method
        HiddenField hdfEditChildID = (HiddenField)e.Item.FindControl("hdf_eid");

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater keylistrepeater = (Repeater)e.Item.FindControl("rpt_edchildekeys");
            keylistrepeater.DataSource = objFaqsAd.getFaqKeysByID(int.Parse(hdfEditChildID.Value.ToString()));
            keylistrepeater.DataBind();
        }
    }


    // routine for pinding the edit repeater control

    private void subEditViewBind(int _ndmh_faq_id)
    {
        rpt_edit.DataSource = objFaqsAd.getFaqByID(_ndmh_faq_id);
        rpt_edit.DataBind();
    }
    
    

    // this is a method that will be run when an insert, update or delete is performed to guage success.

    private void _strMessage(bool flag, string str)
    {
        if (flag)
            lbl_execmess.Text = "FAQ article " + str + " was successfully executed.";
        else
            lbl_execmess.Text = "Sorry, the article " + str + " did not occur.";
    }

    

}