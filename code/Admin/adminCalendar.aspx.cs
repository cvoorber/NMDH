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
        //bind the calendar on initial load
        if (!Page.IsPostBack)
        {
            _rebind();
        }
    }

    protected void subView(object sender, DataGridCommandEventArgs  e)
    {
        //create a new instance of the class
        staffroomClass objCal = new staffroomClass();

        //display the individual event selected, bound to the detailsview control
        dtv_events.DataSource = objCal.getEventbyID(int.Parse(e.CommandArgument.ToString()));
        dtv_events.DataBind();
        pnl_day.Visible = true;
        pnl_dayitems.Visible = true;
    }

    //hide the individual event
    protected void hideDay(object sender, EventArgs e)
    {
        pnl_day.Visible = false;
        pnl_dayitems.Visible = false;
    }

    //delete the event
    protected void subDelete(object sender, RepeaterCommandEventArgs e)
    {
        //create a new instance of the class
        staffroomClass objEvent = new staffroomClass();

        //send the current event id through to the delete method in the class
        objEvent.deletePage(int.Parse(e.CommandArgument.ToString()));

        //hide the panel
        pnl_day.Visible = false;
        pnl_dayitems.Visible = false;

        //rebind the datagrid
        _rebind();
    }

    //create a list to populate the dropdownlist
    public List<ListItem> getsort()
    {
        List<ListItem> sort = new List<ListItem>();
        sort.Add(new ListItem("Show All"));
        sort.Add(new ListItem("Past"));
        sort.Add(new ListItem("Future"));
        return sort;
    }

    //rebind the datagrid to show any new events added
    protected void subSubmit(object sender, EventArgs e)
    {
        _rebind();
    }

    //rebind the datagrid to the list of events obtained from the database
    protected void _rebind()
    {
        //bind the calendar
        staffroomClass objCal = new staffroomClass();
        dg_all.DataSource = objCal.getCalendar();
        dg_all.DataBind();

        //bind the dropdownlist to the list of display options
        ddl_view.DataSource = getsort();
        ddl_view.DataBind();
    }

    //select the display of bookings based on the sort option chosen in the dropdownlist
    protected void subSort(object sender, EventArgs e)
    {
        //create a new instance of the class
        staffroomClass objCal = new staffroomClass();

        //get the selected value from the drop down list
        string sort = ddl_view.SelectedValue.ToString();

        //do something based on what the selected value is
        switch (sort)
        {
            case "Show All":
                //just rebind the datagrid
                _rebind();
                break;
            case "Past":
                //bind the datagrid to the list of past events
                dg_all.DataSource = objCal.getPast();
                dg_all.DataBind();
                break;
            case "Future":
                //bind the datagrid to the list of future events
                dg_all.DataSource = objCal.getFuture();
                dg_all.DataBind();
                break;
        }
    }
}
