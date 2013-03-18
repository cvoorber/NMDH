using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class commentClass
{
    public IQueryable<ndmh_comment> getComments()
    {
        //create an instance of the LINQ object
        news_eventDataContext objCommDC = new news_eventDataContext();
        //create an anonymous variable with its value being the instance of the LINQ object
        var allComments = objCommDC.ndmh_comments.Select(x => x);
        //return IQueryable<comments> for data bound control to bind to 
        return allComments;
    }

    public IQueryable<ndmh_comment> getCommentsByID(int _id)
    {
        news_eventDataContext objCommDC = new news_eventDataContext();
        var allComments = objCommDC.ndmh_comments.Where(x => x.n_id == _id).Select(x => x);
        return allComments;
    }

    public bool commitInsert(string _name, string _email, string _text, int _nid)
    {
        news_eventDataContext objCommDC = new news_eventDataContext();
        //to ensure all data will be disposed when finished
        using (objCommDC)
        {
            //create an instance of the table
            ndmh_comment objNewComment = new ndmh_comment();
            //set table columns to new values being passed from *.aspx page
            objNewComment.comm_name = _name;
            objNewComment.comm_email = _email;
            objNewComment.comm_text = _text;
            //Foreign key to identify associated article
            objNewComment.n_id = _nid;
            //insert command
            objCommDC.ndmh_comments.InsertOnSubmit(objNewComment);
            //commit insert against DB
            objCommDC.SubmitChanges();
            return true;
        }
    }

    public bool commitUpdate(int _id, string _name, string _email, string _text, int _id2)
    {
        news_eventDataContext objCommDC = new news_eventDataContext();
        using (objCommDC)
        {
            var objUpComm = objCommDC.ndmh_comments.Single(x => x.comm_id == _id);
            objUpComm.comm_name = _name;
            objUpComm.comm_email = _email;
            objUpComm.comm_text = _text;
            objUpComm.n_id = _id2;
            //commit update against DB
            objCommDC.SubmitChanges();
            return true;
        }
    }

    public bool commitDelete(int _id)
    {
        news_eventDataContext objCommDC = new news_eventDataContext();
        using (objCommDC)
        {
            var objDelComm = objCommDC.ndmh_comments.Single(x => x.comm_id == _id);
            //delete command
            objCommDC.ndmh_comments.DeleteOnSubmit(objDelComm);
            //commit delete against DB
            objCommDC.SubmitChanges();
            return true;
        }
    }
}