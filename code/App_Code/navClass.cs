﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

public class navClass
{
    public IQueryable<ndmh_general_page> getAll()
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        var allPage = objPageDC.ndmh_general_pages.Select(x => x);
        return allPage;
    }

    public IQueryable<ndmh_general_page> getPageByName(string _name)
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        var allPage = objPageDC.ndmh_general_pages.Where(x => x.gp_title == _name).Select(x => x);
        return allPage;
    }

    public IQueryable<ndmh_general_page> getPageByID(int _id)
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        var allPage = objPageDC.ndmh_general_pages.Where(x => x.gp_id == _id).Select(x => x);
        return allPage;
    }

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

    public bool updatePage(int _id, string _title, string _type, string _content, string _image, bool _publish)
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        //to ensure all data will be disposed when finished
        using (objPageDC)
        {
            //create an instance of the table
            ndmh_general_page objNewPage = new ndmh_general_page();
            //set table columns to new values being passed from *.aspx page
            var objEdit = objPageDC.ndmh_general_pages.Single(x => x.gp_id == _id);
            objNewPage.gp_title = _title;
            objNewPage.gp_section = _type;
            objNewPage.gp_content = _content;
            objNewPage.gp_image = _image;
            objNewPage.gp_active = _publish;
            objPageDC.SubmitChanges();
            return true;
        }
    }
}