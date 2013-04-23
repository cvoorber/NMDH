using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class chatlist : System.Web.UI.Page
{
    string adminName = "Quin";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!ChatRoomClass.admins.Contains(adminName))
            {
                ChatRoomClass.admins.Add(adminName);
                Session["adminuser"] = adminName;
            }
        }
    }

    protected void subTick(object sender,EventArgs e)
    {

        _rebind();
    }

    private void _rebind()
    {
        if (ChatRoomClass.users.Count == 0)
        {
            lbl_result.Text = "There are currently no users online.";
        }
        else
        {
            lbl_result.Text = "";
        }
        rpt_chatlist.DataSource = ChatRoomClass.users;
        rpt_chatlist.DataBind();
    }
}