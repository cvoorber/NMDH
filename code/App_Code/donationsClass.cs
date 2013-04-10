


using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for donationsClass
/// </summary>
public class donationsClass
{
    ndmhDCDataContext objDonDC = new ndmhDCDataContext();
    // this function will return the entire list of countries for the country DDL's
    public IQueryable<base_country> getAllCountries()
    {
        //creating an instance of the donations LINQ object
        // might have to put the instantiation of datacontext within functions
        var allCountries = objDonDC.base_countries.Select(x => x);
        return allCountries; 
    }

    // this function will return the entire list of provinces and states for the province
    // and states DDL's
    public IQueryable<state_or_province> getAllStatesOrProvinces()
    {
        var allStatesOrProvinces = objDonDC.state_or_provinces.Select(x => x);
        return allStatesOrProvinces;
    }

    // the rest here should be insert functions based on the submit from the last page.

    // method to insert new donation record

    public bool insertDonation(string _d_fname, string _d_lname, string _d_in_memory_of, string _d_amount, string _d_email,
        string _d_address_mailing, string _d_city_mailing, string _d_provstate_mailing, string _d_postalzip_mailing,
        string _d_name_billing, string _d_credit_number, string _d_address_billing, string _d_city_billing,
        string _d_provstate_billing, string _d_country_billing)
    {
        using (objDonDC)
        {
            // create an instance of a table
            ndmh_donation objNewDon = new ndmh_donation();
            objNewDon.d_fname = _d_fname;
            objNewDon.d_lname = _d_lname;
            objNewDon.d_in_memory_of = _d_in_memory_of;
            objNewDon.d_amount = decimal.Parse(_d_amount.ToString()); // doing this because was having problems with data type decimal ... fix later 
            objNewDon.d_email = _d_email;
            objNewDon.d_address_mailing = _d_address_mailing;
            objNewDon.d_city_mailing = _d_city_mailing;
            objNewDon.d_provstate_mailing = _d_provstate_mailing;
            objNewDon.d_postzip_mailing = _d_postalzip_mailing;
            objNewDon.d_name_billing = _d_name_billing;
            objNewDon.d_credit_number = _d_credit_number;
            //objNewDon.d_credit_expiry = _d_credit_expiry;
            objNewDon.d_address_billing = _d_address_billing;
            objNewDon.d_city_billing = _d_city_billing;
            objNewDon.d_provstate_billing = _d_provstate_billing;
            objNewDon.d_country_billing = _d_country_billing;
            // insert command
            objDonDC.ndmh_donations.InsertOnSubmit(objNewDon);
            // commit insert against db
            objDonDC.SubmitChanges();
            return true;
        }
    }
    // properties for user info form

    private string _uifname;
    public string uifirstName
    {
        get { return _uifname; }
        set { _uifname = value; }
    }

    private string _uilname;
    public string uilastName
    {
        get { return _uilname; }
        set { _uilname = value; }
    }

    private string _uiemail;
    public string uiEmail
    {
        get { return _uiemail; }
        set { _uiemail = value; }
    }

    private string _uimemory;
    public string uiMemory
    {
        get { return _uimemory; }
        set { _uimemory = value; }
    }

    private string _uidonate;
    public string uiDonate
    {
        get { return _uidonate; }
        set { _uidonate = value; }
    }

    private string _uiaddress;
    public string uiAddress
    {
        get { return _uiaddress; }
        set { _uiaddress = value; }
    }

    private string _uicity;
    public string uiCity
    {
        get { return _uicity; }
        set { _uicity = value; }
    }

    private string _uicountry;
    public string uiCountry
    {
        get { return _uicountry; }
        set { _uicountry = value; }
    }

    private string _uiprovstate;
    public string uiProvState
    {
        get { return _uiprovstate; }
        set { _uiprovstate = value; }
    }

    private string _uipostzip;
    public string uiPostZip
    {
        get { return _uipostzip; }
        set { _uipostzip = value; }
    }

   

    // properties for Credit Info

    private string _credname;
    public string credName
    {
        get { return _credname; }
        set { _credname = value; }
    }

    private string _credaddress;
    public string credAddress
    {
        get { return _credaddress; }
        set { _credaddress = value; }
    }

    private string _credcity;
    public string credCity
    {
        get { return _credcity; }
        set { _credcity = value; }
    }

    private string _credcountry;
    public string credCountry
    {
        get { return _credcountry; }
        set { _credcountry = value; }
    }

    private string _credprovstate;
    public string credProvState
    {
        get { return _credprovstate; }
        set { _credprovstate = value; }
    }

    private string _credpostzip;
    public string credPostZip
    {
        get { return _credpostzip; }
        set { _credpostzip = value; }
    }

    private string _crednumber;
    public string credNumber
    {
        get { return _crednumber; }
        set { _crednumber = value; }
    }

    private string _credcode;
    public string credCode
    {
        get { return _credcode; }
        set { _credcode = value; }
    }

    private string _credexpiry;
    public string credExpiry
    {
        get { return _credexpiry; }
        set { _credexpiry = value; }
    }

}