using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for virtClass
/// </summary>
public class virtClass
{
    ndmhDCDataContext objVirtTour = new ndmhDCDataContext();

    // this method will get the list of all departments
    public IQueryable<ndmh_department_listing> getDepartments()
    {
        var allDepartments = objVirtTour.ndmh_department_listings.Select(x => x);
        return allDepartments;
    }

    // this method will get a department record, based on its dl_id
    public IQueryable<ndmh_department_listing> getDepartmentByID(int _id)
    {
        var chosenDeparment = objVirtTour.ndmh_department_listings.Where(x => x.dl_id == _id).Select(x => x);
        return chosenDeparment;
            
    }

    // this method will get list of departments based on which floor they are on (floor_no)

    public IQueryable<ndmh_department_listing> getDepartmentsByFloorNo(int _floor_no)
    {
        var chosenDepartments = objVirtTour.ndmh_department_listings.Where(x => x.dl_floor_no == _floor_no).Select(x => x);
        return chosenDepartments;
    }






}