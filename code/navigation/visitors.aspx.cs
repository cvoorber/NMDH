using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class visitors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pp_Url = "~/" + HttpContext.Current.Request.Url.AbsolutePath.ToString().Substring(6);
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
    }

}