using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;

public partial class adminchat : System.Web.UI.Page
{
    LinqClass<ndmh_chat> chatDBObj = new LinqClass<ndmh_chat>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ChatRoomClass chObj = new ChatRoomClass(Session["adminuser"].ToString(), Request.QueryString["user"].ToString());
            ChatRoomClass.chatrooms.Add(chObj);
            ChatRoomClass.users.Remove(Request.QueryString["user"].ToString());

            lbl_chatto.Text = "Chatting with: " + chObj.UserName;
            lbl_nickname.Text = chObj.AdminName;
        }
    }

    //button to handle the send button being pushed
    protected void subSend(object sender, EventArgs e)
    {
        //only do so when textbox is not empty
        if (txt_msg.Text != "")
        {
            ChatRoomClass chObj = ChatRoomClass.chatrooms.Where(x=>x.AdminName==Session["adminuser"].ToString() &&
                   x.UserName == Request.QueryString["user"].ToString()).Single();
            ndmh_chat newChatObj = new ndmh_chat()
            {
                //replace linebreaks with br tags to ensure line breaks are preserved on display
                message = txt_msg.Text.Replace("\n", "<br />"),
                chatroomID = chObj.ChatID,
                timestamp = DateTime.Now,
                fromuser = chObj.AdminName
            };

            //insert the message object to the database
            chatDBObj.Insert(newChatObj).ToString();
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
        //rebind common chat messages, ordered based on timestamp
        ChatRoomClass chObj = ChatRoomClass.chatrooms.Where(x => x.AdminName == Session["adminuser"].ToString() &&
                   x.UserName == Request.QueryString["user"].ToString()).Single();
        try
        {
            rpt_chat.DataSource = chatDBObj.getResultByColumn(m => m.chatroomID == chObj.ChatID).OrderBy(m => m.timestamp);
            rpt_chat.DataBind();
        }
        catch (Exception e)
        {
        }

        //calling javascript function to make div scroll to latest message
        //source: http://forums.asp.net/t/1415969.aspx/1
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "scrolltobottom", ";divScroll();", true);
    }

    [WebMethod(EnableSession=true)]
    public static void cleanUp()
    {
        ndmhDCDataContext dc = new ndmhDCDataContext();

        string user = HttpContext.Current.Request.QueryString["user"].ToString();
        string adminuser = HttpContext.Current.Session["adminuser"].ToString();
        ChatRoomClass chObj = ChatRoomClass.chatrooms.Where(x => x.AdminName == adminuser &&
                   x.UserName == user).Single();
        ChatRoomClass.chatrooms.Remove(chObj);
        
        var chToRemove = dc.ndmh_chats.Where(x => x.chatroomID == chObj.ChatID).Select(x => x);
        dc.ndmh_chats.DeleteAllOnSubmit(chToRemove);
        dc.SubmitChanges();

        
       
    }

    protected void subKill(object sender, EventArgs e)
    {
        ndmhDCDataContext dc = new ndmhDCDataContext();

        string user = Request.QueryString["user"].ToString();
        string adminuser = Session["adminuser"].ToString();
        
        ChatRoomClass chObj = ChatRoomClass.chatrooms.Where(x => x.AdminName == adminuser &&
                   x.UserName == user).Single();
        ChatRoomClass.chatrooms.Remove(chObj);
        
        var chToRemove = dc.ndmh_chats.Where(x => x.chatroomID == chObj.ChatID).Select(x => x);
        dc.ndmh_chats.DeleteAllOnSubmit(chToRemove);
        dc.SubmitChanges();
    }
}