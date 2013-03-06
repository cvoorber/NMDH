﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class newsClass
{
	public IQueryable<ndmh_event> getNews()
    {
        //create an instance of the LINQ object
        news_eventDataContext objNewsDC = new news_eventDataContext();
        //create an anonymous variable with its value being the instance of the LINQ object
        var allNews = objNewsDC.ndmh_events.Select(x => x);
        //return IQueryable<news> for data bound control to bind to 
        return allNews;
    }

    public IQueryable<ndmh_event> getNewsByID(int _id)
    {
        news_eventDataContext objNewsDC = new news_eventDataContext();
        var allNews = objNewsDC.ndmh_events.Where(x => x.n_id == _id).Select(x => x);
        return allNews;
    }
    public bool commitInsert(int _id, string _title, string _desc, System.Data.Linq.Binary _image, DateTime _expires, DateTime _date, int _contact, string _link)
    {
        news_eventDataContext objNewsDC = new news_eventDataContext();
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
            objFreshNews.n_link = _link;
            //insert command
            objNewsDC.ndmh_events.InsertOnSubmit(objFreshNews);
            //commit insert against DB
            objNewsDC.SubmitChanges();
            return true;
        }
    }
    public bool commitUpdate(int _id, string _title, string _desc, System.Data.Linq.Binary _image, DateTime _expires, DateTime _date, int _contact, string _link)
    {
        news_eventDataContext objNewsDC = new news_eventDataContext();
        using (objNewsDC)
        {
            var objUpNews = objNewsDC.ndmh_events.Single(x => x.n_id == _id);
            objUpNews.n_title = _title;
            objUpNews.n_description = _desc;
            objUpNews.n_image = _image;
            objUpNews.n_expires = _expires;
            objUpNews.n_event_date = _date;
            objUpNews.n_contact_id = _contact;
            objUpNews.n_link = _link;
            //commit update against DB
            objNewsDC.SubmitChanges();
            return true;
        }
    }
    public bool commitDelete(int _id)
    {
        news_eventDataContext objNewsDC = new news_eventDataContext();
        using (objNewsDC)
        {
            var objDelNews = objNewsDC.ndmh_events.Single(x => x.n_contact_id == _id);
            //delete command
            objNewsDC.ndmh_events.DeleteOnSubmit(objDelNews);
            //commit delete against DB
            objNewsDC.SubmitChanges();
            return true;
        }
    }
}