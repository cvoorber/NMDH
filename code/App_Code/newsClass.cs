using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class newsClass
{
	public IQueryable<ndmh_event> getNews()
    {
        //create an instance of the LINQ object
        ndmhDCDataContext objNewsDC = new ndmhDCDataContext();
        //create an anonymous variable with its value being the instance of the LINQ object
        var allNews = objNewsDC.ndmh_events.Select(x => x);
        //return IQueryable<news> for data bound control to bind to 
        return allNews;
    }

    public IQueryable<ndmh_event> getNewsByID(int _id)
    {
        ndmhDCDataContext objNewsDC = new ndmhDCDataContext();
        var allNews = objNewsDC.ndmh_events.Where(x => x.n_id == _id).Select(x => x);
        return allNews;
    }

    public IQueryable<ndmh_event> getLatestNews()
    {
        ndmhDCDataContext objNewsDC = new ndmhDCDataContext();
        var allNews = objNewsDC.ndmh_events.OrderByDescending(x => x.n_id).Select(x => x).Take(2);
        return allNews;
    }

    public bool commitInsert(string _title, string _desc, string _image, DateTime _expires, DateTime _date, int _contact)
    {
        ndmhDCDataContext objNewsDC = new ndmhDCDataContext();
        //to ensure all data will be disposed when finished
        using (objNewsDC)
        {
            //create an instance of the table
            ndmh_event objFreshNews = new ndmh_event();
            //set table columns to new values being passed from *.aspx page
            objFreshNews.n_title = _title;
            objFreshNews.n_description = _desc;
            objFreshNews.n_image = _image;
            objFreshNews.n_expires = _expires;
            objFreshNews.n_event_date = _date;
            objFreshNews.n_contact_id = _contact;
            //insert command
            objNewsDC.ndmh_events.InsertOnSubmit(objFreshNews);
            //commit insert against DB
            objNewsDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _title, string _desc, string _image, int _contact)
    {
        ndmhDCDataContext objNewsDC = new ndmhDCDataContext();
        using (objNewsDC)
        {
            var objUpNews = objNewsDC.ndmh_events.Single(x => x.n_id == _id);
            objUpNews.n_title = _title;
            objUpNews.n_description = _desc;
            objUpNews.n_image = _image;
            objUpNews.n_contact_id = _contact;
            //commit update against DB
            objNewsDC.SubmitChanges();
            return true;
        }
    }
    public bool commitDelete(int _id)
    {
        ndmhDCDataContext objNewsDC = new ndmhDCDataContext();
        using (objNewsDC)
        {
            var objDelNews = objNewsDC.ndmh_events.Single(x => x.n_id == _id);
            //delete command
            objNewsDC.ndmh_events.DeleteOnSubmit(objDelNews);
            //commit delete against DB
            objNewsDC.SubmitChanges();
            return true;
        }
    }
}