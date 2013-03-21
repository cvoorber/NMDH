using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

/// <summary>
/// Summary description for LinqClass
/// </summary>
public class LinqClass<T> where T: class
{
	//creating an instance of the Linq object
	//accessible by all functions in file
     
    news_eventDataContext dcObj = new news_eventDataContext();
    public IQueryable<T> getItems()
    {
       var allItems = dcObj.GetTable<T>().Select(x => x);
       return allItems;
    }


    public IQueryable<T> getItem(Expression<Func<T,bool>> predicate)
    {
		//select all from products where id = _id
        news_eventDataContext dcObj = new news_eventDataContext();

        var item = dcObj.GetTable<T>().Where(predicate).Select(x=>x);
        return item;
    }



    public static bool Insert<T>(T insertItem) where T: class
    {
    	news_eventDataContext dcObj = new news_eventDataContext();
    		
    		//automatic opening and closing of Linq object connection
        using (dcObj)
        {
		    dcObj.GetTable<T>().InsertOnSubmit(insertItem);
        	dcObj.SubmitChanges();
	    }
        return true;
    }

    public static bool Update<T>(T updateItem) where T: class
    {
		//creating own copy of Linq object
        news_eventDataContext dcObj = new news_eventDataContext();
		
		//automatic opening and closing of Linq object connection
        using (dcObj)
        {
			dcObj.GetTable<T>().Attach(updateItem);
            dcObj.SubmitChanges();
        }
        return true;
    }

    public static bool Delete(Expression<Func<T,bool>> predicate)
    {
        news_eventDataContext dcObj = new news_eventDataContext();
        using(dcObj)
        {
            var delObj = dcObj.GetTable<T>().Where<T>(predicate).Single();
            dcObj.GetTable<T>().DeleteOnSubmit(delObj);
            dcObj.SubmitChanges();
        }
        return true;
    }

}