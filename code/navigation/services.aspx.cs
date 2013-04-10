using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //set the masterpage pp_url variable to the end of the current page url
        Master.pp_Url = "~/" + HttpContext.Current.Request.Url.AbsolutePath.ToString().Substring(6);
    }
}