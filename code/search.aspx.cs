using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    LinqClass<ndmh_keyword> kwObj = new LinqClass<ndmh_keyword>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["query"] != null)
        {
            List<ndmh_keyword> matchKeys = new List<ndmh_keyword>();
            var strArray = Request.QueryString["query"].Split('+');
            var keyObjects = kwObj.getItems();

            foreach (ndmh_keyword kw in keyObjects)
            {
                for (int i = 0; i < strArray.Length; i++)
                {
                        string tmpStr = strArray[i].Trim().ToLower();
                        if(kw.page_title.Contains(tmpStr)||kw.keywords.Contains(tmpStr))
                        {
                            matchKeys.Add(kw);
                            break;
                        }
                }
            }

            if (matchKeys.Count > 0)
            {
                rpt_result.DataSource = matchKeys;
                rpt_result.DataBind();
                pnl_result.Visible = true;
            }
        }
    }

    
    protected void subSearch(object sender, EventArgs e)
    {
            List<ndmh_keyword> matchKeys = new List<ndmh_keyword>();
            var keyObjects = kwObj.getItems();
            var strArray = (txt_search.Text).Split(' ');

            foreach (ndmh_keyword kw in keyObjects)
            {
                for (int i = 0; i < strArray.Length; i++)
                {
                        string tmpStr = strArray[i].Trim().ToLower();
                        if(kw.page_title.Contains(tmpStr)||kw.keywords.Contains(tmpStr))
                        {
                            matchKeys.Add(kw);
                            break;
                        }
                }
            }

            if (matchKeys.Count > 0)
            {
                rpt_result.DataSource = matchKeys;
                rpt_result.DataBind();
                pnl_result.Visible = true;
            }
        }
    }