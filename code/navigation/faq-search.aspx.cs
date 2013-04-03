﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    faqsClass objFaqs = new faqsClass();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
    }

     //this method was generated by AJAX control toolkit to create the list of auto-fill suggestions
     //inspired by example from http://www.asp.net/ajaxlibrary/act_AutoComplete_Simple.ashx
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        faqsClass objFaqs = new faqsClass();
        
        // set titles array that will be used in the return statement to routine that sets list of titles from db into an array.  
        string[] titles = objFaqs.getAllFaqTitles(); 

        // Return matching movies  
        return (from t in titles where t.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select t).Take(count).ToArray();
    }

    
   // start condition: on click of search button -> uses string from the search box
    // end condition: subroutine called that will display top matching faq articles
    protected void subSearchSubmit(object sender, EventArgs e)
    {
        string words = txt_faqsearch.Text;
        
        // take string from search box and getting a list (Idictionary -> like associative array) 
        //of scores for the string againgst each faq.
        IDictionary<int, int> scorelist = objFaqs.compareToKeywords(words);
      
      foreach (KeyValuePair<int, int> item in scorelist.OrderBy(key => key.Value))
        {
            // run function to return faq content for each of the faq ordered results in a repeater
          //*** As of first test, just the first item on the list is showing up -> probe this further laster
          // my understanding of ordering an IDictionary array, and getting them to be listed out is not perfect.
            subResultPanelBind(item.Key);
        }
    }



    // called by subSearchSubmit to bind the top search results to the display repeater.
    private void subResultPanelBind(int _id)
    {
        rpt_searchresults.DataSource = objFaqs.getAllFaqsByID(_id);
        rpt_searchresults.DataBind();
    }

    

}