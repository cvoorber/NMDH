using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newsblog : System.Web.UI.Page
{
    newsClass objNews = new newsClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        Master.pp_Url = "~/" + HttpContext.Current.Request.Url.AbsolutePath.ToString().Substring(6);
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
    }

    private void _subRebind()
    {
        grd_main.DataSource = objNews.getNews();
        grd_main.DataBind();
    }
}