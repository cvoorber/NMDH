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
            //if nickname is in query string from postback
            if (Request.QueryString["nickname"] != null)
            {
                //put nickname in session variable
                Session["nickname"] = Request.QueryString["nickname"].ToString();

                //if no chatroom/chatID assigned to session
                //get next available
                if (Session["chatroom"] == null)
                {
                    Session["chatroom"] = _getChatRoom();
                    lbl_nicknameC.Text = "Chatroom: " + Session["chatroom"].ToString();

                    lbl.Text = "Nickname: " + Session["nickname"].ToString();
                }

                _showPanel(pnl_chat);
                _rebind();
            }
            else
            {
                _showPanel(pnl_status);
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
                //convert newline characters to br tags before sending to database
                message = txt_msg.Text.Replace("\n", "<br />"),
                chatroomID = Int32.Parse(Session["chatroom"].ToString()),
                timestamp = DateTime.Now,
                fromuser = Session["nickname"].ToString()
            };
            
            chatDBObj.Insert(newChatObj);
            _rebind();
        }
        txt_msg.Text = "";
    }

    protected void subRefresh(object sender, EventArgs e)
    {
        _rebind();
    }

    private void _rebind()
    {
        rpt_chat.DataSource = chatDBObj.getResultByColumn(m => m.chatroomID == Int32.Parse(Session["chatroom"].ToString()))
            .OrderBy(m => m.timestamp);
        rpt_chat.DataBind();

        //calling javascript function to make div scroll to latest message
        //source: http://forums.asp.net/t/1415969.aspx/1
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "scrolltobottom", ";divScroll();", true);
    }

    private void _showPanel(Panel p)
    {
        pnl_chat.Visible = false;
        pnl_status.Visible = false;
        p.Visible = true;
    }

    //get first available chatID/chatroom
    private int _getChatRoom()
    {
        int chID = 0;
        
        //if count is 0, there are no admin on to create 'chatrooms'
        if (ChatClass.chatrooms.Count == 0)
        {
            _disableChat();
            lbl_status.Text = "Chat is Offline.";
        }
        else
        {
            //loop through chatrooms to see what is available
            //if chatroom is available (denoted by not having username set
            //and admin is set
            for (int i = 0; i < ChatClass.chatrooms.Count; i++)
            {
                if (ChatClass.chatrooms[i].userName == "" && ChatClass.chatrooms[i].adminName != "")
                {
                    ChatClass.chatrooms[i].userName = Session["nickname"].ToString();
                    
                    //chatrooms / chatID starts from 1 even though array/list starts from index zero
                    chID = i + 1;
                }
                else
                {
                    lbl_status.Text = "Currently no chats are available.";
                }
            }
          
        }

        //return first available
        return chID;
    }

    private void _disableChat()
    {
    }

    //when nickname form is submitted 
    //postback to page with nickname
    protected void subSubmit(object sender, EventArgs e)
    {
        Response.Redirect("chat.aspx?nickname="+txt_nickname.Text);
    }
}