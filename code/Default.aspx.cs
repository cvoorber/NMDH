using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _BindData();
        }
    }

    //instantiating the wait class
    waitClass objWait = new waitClass();

    //instantiating the news class
    newsClass objNews = new newsClass();

    private void _BindData()
    {
        dtl_main.DataSource = objWait.getWait();
        dtl_main.DataBind();
        rpt_news.DataSource = objNews.getLatestNews();
        rpt_news.DataBind();
    }

    protected void subUpdate(object sender, EventArgs e)
    {
        _BindData();
    }
}