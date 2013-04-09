using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for staffClass
/// </summary>
public class staffClass
{
		public IQueryable<ndmh_staff_listing> getList()
    {
        ndmhDCDataContext objStaffDC = new ndmhDCDataContext();
        var allStaff = objStaffDC.ndmh_staff_listings.Select(x => x);
        return allStaff;
    }
	
}