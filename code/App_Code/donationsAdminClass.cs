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

    // method to get donation by ID
    public IQueryable<ndmh_donation> getDonByID(int _d_id)
    {
        var allDonID = objPageDC.ndmh_donations.Where(x => x.d_id == _d_id).Select(x => x);
        return allDonID;

    }

    // method to insert new donation record

    public bool insertDonation(string _d_fname, string _d_lname, string _d_in_memory_of, string _d_amount, string _d_email,
        string _d_address_mailing, string _d_city_mailing, string _d_provstate_mailing, string _d_postalzip_mailing,
        string _d_name_billing, string _d_credit_number, string _d_credit_expiry, string _d_address_billing, string _d_city_billing,
        string _d_provstate_billing, string _d_country_billing)
    {
        using (objPageDC)
        {
            // create an instance of a table
            ndmh_donation objNewDon = new ndmh_donation();
            objNewDon.d_fname = _d_fname;
            objNewDon.d_lname = _d_lname;
            objNewDon.d_in_memory_of = _d_in_memory_of;
            objNewDon.d_amount = _d_amount;
            objNewDon.d_email = _d_email;
            objNewDon.d_address_mailing = _d_address_mailing;
            objNewDon.d_city_mailing = _d_city_mailing;
            objNewDon.d_provstate_mailing = _d_provstate_mailing;
            objNewDon.d_postzip_mailing = _d_postalzip_mailing;
            objNewDon.d_name_billing = _d_name_billing;
            objNewDon.d_credit_number = _d_credit_number;
            objNewDon.d_credit_expiry = _d_credit_expiry;
            objNewDon.d_address_billing = _d_address_billing;
            objNewDon.d_city_billing = _d_city_billing;
            objNewDon.d_provstate_billing = _d_provstate_billing;
            objNewDon.d_country_billing = _d_country_billing;
            // insert command
            objPageDC.ndmh_donations.InsertOnSubmit(objNewDon);
            // commit insert against db
            objPageDC.SubmitChanges();
            return true;
        }
    }


    // method to update donation record

    public bool updateDons(int _d_id, string _d_fname, string _d_lname, string _d_in_memory_of, string _d_amount, string _d_email,
        string _d_address_mailing, string _d_city_mailing, string _d_provstate_mailing, string _d_postalzip_mailing,
        string _d_name_billing, string _d_credit_number, string _d_credit_expiry, string _d_address_billing, string _d_city_billing,
        string _d_provstate_billing, string _d_country_billing)
    {
        using (objPageDC)
        {
            var objUpDon = objPageDC.ndmh_donations.Single(x => x.d_id == _d_id);

            objUpDon.d_fname = _d_fname;
            objUpDon.d_lname = _d_lname;
            objUpDon.d_in_memory_of = _d_in_memory_of;
            objUpDon.d_amount = _d_amount;
            objUpDon.d_email = _d_email;
            objUpDon.d_address_mailing = _d_address_mailing;
            objUpDon.d_city_mailing = _d_city_mailing;
            objUpDon.d_provstate_mailing = _d_provstate_mailing;
            objUpDon.d_postzip_mailing = _d_postalzip_mailing;
            objUpDon.d_name_billing = _d_name_billing;
            objUpDon.d_credit_number = _d_credit_number;
            objUpDon.d_credit_expiry = _d_credit_expiry;
            objUpDon.d_address_billing = _d_address_billing;
            objUpDon.d_city_billing = _d_city_billing;
            objUpDon.d_provstate_billing = _d_provstate_billing;
            objUpDon.d_country_billing = _d_country_billing;



            // commit against db
            objPageDC.SubmitChanges();
            return true;
        }
    }

    // delete method for donation record
    public bool deleteDonation(int _d_id)
    {
        using (objPageDC)
        {
            var objDelDon = objPageDC.ndmh_donations.Single(x => x.d_id == _d_id);
            // delete command
            objPageDC.ndmh_donations.DeleteOnSubmit(objDelDon);
            // commit delte against db
            objPageDC.SubmitChanges();
            return true;
        }
    }


}