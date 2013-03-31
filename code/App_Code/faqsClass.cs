using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for faqsClass
/// </summary>
public class faqsClass
{
    faqsDataContext objFaqs = new faqsDataContext();

    // this function performs a linq query to get FAQ titles, and retuns an array of the titles 
    public string[] getAllFaqTitles()
    {
        var allFaqs = objFaqs.ndmh_faqs.Select(x => x.ndmh_faq_title).ToArray();
        return allFaqs;
    }






}