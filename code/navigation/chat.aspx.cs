using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    bool loggedIn = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<ChatStream> ass = Application["chatStreams"] as List<ChatStream>;
            subEnableInput(ass.Count>0);
        }
    }

    private void subEnableInput(bool yn)
    {
        btn_submit.Enabled = yn;
        txt_nickname.Enabled = yn;

        if (yn == true)
            lbl_status.Text = "Chat Status: Live";
        else
            lbl_status.Text = "Chat Status: Offline.";

        if (loggedIn)
            showPanel(pnl_chat);
        else
            showPanel(pnl_status);
    }

    protected void subSend(object sender, EventArgs e)
    {
    }

    protected void subSubmit(object sender, EventArgs e)
    {
        loggedIn = true;
    }

    protected void subRefresh(object sender, EventArgs e)
    {

    }

    private void showPanel(Panel p)
    {
        pnl_chat.Visible = false;
        pnl_status.Visible = false;
        p.Visible = true;
    }
}