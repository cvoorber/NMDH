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
            if (Session["chatroom"] != null)
            {
                pnl_form.Enabled = false;
                _showPanel(pnl_chat);
            }

            if(Session["user"]!=null && Session["inchat"]!=null)
            {
                if (Session["inchat"] == "yes" && Session["chatroom"] != null)
                {
                    pnl_chat.Enabled = false;
                    lbl_status.Text = "User has left chat.  Please close window.";
                }
            }

            if (Session["chatroom"] == null && Session["user"] != null)
            {
                string nickname = Session["user"].ToString();

                if (!ChatRoomClass.users.Contains(nickname))
                {
                    ChatRoomClass.users.Add(nickname);
                }

                lbl_nickname.Text = nickname;
                pnl_chat.Enabled = false;
                _showPanel(pnl_chat);
            }

            if (Session["chatroom"] == null && Session["user"] == null)
            {
                _showPanel(pnl_form);
            }
        }
    }

    protected void subSubmit(object sender, EventArgs e)
    {
        if (ChatRoomClass.users.Contains(txt_nickname.Text))
            lbl_status.Text = "Nickname is already taken.";
        else
        {
            Session["user"] = txt_nickname.Text;
            pnl_form.Enabled = false;
            //_showPanel(pnl_chat);
            Response.Redirect("~/Default.aspx");
        }
    }

    private void _showPanel(Panel p)
    {
        pnl_chat.Visible = false;
        pnl_form.Visible = false;
        p.Visible = true;
    }

    protected void subValidate(object sender, ServerValidateEventArgs e)
    {
        if (txt_nickname.Text.Contains(" "))
            e.IsValid = false;
        else
            e.IsValid = true;
    }

    protected void subCheck(object sender, EventArgs e)
    {
        if (ChatRoomClass.admins.Count == 0)
        {
            pnl_form.Enabled = false;
            lbl_status.Text = "Currently chat is offline.";
        }
        else
        {
            tmr_main.Enabled = false;
            pnl_form.Enabled = true;
            lbl_status.Text = "";
        }
    }

    private void _toggleChat()
    {
        pnl_chat.Enabled = !pnl_chat.Enabled;
    }

    protected void subConnect(object sender, EventArgs e)
    {
        List<ChatRoomClass> chatrooms = ChatRoomClass.chatrooms;
        if (chatrooms.Count > 0)
        {
            ChatRoomClass chObj;
            if(Session["chatroom"]!=null)
            {
                chObj = (ChatRoomClass)Session["chatroom"];
            }
            else
            {
                chObj = chatrooms.Where(x => x.UserName == Session["user"].ToString()).Single();
                if (chObj != null)
                {
                    tmr_connect.Enabled = false;
                    _toggleChat();
                    Session["chatroom"] = chObj;
                    lbl_chatto.Text = "Chatting with: " + chObj.AdminName;
                    lbl_constatus.Text = "Connected.";
                }
                else
                    lbl_constatus.Text = "Please wait.  Trying to connect.";
            }
        }
        else
            lbl_constatus.Text = "Please wait.  Trying to connect.";
    }


    protected void subRefresh(object sender, EventArgs e)
    {
        _rebind();
    }

    protected void subSend(object sender, EventArgs e)
    {
        ChatRoomClass chObj = (ChatRoomClass)Session["chatroom"];
        if (txt_msg.Text != "")
        {
            ndmh_chat newChatObj = new ndmh_chat()
            {
                //convert newline characters to br tags before sending to database
                message = txt_msg.Text.Replace("\n", "<br />"),
                chatroomID = chObj.ChatID,
                timestamp = DateTime.Now,
                fromuser = chObj.UserName.ToString()
            };

            txt_msg.Text = chObj.ChatID.ToString();
            chatDBObj.Insert(newChatObj);
            _rebind();
            
        }
        txt_msg.Text = "";
    }

    private void _rebind()
    {
        ChatRoomClass chObj = (ChatRoomClass)Session["chatroom"];

        if (!ChatRoomClass.chatrooms.Contains(chObj))
        {
            _toggleChat();
            lbl_status2.Text = "<b>" + chObj.AdminName.ToString() + " has left the chat. Please close the window.</b>";
            Session.RemoveAll();
            Session.Abandon();
        }
        else
        {
            //rebind common chat messages, ordered based on timestamp
            rpt_chat.DataSource = chatDBObj.getResultByColumn(m => m.chatroomID == chObj.ChatID).OrderBy(m => m.timestamp);
            rpt_chat.DataBind();
        }

        //calling javascript function to make div scroll to latest message
        //source: http://forums.asp.net/t/1415969.aspx/1
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "scrolltobottom", ";divScroll();", true);
    }

}