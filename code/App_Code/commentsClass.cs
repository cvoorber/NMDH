using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class commentClass
{
    //getting all comments from the database
    public IQueryable<ndmh_comment> getComments()
    {
        //create an instance of the LINQ object
        ndmhDCDataContext objCommDC = new ndmhDCDataContext();
        //create an anonymous variable with its value being the instance of the LINQ object
        var allComments = objCommDC.ndmh_comments.Select(x => x);
        //return IQueryable<comments> for data bound control to bind to 
        return allComments;
    }

    //getting comments based on specific id
    public IQueryable<ndmh_comment> getCommentsByID(int _id)
    {
        ndmhDCDataContext objCommDC = new ndmhDCDataContext();
        var allComments = objCommDC.ndmh_comments.Where(x => x.n_id == _id).Select(x => x);
        return allComments;
    }

    //inserting comments
    public bool commitInsert(string _name, string _email, string _text, int _nid)
    {
        ndmhDCDataContext objCommDC = new ndmhDCDataContext();
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

    //for updating comments
    public bool commitUpdate(int _id, string _name, string _email, string _text, int _id2)
    {
        ndmhDCDataContext objCommDC = new ndmhDCDataContext();
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

    //for deleting comments
    public bool commitDelete(int _id)
    {
        ndmhDCDataContext objCommDC = new ndmhDCDataContext();
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