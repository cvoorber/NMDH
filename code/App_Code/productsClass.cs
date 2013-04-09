using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class productsClass
{

    public IQueryable<ndmh_product> getProducts()
    {
        //create an instance of the LINQ object
        ndmhDCDataContext objProdDC = new ndmhDCDataContext();
        //create an anonymous variable with its value being the instance of the LINQ object
        var allProducts = objProdDC.ndmh_products.Select(x => x);
        //return IQueryable<ndmh_product> for data bound control to bind to 
        return allProducts;
    }

    public IQueryable<ndmh_product> getProductsByID(int _id)
    {
        ndmhDCDataContext objProdDC = new ndmhDCDataContext();
        var allProducts = objProdDC.ndmh_products.Where(x => x.p_id == _id).Select(x => x);
        return allProducts;
    }

    public bool commitInsert(string _name, string _desc, string _image, decimal _price)
    {
        ndmhDCDataContext objProdDC = new ndmhDCDataContext();
        //to ensure all data will be disposed when finished
        using (objProdDC)
        {
            //create an instance of the table
            ndmh_product objNewProd = new ndmh_product();
            //set table columns to new values being passed from *.aspx page
            objNewProd.p_name = _name;
            objNewProd.p_desc = _desc;
            objNewProd.p_image = _image;
            objNewProd.p_price = _price;
            //insert command
            objProdDC.ndmh_products.InsertOnSubmit(objNewProd);
            //commit insert against DB
            objProdDC.SubmitChanges();
            return true;
        }
    }
    public bool commitUpdate(int _id, string _name, string _desc, decimal _price)
    {
        ndmhDCDataContext objProdDC = new ndmhDCDataContext();
        using (objProdDC)
        {
            var objUpProd = objProdDC.ndmh_products.Single(x => x.p_id == _id);
            objUpProd.p_name = _name;
            objUpProd.p_desc = _desc;
            objUpProd.p_price = _price;
            //commit update against DB
            objProdDC.SubmitChanges();
            return true;
        }
    }
    public bool commitDelete(int _id)
    {
        ndmhDCDataContext objProdDC = new ndmhDCDataContext();
        using (objProdDC)
        {
            var objDelProd = objProdDC.ndmh_products.Single(x => x.p_id == _id);
            //delete command
            objProdDC.ndmh_products.DeleteOnSubmit(objDelProd);
            //commit delete against DB
            objProdDC.SubmitChanges();
            return true;
        }
    }
}