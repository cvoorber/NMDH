using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

public partial class SubMaster1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        ((maintemplate)this.Master).upFont += new EventHandler(fontInc);
        ((maintemplate)this.Master).downFont += new EventHandler(fontDec);
    }

    protected void fontInc(object sender, EventArgs e)
    {
    }

    protected void fontDec(object sender, EventArgs e)
    {
    }
}
