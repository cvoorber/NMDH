using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

using System.Data.Linq;

/// <summary>
/// semi generic linq class to handle multiple table objects onf datacontext
/// </summary>
public class LinqClass<T> where T: class
{
	
    //create new datacontext object
    ndmhDCDataContext dcObj = new ndmhDCDataContext();

    //get all items of type T from datacontext
    public IQueryable<T> getItems()
    {
       var allItems = dcObj.GetTable<T>().Select(x => x);
       return allItems;
    }

    //get all items of type T based on lambda expression
    public IQueryable<T> getResultByColumn(Expression<Func<T,bool>> lambda)
    {
        ndmhDCDataContext dcObj = new ndmhDCDataContext();

        var item = dcObj.GetTable<T>().Where(lambda).Select(x=>x);
        return item;
    }


    //insert into item of type T 
    public bool Insert(T insertItem)
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

    public bool Update(T updateItem)
    {
		//creating own copy of Linq object
        ndmhDCDataContext dcObj = new ndmhDCDataContext();

        
		//automatic opening and closing of Linq object connection
        using (dcObj)
        {
            //attach the updated object (record)
			dcObj.GetTable<T>().Attach(updateItem);

            //resolves conflicts by overwriting values of the object in question
            dcObj.Refresh(RefreshMode.KeepCurrentValues, updateItem);
            
            dcObj.SubmitChanges();
        }
        return true;
    }

    //takes a lambda expression and deletes record
    public bool Delete(Expression<Func<T,bool>> lambda)
    {
        ndmhDCDataContext dcObj = new ndmhDCDataContext();
        using(dcObj)
        {
            var delObj = dcObj.GetTable<T>().Where(lambda).Single();
            dcObj.GetTable<T>().DeleteOnSubmit(delObj);
            dcObj.SubmitChanges();
        }
        return true;
    }

}