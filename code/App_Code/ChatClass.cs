using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChatClass
/// </summary>
public class ChatClass
{
    private int _chatID;
    private string _userName;
    private string _adminName;
    
    //static list to keep track of 'chatrooms'
    //ChatClass object = chatroom
    //dynamically created by adminchat and inserted into this list
    
    public static List<ChatClass> chatrooms = new List<ChatClass>();

    
    public ChatClass(int chatID=0,string userName="",string adminName="")
    {
    	_userName = userName;
        _adminName = adminName;
        _chatID = chatID;
    }

    public int chatID
    {
        set { _chatID = value; }
        get { return _chatID; }
    }

    public string userName
    {
        set { _userName = value; }
        get { return _userName; }
    }

    public string adminName
    {
        set { _adminName = value; }
        get { return _adminName; }
    }

    public void addToList()
    {
        chatrooms.Add(this);
    }

}