using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    LinqClass<ndmh_chat> chatDBObj = new LinqClass<ndmh_chat>();

    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["nickname"] != null)
            {
                Session["nickname"] = Request.QueryString["nickname"].ToString();

                if(Session["chatroom"] == null)
                    Session["chatroom"] = getChatRoom(); 
                
                showPanel(pnl_chat);
                rebind();
            }
            else
            {
                showPanel(pnl_status);
            }
           ;
        }
    }

    protected void subSend(object sender, EventArgs e)
    {
        if (txt_msg.Text != "")
        {
            ndmh_chat newChatObj = new ndmh_chat()
            {
                message = txt_msg.Text.Replace("\n", "<br />"),
                chatroomID = Int32.Parse(Session["chatroom"].ToString()),
                timestamp = DateTime.Now,
                fromuser = Session["nickname"].ToString()
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
        rpt_chat.DataSource = chatDBObj.getResultByColumn(m => m.chatroomID == Int32.Parse(Session["chatroom"].ToString()))
            .OrderBy(m => m.timestamp);
        rpt_chat.DataBind();

        //calling javascript function to make div scroll to latest message
        //source: http://forums.asp.net/t/1415969.aspx/1
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "scrolltobottom", ";divScroll();", true);
    }

    private void showPanel(Panel p)
    {
        pnl_chat.Visible = false;
        pnl_status.Visible = false;
        p.Visible = true;
    }


    private int getChatRoom()
    {
        int chID = 0;
        if (ChatClass.chatrooms.Count == 0)
        {
            disableChat();
            lbl_status.Text = "Chat is Offline.";
        }
        else
        {
            for (int i = 0; i < ChatClass.chatrooms.Count; i++)
            {
                if (ChatClass.chatrooms[i].userName == "" && ChatClass.chatrooms[i].adminName != "")
                {
                    ChatClass.chatrooms[i].userName = Session["nickname"].ToString();
                    chID = i + 1;
                }
                else
                {
                    lbl_status.Text = "Currently no chats are available.";
                }
            }
          
        }
        return chID;
    }

    private void disableChat()
    {
    }

    protected void subSubmit(object sender, EventArgs e)
    {
        Response.Redirect("chat.aspx?nickname="+txt_nickname.Text);
    }
}