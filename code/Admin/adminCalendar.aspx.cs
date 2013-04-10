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
        cld_main.Caption = "Staff Room Events";
        cld_main.FirstDayOfWeek = FirstDayOfWeek.Sunday;
        cld_main.NextPrevFormat = NextPrevFormat.ShortMonth;
        cld_main.TitleFormat = TitleFormat.Month;
        cld_main.ShowGridLines = true;
        cld_main.OtherMonthDayStyle.BackColor = System.Drawing.Color.AliceBlue;
        cld_main.SelectedDayStyle.CssClass = "selectedday";
        cld_main.SelectedDayStyle.ForeColor = System.Drawing.Color.Black;

        if (!Page.IsPostBack)
        {
            cld_main.SelectedDate = DateTime.Now.Date;
        }
    }

    protected void cld_main_SelectionChanged(object sender, EventArgs e)
    {
        pnl_day.Visible = true;
        pnl_dayitems.Visible = true;
        staffroomClass calDay = new staffroomClass();
        DateTime day = DateTime.Parse(cld_main.SelectedDate.ToShortDateString());
        DateTime nextday = DateTime.Parse(cld_main.SelectedDate.AddDays(1).ToShortDateString());
        dtv_events.DataSource = calDay.getEventsbyDay(day, nextday);
        dtv_events.DataBind();
    }

    protected void hideDay(object sender, EventArgs e)
    {
        pnl_day.Visible = false;
        pnl_dayitems.Visible = false;
    }

    protected void cld_main_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
    }

    protected void subRender(object sender, DayRenderEventArgs e)
    {
        staffroomClass objBook = new staffroomClass();
        foreach (var day in objBook.getCalendar())
        {
            if (day.rb_start.Date.ToShortDateString() == e.Day.Date.ToShortDateString())
            {
                Literal literal1 = new Literal();
                e.Cell.Controls.Add(literal1);
                Label label1 = new Label();
                label1.Text = day.rb_title.ToString() + "<br />";
                label1.Text += day.rb_start.ToShortTimeString() + "-" + day.rb_end.ToShortTimeString();
                label1.Font.Size = new FontUnit(FontSize.Smaller);
                label1.CssClass = "calendarItem";
                e.Cell.Controls.Add(label1);
            }
        }
    }

    protected void subSubmit(object sender, EventArgs e)
    {
        this.Page.Response.Redirect(this.Page.Request.RawUrl);
    }

    protected void pnlShow(object sender, EventArgs e)
    {
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
