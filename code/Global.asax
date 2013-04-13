<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        if (Session["chatroom"] != null)
        {
            using (ndmhDCDataContext dc = new ndmhDCDataContext())
            {

                int chID = Int32.Parse(Session["chatroom"].ToString());

                //grabs all items with chatID
                var currChatItems = dc.ndmh_chats.Where(x => x.chatroomID == chID).Select(x => x);
                if (currChatItems != null)
                {
                    dc.ndmh_chats.DeleteAllOnSubmit(currChatItems);
                    dc.SubmitChanges();
                }

                if (((bool)Session["admin"]) == false)
                    ChatClass.chatrooms[chID - 1].userName = "";
                else
                {
                    foreach (ChatClass ch in ChatClass.chatrooms)
                    {
                        if (ch.chatID == chID)
                        {
                            ChatClass.chatrooms.Remove(ch);
                            break;
                        }
                    }
                }
            }
        }
    }
       
</script>
