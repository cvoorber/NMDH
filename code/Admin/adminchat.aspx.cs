using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_adminchat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Application["adminOn"] = true;
        Session["adminOn"] = true;
    }

    protected void subSend(object sender, EventArgs e)
    {
        
        BulletedList bl = (BulletedList)udp_main.ContentTemplateContainer.FindControl("bl_messages");
        string msg = txt_message.Text;
        string username = txt_uname.Text;
        Application["msg"] = "";
        txt_message.Text = "";
        string fullLine = username + "(" + DateTime.Now.ToString() + "): " + msg;
        bl.Items.Add(new ListItem(fullLine));

        Application["msg"] = fullLine + Environment.NewLine;

    }

    protected void subTick(object sender, EventArgs e)
    {
        BulletedList bl = (BulletedList)udp_main.ContentTemplateContainer.FindControl("bl_messages");
        bl.Items.Add(new ListItem((string)Application["msg"]));
        Application["msg"] = "";
    }

   
}