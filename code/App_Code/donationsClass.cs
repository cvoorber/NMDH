using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for donationsClass
/// </summary>
public class donationsClass
{
    donationsDataContext objDonDC = new donationsDataContext();
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






   
}