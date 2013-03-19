using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class navClass
{
    public IQueryable<ndmh_general_page> getPageByName(string _name)
    {
        get_pageDataContext objPageDC = new get_pageDataContext();
        var allPage = objPageDC.ndmh_general_pages.Where(x => x.gp_title == _name).Select(x => x);
        return allPage;
    }
}