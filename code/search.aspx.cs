using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    LinqClass<ndmh_keyword> kwObj = new LinqClass<ndmh_keyword>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["query"] != null)
        {
            
        }
    }

    protected void subSearch(object sender, EventArgs e)
    {
        
    }

}