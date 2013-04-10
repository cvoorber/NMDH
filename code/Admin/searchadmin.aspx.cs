using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void subEdit(object sender, EventArgs e)
    {
    }

    protected void subDelete(object sender, EventArgs e)
    {
    }

    private void showPanel(Panel pnl)
    {
        pnl_edit.Visible = false;
        pnl_insert.Visible = false;
        pnl_update.Visible = false;
        pnl.Visible = true;
    }


}