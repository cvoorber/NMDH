using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

public class navClass
{
    //this method returns all the pages from the general pages table
    public IQueryable<ndmh_general_page> getAll()
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        var allPage = objPageDC.ndmh_general_pages.Select(x => x);
        return allPage;
    }

    //this method returns one page based on the name(title) provided
    public IQueryable<ndmh_general_page> getPageByName(string _name)
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        var allPage = objPageDC.ndmh_general_pages.Where(x => x.gp_title == _name).Select(x => x);
        return allPage;
    }

    //return the record matching the provided id
    public IQueryable<ndmh_general_page> getPageByID(int _id)
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        var allPage = objPageDC.ndmh_general_pages.Where(x => x.gp_id == _id).Select(x => x);
        return allPage;
    }

    //add a new page to the database
    public bool newPage(string _title, string _type, string _content, string _image, bool _publish)
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        //to ensure all data will be disposed when finished
        using (objPageDC)
        {
            //create an instance of the table
            ndmh_general_page objNewPage = new ndmh_general_page();
            //set table columns to new values being passed from *.aspx page
            objNewPage.gp_title = _title;
            objNewPage.gp_section = _type;
            objNewPage.gp_content = _content;
            objNewPage.gp_image = _image;
            objNewPage.gp_active = _publish;
            //insert command
            objPageDC.ndmh_general_pages.InsertOnSubmit(objNewPage);
            //commit insert against DB
            objPageDC.SubmitChanges();
            return true;
        }
    }

    //update an existing record
    public bool updatePage(int _id, string _title, string _type, string _content, bool _publish)
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        //to ensure all data will be disposed when finished
        using (objPageDC)
        {
            //create an instance of the table
            ndmh_general_page objNewPage = new ndmh_general_page();
            //set table columns to new values being passed from *.aspx page
            var objEdit = objPageDC.ndmh_general_pages.Single(x => x.gp_id == _id);
            objEdit.gp_title = _title;
            objEdit.gp_section = _type;
            objEdit.gp_content = _content;
            objEdit.gp_image = "image";
            objEdit.gp_active = _publish;
            objPageDC.SubmitChanges();
            return true;
        }
    }

    //delete a record based on the id provided
    public bool deletePage(int _id)
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        //to ensure all data will be disposed when finished
        using (objPageDC)
        {
            var objDelPage = objPageDC.ndmh_general_pages.Single(x => x.gp_id == _id);
            //delete command
            objPageDC.ndmh_general_pages.DeleteOnSubmit(objDelPage);
            //commit delete against DB
            objPageDC.SubmitChanges();
            return true;
        }
    }
}