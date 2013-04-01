using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newsblog : System.Web.UI.Page
{
    newsClass objNews = new newsClass();

    commentClass objComm = new commentClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }

    protected void subChange(object sender, EventArgs e)
    {
        int _id = int.Parse(ddl_main.SelectedValue.ToString());
        grd_main.DataSource = objNews.getNewsByID(_id);
        grd_main.DataBind();

        rpt_main.DataSource = objComm.getCommentsByID(_id);
        rpt_main.DataBind();
    }

    private void _subRebind()
    {
        txt_nameI.Text = string.Empty;
        txt_emailI.Text = string.Empty;
        txt_commentI.Text = string.Empty;

        ddl_main.DataSource = objNews.getNews();
        ddl_main.DataTextField = "n_title";
        ddl_main.DataValueField = "n_id";
        ddl_main.DataBind();

        int _id = int.Parse(ddl_main.SelectedValue.ToString());

        grd_main.DataSource = objNews.getNewsByID(_id);
        grd_main.DataBind();

        rpt_main.DataSource = objComm.getCommentsByID(_id);
        rpt_main.DataBind();
    }

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

    protected void subInsert(object sender, EventArgs e)
    {
        int artID = int.Parse(ddl_main.SelectedValue.ToString());
        _strMessage(objComm.commitInsert(txt_nameI.Text, txt_emailI.Text, txt_commentI.Text, artID), "insert");
        _subRebind();
    }

}