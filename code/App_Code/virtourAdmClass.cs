using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for virtourAdmClass
/// </summary>
public class virtourAdmClass
{
    // instance of website data context
    ndmhDCDataContext objDC = new ndmhDCDataContext();

	
    // this method will get the list of all departments
    public IQueryable<ndmh_department_listing> getDepartments()
    {
        var allDepartments = objDC.ndmh_department_listings.Select(x => x);
        return allDepartments;
    }

    // this method will get a department record, based on its dl_id
    public IQueryable<ndmh_department_listing> getDepartmentByID(int _id)
    {
        var chosenDeparment = objDC.ndmh_department_listings.Where(x => x.dl_id == _id).Select(x => x);
        return chosenDeparment;

    }

    // method to update department record
    public bool updateDepts(int _dl_id, string _dl_name, int _dl_extention, 
        string _dl_days_open, int _dl_floor_no, int _dl_room_no, string _dl_description, string _dl_img_url, string _dl_img_alt,
        string _dl_img_desc, int _dl_img_width, int _dl_img_height)
    {
        using (objDC)
        {
            var objUpDept = objDC.ndmh_department_listings.Single(x => x.dl_id == _dl_id);
            
            objUpDept.dl_name = _dl_name;
            objUpDept.dl_extention = _dl_extention;
            objUpDept.dl_days_open = _dl_days_open;
            objUpDept.dl_floor_no = _dl_floor_no;
            objUpDept.dl_room_no = _dl_room_no;
            objUpDept.dl_description = _dl_description;
            objUpDept.dl_img_url = _dl_img_url;
            objUpDept.dl_img_alt = _dl_img_alt;
            objUpDept.dl_img_desc = _dl_img_desc;
            objUpDept.dl_img_width = _dl_img_width;
            objUpDept.dl_img_height = _dl_img_height;
            


            // commit against db
            objDC.SubmitChanges();
            return true;
        }
    }

    // method to insert new department record
   
    public bool insertDepartment(string _dl_name, int _dl_extention,
        string _dl_days_open, int _dl_floor_no, int _dl_room_no, string _dl_description, string _dl_img_url, string _dl_img_alt,
        string _dl_img_desc, int _dl_img_width, int _dl_img_height)
    {
        using (objDC)
        {
            // create an instance of a table
            ndmh_department_listing objNewDep = new ndmh_department_listing();
            objNewDep.dl_name = _dl_name;
            objNewDep.dl_extention = _dl_extention;
            objNewDep.dl_days_open = _dl_days_open;
            objNewDep.dl_floor_no = _dl_floor_no;
            objNewDep.dl_room_no = _dl_room_no;
            objNewDep.dl_description = _dl_description;
            objNewDep.dl_img_url = _dl_img_url;
            objNewDep.dl_img_alt = _dl_img_alt;
            objNewDep.dl_img_desc = _dl_img_desc;
            objNewDep.dl_img_width = _dl_img_width;
            objNewDep.dl_img_height = _dl_img_height;
            // insert command
            objDC.ndmh_department_listings.InsertOnSubmit(objNewDep);
            // commit insert against db
            objDC.SubmitChanges();
            return true;
        }
    }

   // method to delete a department record
    public bool deleteDepartment(int _dl_id)
    {
        using (objDC)
        {
            var objDelDept = objDC.ndmh_department_listings.Single(x => x.dl_id == _dl_id);
            // delete command
            objDC.ndmh_department_listings.DeleteOnSubmit(objDelDept);
            // commit delte against db
            objDC.SubmitChanges();
            return true;
        }
    }





}