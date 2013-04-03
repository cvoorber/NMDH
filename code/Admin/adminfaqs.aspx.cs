using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    // instance of FaqsAdmin class
    faqsadminClass objFaqsAd = new faqsadminClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            subMaindBind();
        }
    }

    // event opens the edit panel
    protected void subEdit(object sender, CommandEventArgs e)
    {
        pnl_edit.Visible = true;
    }

    // event opens the insert panel
    protected void subInsert(object sender, CommandEventArgs e)
    {
        pnl_insert.Visible = true;
    }

    // brings about delete actions *** Remember to put in a pop-up
    protected void subDelete(object sender, CommandEventArgs e)
    {
        // add stuff in here later
    }

  

   

    


    // routine will bind FAQ data to the grid view control

    private void subMaindBind()
    {
        rpt_faqadm.DataSource = objFaqsAd.getAllFaqs();
        rpt_faqadm.DataBind();
    }
}