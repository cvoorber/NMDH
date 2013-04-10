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
    //return all calendar events
    public IQueryable<ndmh_roomBooking> getCalendar()
    {
        ndmhDCDataContext objCalendarDC = new ndmhDCDataContext();
        var allDates = objCalendarDC.ndmh_roomBookings.Select(x => x).OrderBy(x => x.rb_start);
        return allDates;
    }

    //return all events that fit within a certain date range (one day and the day after to provide a timeslot of 24 hours that an event can fit into)
    public IQueryable<ndmh_roomBooking> getEventsbyDay(DateTime _day, DateTime _nextday)
    {
        ndmhDCDataContext objCalendarDC = new ndmhDCDataContext();
        DataLoadOptions options = new DataLoadOptions();

        //join with the staff listing table to get member name and contact info
        options.LoadWith<ndmh_roomBooking>(x => x.ndmh_staff_listing);
        objCalendarDC.LoadOptions = options;

        //execute the query and return the records
        var allDates = objCalendarDC.ndmh_roomBookings.Where(x => x.rb_start > _day && x.rb_start < _nextday).Select(x => x).OrderBy(x => x.rb_start);
        return allDates;
    }

    //return the event matching the id provided
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