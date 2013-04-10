using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class calendar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _rebind();
        }
    }

    protected void subAction(object sender, DataGridCommandEventArgs  e)
    {
        staffroomClass objCal = new staffroomClass();
        switch (e.CommandName)
        {
            case "subEdit":
                dtv_events.DataSource = objCal.getEventbyID(int.Parse(e.CommandArgument.ToString()));
                dtv_events.DataBind();
                pnl_day.Visible = true;
                pnl_dayitems.Visible = true;
                break;
        }
    }

    protected void hideDay(object sender, EventArgs e)
    {
        pnl_day.Visible = false;
        pnl_dayitems.Visible = false;
    }

    protected void subRepAction(object sender, RepeaterCommandEventArgs e)
    {
        staffroomClass objEvent = new staffroomClass();
        objEvent.deletePage(int.Parse(e.CommandArgument.ToString()));
        pnl_day.Visible = false;
        pnl_dayitems.Visible = false;
        _rebind();
    }

    public List<ListItem> getsort()
    {
        List<ListItem> sort = new List<ListItem>();
        sort.Add(new ListItem("Show All"));
        sort.Add(new ListItem("Past"));
        sort.Add(new ListItem("Future"));
        return sort;
    }

    protected void subSubmit(object sender, EventArgs e)
    {
        _rebind();
    }

    protected void _rebind()
    {
        staffroomClass objCal = new staffroomClass();
        dg_all.DataSource = objCal.getCalendar();
        dg_all.DataBind();

        ddl_view.DataSource = getsort();
        ddl_view.DataBind();
    }

    protected void subSort(object sender, EventArgs e)
    {
        staffroomClass objCal = new staffroomClass();
        string sort = ddl_view.SelectedValue.ToString();

        switch (sort)
        {
            case "Show All":
                _rebind();
                break;
            case "Past":
                dg_all.DataSource = objCal.getPast();
                dg_all.DataBind();
                break;
            case "Future":
                dg_all.DataSource = objCal.getFuture();
                dg_all.DataBind();
                break;
        }
    }
}
