using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _default : System.Web.UI.Page
{
    //executing the databind function on original page load
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

    //binding data
    private void _BindData()
    {
        //wait time estimator bind
        dtl_main.DataSource = objWait.getWait();
        dtl_main.DataBind();
        //news blog estimator bind (2 latest rows only)
        rpt_news.DataSource = objNews.getLatestNews();
        rpt_news.DataBind();
    }

    //refreshes the page and with it, the wait time estimation
    protected void subUpdate(object sender, EventArgs e)
    {
        _BindData();
    }
}