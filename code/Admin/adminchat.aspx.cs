using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//at the time of this feature completion, admin roles have not been established yet

public partial class _Default : System.Web.UI.Page
{

    LinqClass<ndmh_chat> chatDBObj = new LinqClass<ndmh_chat>(); 
    string adminName = "quin";  //hardcoded name for admin chatter


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            //checks to see if admin already in a chatroom via chatid in the session var.
            if (Session["chatroom"] == null)
            {
                //count the chat queue
                int count = ChatClass.chatrooms.Count;
                
                //if none, freely add a new one
                if (count == 0)
                {
                    Session["chatroom"] = 1;

                    //create the chat obj for the static chat list
                    ChatClass.chatrooms.Add(new ChatClass(1, "", adminName));
                }
                else
                {
                    //if there are some, get last index and increment one
                    //that will be the chatID
                    Session["chatroom"] = count + 1;
                    ChatClass.chatrooms.Add(new ChatClass(count + 1, "", adminName));
                }
            }

            _rebind();
        }
   
    }

    //button to handle the send button being pushed
    protected void subSend(object sender, EventArgs e)
    {
        //only do so when textbox is not empty
        if (txt_msg.Text != "")
        {
            
            ndmh_chat newChatObj = new ndmh_chat()
            {
                //replace linebreaks with br tags to ensure line breaks are preserved on display
                message = txt_msg.Text.Replace("\n","<br />"),
                chatroomID = Int32.Parse(Session["chatroom"].ToString()),
                timestamp = DateTime.Now,
                fromuser = adminName
            };

            //insert the message object to the database
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
        //rebind common chat messages, ordered based on timestamp
        rpt_chat.DataSource = chatDBObj.getResultByColumn(m=>m.chatroomID==Int32.Parse(Session["chatroom"].ToString()))
            .OrderBy(m => m.timestamp);
        rpt_chat.DataBind();

        //calling javascript function to make div scroll to latest message
        //source: http://forums.asp.net/t/1415969.aspx/1
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "scrolltobottom", ";divScroll();", true);
    }
    
    //delete current chat entries based on chatID
    protected void clearChatInDB(object sender, EventArgs e)
    {
        using (ndmhDCDataContext dc = new ndmhDCDataContext())
        {
            
            int chID = Int32.Parse(Session["chatroom"].ToString());

            //grabs all items with chatID
            var currChatItems = dc.ndmh_chats.Where(x => x.chatroomID == chID).Select(x=>x);
            if (currChatItems != null)
            {
                dc.ndmh_chats.DeleteAllOnSubmit(currChatItems);
                dc.SubmitChanges();
                _rebind();
            }
        }
    }

}