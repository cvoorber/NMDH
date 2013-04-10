using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    LinqClass<ndmh_chat> chatDBObj = new LinqClass<ndmh_chat>();
    int chatID = 1;
    int myID = 11;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            rebind();
    }

    protected void subSend(object sender, EventArgs e)
    {
        if (txt_msg.Text != "")
        {
            ndmh_chat newChatObj = new ndmh_chat()
            {
                message = txt_msg.Text.Replace("\n","<br />"),
                chatroomID = chatID,
                timestamp = DateTime.Now,
                fromuser = myID,
                touser = 1
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
        rpt_chat.DataSource = chatDBObj.getItems().OrderBy(m => m.timestamp);
        rpt_chat.DataBind();

        //calling javascript function to make div scroll to latest message
        //source: http://forums.asp.net/t/1415969.aspx/1
        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "scrolltobottom", ";divScroll();", true);
    }
    

    public void clearChatInDB(int id)
    {
        using (ndmhDCDataContext dc = new ndmhDCDataContext())
        {
            var currChatItems = dc.ndmh_chats.Where(x => x.chatroomID == id).Select(x=>x);
            if (currChatItems != null)
            {
                dc.ndmh_chats.DeleteAllOnSubmit(currChatItems);
                dc.SubmitChanges();
            }
        }
    }
}