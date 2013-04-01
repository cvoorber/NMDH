using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void subSend(object sender, EventArgs e)
    {
        BulletedList bl = (BulletedList)udp_main.ContentTemplateContainer.FindControl("bl_messages");
        string msg = txt_message.Text;
        string username = txt_uname.Text;
        
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

   
    private void adminOn()
    {
        if ((bool)Application["adminOn"] == true)
        {
            txt_message.Enabled = true;
            btn_send.Enabled = true;
            
        }
        else
        {
            txt_message.Enabled = false;
            btn_send.Enabled = false;
        }
    }
}