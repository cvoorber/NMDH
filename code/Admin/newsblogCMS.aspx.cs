using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_newsblogCMS : System.Web.UI.Page
{
    newsClass objLinq = new newsClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }

    private void _subRebind()
    {
        txt_titleI.Text = string.Empty;
        txt_descI.Text = string.Empty;
        txt_imageI.Text = string.Empty;
        txt_expiryI.Text = string.Empty;
        txt_eventdateI.Text = string.Empty;
        txt_contactidI.Text = string.Empty;
        txt_linkI.Text = string.Empty;

        ddl_main.DataSource = objLinq.getNews();
        ddl_main.DataTextField = "n_title";
        ddl_main.DataValueField = "n_id";
        ddl_main.DataBind();

        int _id = int.Parse(ddl_main.SelectedValue.ToString());
        lv_main.DataSource = objLinq.getNewsByID(_id);
        lv_main.DataBind();
    }

    protected void subChange(object sender, EventArgs e)
    {
        int _id = int.Parse(ddl_main.SelectedValue.ToString());
        lv_main.DataSource = objLinq.getNewsByID(_id);
        lv_main.DataBind();
    }

    private void _strMessage(bool flag, string str)
    {
        if (flag)
        {
            lbl_message.Text = "<span style='color:green;'>News " + str + " was succesful.</span>";
        }
        else
        {
            lbl_message.Text = "<span style='color:red;'>Sorry, unable to " + str + " news.</span>";
        }
    }

    protected void subInsert(object sender, EventArgs e)
    {
        _strMessage(objLinq.commitInsert(txt_titleI.Text, txt_descI.Text, txt_imageI.Text, DateTime.Parse(txt_expiryI.Text), DateTime.Parse(txt_eventdateI.Text), int.Parse(txt_contactidI.Text.ToString()), txt_linkI.Text), "insert");
        _subRebind();
    }

    protected void subAdmin(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "subUpdate":
                TextBox txtTitle = (TextBox)e.Item.FindControl("txt_titleE");
                TextBox txtDesc = (TextBox)e.Item.FindControl("txt_descE");
                TextBox txtEventDate = (TextBox)e.Item.FindControl("txt_eventdateE");
                TextBox txtImage = (TextBox)e.Item.FindControl("txt_imageE");
                TextBox txtExpiry = (TextBox)e.Item.FindControl("txt_expiryE");
                TextBox txtContactID = (TextBox)e.Item.FindControl("txt_contactidE");
                TextBox txtLink = (TextBox)e.Item.FindControl("txt_linkE");
                HiddenField hdfID = (HiddenField)e.Item.FindControl("hdf_idE");
                int newsID = int.Parse(hdfID.Value.ToString());

                _strMessage(objLinq.commitUpdate(newsID, txtTitle.Text, txtDesc.Text, txtImage.Text, DateTime.Parse(txtExpiry.Text), DateTime.Parse(txtEventDate.Text), int.Parse(txtContactID.Text.ToString()), txtLink.Text), "update");
                _subRebind();
                break;
            case "subDelete":
                int _id = int.Parse(((HiddenField)e.Item.FindControl("hdf_idE")).Value);
                _strMessage(objLinq.commitDelete(_id), "delete");
                _subRebind();
                break;
        }
    }
}