using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for faqsadminClass
/// </summary>
public class faqsadminClass
{
    ndmhDCDataContext objFaqs = new ndmhDCDataContext();

	// method to get all faq data
    public IQueryable<ndmh_faq> getAllFaqs()
    {
        var allFaqs = objFaqs.ndmh_faqs.Select(x => x);
        return allFaqs;
    }

    // method to get all faq data by ID
    public IQueryable<ndmh_faq> getFaqByID(int _ndmh_faq_id)
    {
        var allFaqsID = objFaqs.ndmh_faqs.Where(x => x.ndmh_faq_id == _ndmh_faq_id).Select(x => x);
        return allFaqsID;

    }

    // method to get all keyword data for a particular faq ID - returns an Iqueryable object
    public IQueryable<ndmh_faq_keyword> getFaqKeysByID(int _ndmh_faq_id)
    {
        var allFaqKeysID = objFaqs.ndmh_faq_keywords.Where(x => x.ndmh_faq_id == _ndmh_faq_id).Select(x => x);
        return allFaqKeysID;
    }

    // method to insert new faq record
    public bool insertFaqs(string _ndmh_faq_title, string _ndmh_contact_content)
    {
        using (objFaqs)
        {
            // create an instance of a table
            ndmh_faq objNewFaq = new ndmh_faq();
            objNewFaq.ndmh_faq_title = _ndmh_faq_title;
            objNewFaq.ndmh_content = _ndmh_contact_content;
            // insert command
            objFaqs.ndmh_faqs.InsertOnSubmit(objNewFaq);
            // commit insert against db
            objFaqs.SubmitChanges();
            return true;
        }
    }

    // method to update faq record
    public bool updateFaqs(int _ndmh_faq_id, string _ndmh_faq_title, string _ndmh_contact_content)
    {
        using (objFaqs)
        {
            var objUpFaqs = objFaqs.ndmh_faqs.Single(x => x.ndmh_faq_id == _ndmh_faq_id);
            objUpFaqs.ndmh_faq_title = _ndmh_faq_title;
            objUpFaqs.ndmh_content = _ndmh_contact_content;
            // commit against db
            objFaqs.SubmitChanges();
            return true;
        }
    }

    // this method commits a delete of a faq record.
    public bool deleteFaqs(int _ndmh_faq_id)
    {
        using (objFaqs)
        {
            var objDelFaq = objFaqs.ndmh_faqs.Single(x => x.ndmh_faq_id == _ndmh_faq_id);
            // delete command
            objFaqs.ndmh_faqs.DeleteOnSubmit(objDelFaq);
            // commit delte against db
            objFaqs.SubmitChanges();
            return true;
        }
    }

    // method to update faq keyword record
    public bool updateFaqKeyWordByID(int _fkword_id, string _faq_keyword)
    {
        using (objFaqs)
        {
            var objUpFaqKey = objFaqs.ndmh_faq_keywords.Single(x => x.fkword_id == _fkword_id);
            objUpFaqKey.faq_keyword = _faq_keyword;
            
            // commit against db
            objFaqs.SubmitChanges();
            return true;
        }
    }

    // method to delete faq keyword record by id

    public bool deleteFaqKeyword(int _fkword_id)
    {
        using (objFaqs)
        {
            var objDelFaqKey = objFaqs.ndmh_faq_keywords.Single(x => x.fkword_id == _fkword_id);
            // delete command
            objFaqs.ndmh_faq_keywords.DeleteOnSubmit(objDelFaqKey);
            // commit delte against db
            objFaqs.SubmitChanges();
            return true;
        }
    }

    // method to insert new faq keyword
    public bool insertFaqKeywordByFaqID(int _ndmh_faq_id, string _faq_keyword)
    {
        using (objFaqs)
        {
            // create an instance of a faq key table
            ndmh_faq_keyword objNewFaqKey = new ndmh_faq_keyword();
            objNewFaqKey.ndmh_faq_id = _ndmh_faq_id;
            objNewFaqKey.faq_keyword = _faq_keyword;
            // insert command
            objFaqs.ndmh_faq_keywords.InsertOnSubmit(objNewFaqKey);
            // commit insert against db
            objFaqs.SubmitChanges();
            return true;
        }
    }
}