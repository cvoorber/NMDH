using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

/// <summary>
/// Summary description for staffRoom
/// </summary>
public class staffroomClass
{
    public IQueryable<ndmh_roomBooking> getCalendar()
    {
        ndmhDCDataContext objCalendarDC = new ndmhDCDataContext();
        var allDates = objCalendarDC.ndmh_roomBookings.Select(x => x).OrderBy(x => x.rb_start);
        return allDates;
    }

    public IQueryable<ndmh_roomBooking> getEventsbyDay(DateTime _day, DateTime _nextday)
    {
        ndmhDCDataContext objCalendarDC = new ndmhDCDataContext();
        DataLoadOptions options = new DataLoadOptions();
        options.LoadWith<ndmh_roomBooking>(x => x.ndmh_staff_listing);
        objCalendarDC.LoadOptions = options;
        var allDates = objCalendarDC.ndmh_roomBookings.Where(x => x.rb_start > _day && x.rb_start < _nextday).Select(x => x).OrderBy(x => x.rb_start);
        return allDates;
    }

    public IQueryable<ndmh_roomBooking> getEventbyID(int _id)
    {
        ndmhDCDataContext objCalendarDC = new ndmhDCDataContext();
        DataLoadOptions options = new DataLoadOptions();
        options.LoadWith<ndmh_roomBooking>(x => x.ndmh_staff_listing);
        objCalendarDC.LoadOptions = options;
        var allDates = objCalendarDC.ndmh_roomBookings.Where(x => x.rb_id == _id).Select(x => x);
        return allDates;
    }
}