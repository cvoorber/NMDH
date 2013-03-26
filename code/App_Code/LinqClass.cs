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

    ndmhDCDataContext dcObj = new ndmhDCDataContext();
    public IQueryable<T> getItems()
    {
       var allItems = dcObj.GetTable<T>().Select(x => x);
       return allItems;
    }


    public IQueryable<T> getResultByColumn(Expression<Func<T,bool>> predicate)
    {
		//select all from products where id = _id
        ndmhDCDataContext dcObj = new ndmhDCDataContext();

        var item = dcObj.GetTable<T>().Where(predicate).Select(x=>x);
        return item;
    }



    public static bool Insert<T>(T insertItem) where T: class
    {
        ndmhDCDataContext dcObj = new ndmhDCDataContext();
    		
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
        ndmhDCDataContext dcObj = new ndmhDCDataContext();
		
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
        ndmhDCDataContext dcObj = new ndmhDCDataContext();
        using(dcObj)
        {
            var delObj = dcObj.GetTable<T>().Where<T>(predicate).Single();
            dcObj.GetTable<T>().DeleteOnSubmit(delObj);
            dcObj.SubmitChanges();
        }
        return true;
    }

}