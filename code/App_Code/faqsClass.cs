using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for faqsClass
/// </summary>
public class faqsClass
{
    // instance of faq data context
    ndmhDCDataContext objFaqs = new ndmhDCDataContext();

    // this method performs a linq query to get FAQ titles, and retuns an array of the titles 
    public string[] getAllFaqTitles()
    {
        var allFaqs = objFaqs.ndmh_faqs.Select(x => x.ndmh_faq_title).ToArray();
        return allFaqs;
    }

    // this method grabs all the faqids from the db and returs them as a int array
    public int[] getAllFaqIDs()
    {
        var allFaqIDs = objFaqs.ndmh_faqs.Select(x => x.ndmh_faq_id).ToArray();
        return allFaqIDs;
    }

    // this method will return the list of faq keywords as a string array, based on the faq_id
    public string[] getFaqKeywordsByFaqID(int _faq_id)
    {
        var allFaqKeyws = objFaqs.ndmh_faq_keywords.Where(x => x.ndmh_faq_id == _faq_id).Select(x => x.faq_keyword).ToArray();
        return allFaqKeyws;
    }

    // returns all columns for Faq table by for given ID
    public IQueryable<ndmh_faq> getAllFaqsByID(int _id)
    {
        var allFaqs = objFaqs.ndmh_faqs.Where(x => x.ndmh_faq_id == _id).Select(x => x);
        return allFaqs;
    }


    // this method accepts the keyword string array for a particular faq and the search string from the search box
    // matches the keyword string with the split string from the search box, and returns an int value that indicates the number
    // of words that matched.
    // Split method part inspired by example from http://msdn.microsoft.com/en-ca/library/b873y76a.aspx

    public int getMatchScore(string[] allkeywords, string _words)
    {

        

        string[] split = _words.Split(new Char[] { ' ', ',', '.', ':', '\t', '?' });
        string[] peas = allkeywords; 
        int score = 0;
        foreach (string s in split)
        {
            
            // just before doing the comparrision, we do the trim test to eliminate blank cells.
            if (s.Trim() != "")
            {
                // contains function looks at how many of the words from the split _words string are contained in the 
                // peas array that has the list of all keywords for the particular faq
                if (peas.Contains(s))
                {
                    score += 1;
                }
            }
        }
        return score;
    }

    
    // Pre Condition: this function will compare the string array from the search box to the string arrays for each of the faqs
    // Post Condition: this function will return an IDictionary "associative" array having faqid as index and score as value for each faq.
    public IDictionary<int, int> compareToKeywords(string _words)
    {
        
        // get all faq ids from FAQ table as an int array
        int[] allfaqids = getAllFaqIDs();

        // using the dictionary class to create a kind of associative array to store the faqid and score using below foreach
        IDictionary<int, int> scorelist = new Dictionary<int, int>();
       
        // this foreach grabs the keywords for each faq (by faqID), runs the match function against the searchbox string
        // then puts the score that is returned by the getMatchScoreFunction into an IDictionary array using the FaqID as the index and "matchscore"
        // as the value
        foreach (int i in allfaqids)
        {
            
            string[] allkeywords = getFaqKeywordsByFaqID(i);
            int score = getMatchScore(allkeywords, _words);

            
            scorelist[i] = score;

        }
        // return the scorelist with faqid's and scores for each of the faqs that are in the db.
        return scorelist; 
   
    }

}

