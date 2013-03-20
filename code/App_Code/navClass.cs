using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class navClass
{
    public IQueryable<ndmh_general_page> getPageByName(string _name)
    {
        ndmhDCDataContext objPageDC = new ndmhDCDataContext();
        var allPage = objPageDC.ndmh_general_pages.Where(x => x.gp_title == _name).Select(x => x);
        return allPage;
    }
}