using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _BindData();
        }
    }

    //instantiating the class
    waitClass objWait = new waitClass();

    private void _BindData()
    {
        dtl_main.DataSource = objWait.getWait();
        dtl_main.DataBind();
    }

    protected void subUpdate(object sender, EventArgs e)
    {
        _BindData();
    }
}