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
        //add additional attributes to the calendar
        cld_main.Caption = "Staff Room Events";
        cld_main.FirstDayOfWeek = FirstDayOfWeek.Sunday;
        cld_main.NextPrevFormat = NextPrevFormat.ShortMonth;
        cld_main.TitleFormat = TitleFormat.Month;
        cld_main.ShowGridLines = true;
        cld_main.OtherMonthDayStyle.BackColor = System.Drawing.Color.AliceBlue;
        cld_main.SelectedDayStyle.CssClass = "selectedday";
        cld_main.SelectedDayStyle.ForeColor = System.Drawing.Color.Black;

        //set the default day selected to today
        if (!Page.IsPostBack)
        {
            cld_main.SelectedDate = DateTime.Now.Date;
        }
    }

    //when a day is selected, display the panel containing that day's events
    protected void cld_main_SelectionChanged(object sender, EventArgs e)
    {
        //make the paneland its background panel visible
        pnl_day.Visible = true;
        pnl_dayitems.Visible = true;

        //create a new instance of staffroomClass
        staffroomClass calDay = new staffroomClass();

        //create two DateTime objects that represent the datetime range for events to display
        DateTime day = DateTime.Parse(cld_main.SelectedDate.ToShortDateString());
        DateTime nextday = DateTime.Parse(cld_main.SelectedDate.AddDays(1).ToShortDateString());

        //bind the control
        dtv_events.DataSource = calDay.getEventsbyDay(day, nextday);
        dtv_events.DataBind();
    }

    //hide the panel displaying the day's events
    protected void hideDay(object sender, EventArgs e)
    {
        pnl_day.Visible = false;
        pnl_dayitems.Visible = false;
    }

    //when each day is rendered, load any applicable events
    protected void subRender(object sender, DayRenderEventArgs e)
    {
        //create a new instance of the class
        staffroomClass objBook = new staffroomClass();

        //loop through each event
        foreach (var day in objBook.getCalendar())
        {
            //if the date of the event matches the day currently being rendered
            if (day.rb_start.Date.ToShortDateString() == e.Day.Date.ToShortDateString())
            {
                //create a new label and set its attributes to match the current event
                Label label1 = new Label();
                label1.Text = day.rb_title.ToString() + "<br />";
                label1.Text += day.rb_start.ToShortTimeString() + "-" + day.rb_end.ToShortTimeString();
                label1.Font.Size = new FontUnit(FontSize.Smaller);
                label1.CssClass = "calendarItem";

                //add this control to the day
                e.Cell.Controls.Add(label1);
            }
        }
    }

    protected void subSubmit(object sender, EventArgs e)
    {
        //refresh the page
        this.Page.Response.Redirect(this.Page.Request.RawUrl);
    }

    protected void pnlShow(object sender, EventArgs e)
    {
        //show or hide the custom control based on whether it is currently visible
        //also change the text on the button to match its function
        if (pnl_new.Visible == false)
        {
            pnl_new.Visible = true;
            btn_new.Text = "Cancel";
        }
        else
        {
            pnl_new.Visible = false;
            btn_new.Text = "New Event";
        }
    }
}
