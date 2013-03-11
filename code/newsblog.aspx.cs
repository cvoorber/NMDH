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
        if (!Page.IsPostBack)
        {
            _subRebind();
        }
    }

    private void _subRebind()
    {
        grd_main.DataSource = objNews.getNews();
        grd_main.DataBind();
    }
}