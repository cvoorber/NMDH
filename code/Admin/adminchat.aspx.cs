using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{

    LinqClass<ndmh_chat> chatDBObj = new LinqClass<ndmh_chat>(); 
    string adminName = "quin";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Session["chatroom"] == null)
            {
                int count = ChatClass.chatrooms.Count;
                if (count == 0)
                {
                    Session["chatroom"] = 1;
                    ChatClass.chatrooms.Add(new ChatClass(1, "", adminName));
                }
                else
                {
                    Session["chatroom"] = count + 1;
                    ChatClass.chatrooms.Add(new ChatClass(count + 1, "", adminName));
                }
            }

            rebind();
        }
   
    }

    protected void subSend(object sender, EventArgs e)
    {
        if (txt_msg.Text != "")
        {
            ndmh_chat newChatObj = new ndmh_chat()
            {
                message = txt_msg.Text.Replace("\n","<br />"),
                chatroomID = Int32.Parse(Session["chatroom"].ToString()),
                timestamp = DateTime.Now,
                fromuser = adminName
            };

            chatDBObj.Insert(newChatObj);
            rebind();
        }
        txt_msg.Text = "";
    }

    protected void subRefresh(object sender, EventArgs e)
    {
        rebind();
    }

    private void rebind()
    {
        rpt_chat.DataSource = chatDBObj.getResultByColumn(m=>m.chatroomID==Int32.Parse(Session["chatroom"].ToString()))
            .OrderBy(m => m.timestamp);
        rpt_chat.DataBind();

        //calling javascript function to make div scroll to latest message
        //source: http://forums.asp.net/t/1415969.aspx/1
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "scrolltobottom", ";divScroll();", true);
    }
    

    protected void clearChatInDB(object sender, EventArgs e)
    {
        using (ndmhDCDataContext dc = new ndmhDCDataContext())
        {
            int chID = Int32.Parse(Session["chatroom"].ToString());
            var currChatItems = dc.ndmh_chats.Where(x => x.chatroomID == chID).Select(x=>x);
            if (currChatItems != null)
            {
                dc.ndmh_chats.DeleteAllOnSubmit(currChatItems);
                dc.SubmitChanges();
                rebind();
            }
        }
    }

}