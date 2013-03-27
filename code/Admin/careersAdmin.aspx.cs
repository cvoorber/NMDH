using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_careersAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void subShowSection(object sender, EventArgs e)
    {
        string selected = mnu_career.SelectedItem.Value;
        switch (selected)
        {
            case "1":
                showPanel(pnl_cat);
                break;
            case "2":
                showPanel(pnl_posts);
                break;
            case "3":
                showPanel(pnl_apps);
                break;
        }
    }

    private void showPanel(Panel p)
    {
        pnl_apps.Visible = false;
        pnl_cat.Visible = false;
        pnl_posts.Visible = false;
        p.Visible = true;
    }
}

