using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newsblog : System.Web.UI.Page
{
    //instantiating the news class
    newsClass objNews = new newsClass();

    //instantiating the comment class
    commentClass objComm = new commentClass();

    //binding data on initial page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }

    //subroutine controlling which article and associated comments are shown on the page (user selected)
    protected void subChange(object sender, EventArgs e)
    {
        int _id = int.Parse(ddl_main.SelectedValue.ToString());
        grd_main.DataSource = objNews.getNewsByID(_id);
        grd_main.DataBind();

        rpt_main.DataSource = objComm.getCommentsByID(_id);
        rpt_main.DataBind();
    }

    //clearing comment inputs and binding all data on page load/hard refresh
    private void _subRebind()
    {
        txt_nameI.Text = string.Empty;
        txt_emailI.Text = string.Empty;
        txt_commentI.Text = string.Empty;

        ddl_main.DataSource = objNews.getNews();
        ddl_main.DataTextField = "n_title";
        ddl_main.DataValueField = "n_id";
        ddl_main.DataBind();

        //determining selected DDL value
        int _id = int.Parse(ddl_main.SelectedValue.ToString());

        //selecting approriate article
        grd_main.DataSource = objNews.getNewsByID(_id);
        grd_main.DataBind();

        //selecting appropriate comments related to particular article
        rpt_main.DataSource = objComm.getCommentsByID(_id);
        rpt_main.DataBind();
    }

    //success and failure messages
    private void _strMessage(bool flag, string str)
    {
        if (flag)
        {
            lbl_message.Text = "<br /><span style='color:green;'>Comment " + str + " was succesful.</span>";
        }
        else
        {
            lbl_message.Text = "<br /><span style='color:red;'>Sorry, unable to " + str + " comment.</span>";
        }
    }

    //comment insert subroutine
    protected void subInsert(object sender, EventArgs e)
    {
        int artID = int.Parse(ddl_main.SelectedValue.ToString());
        _strMessage(objComm.commitInsert(txt_nameI.Text, txt_emailI.Text, txt_commentI.Text, artID), "insert");
        _subRebind();
    }

}