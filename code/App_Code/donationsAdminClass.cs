using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for donationsAdminClass
/// </summary>
public class donationsAdminClass
{
    ndmhDCDataContext objPageDC = new ndmhDCDataContext();

    // get all the records from the donations table
    public IQueryable<ndmh_donation> getAllDonRecords()
    {
        
        var allDonations = objPageDC.ndmh_donations.Select(x => x);
        return allDonations;
    }





}