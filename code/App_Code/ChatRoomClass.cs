using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChatRoomClass
/// </summary>
public class ChatRoomClass
{
    private int _chatID;
    private string _adminName;
    private string _userName;

    public static List<string> admins = new List<string>();
    public static List<string> users = new List<string>();
    public static List<ChatRoomClass> chatrooms = new List<ChatRoomClass>();

	public ChatRoomClass(string a, string u)
	{
        _chatID = generateID();
        _adminName = a;
        _userName = u;
	}

    public int ChatID
    {
        set { _chatID = value; }
        get { return _chatID; }
    }

    public string AdminName
    {
        set { _adminName = value; }
        get { return _adminName; }
    }

    public string UserName
    {
        set { _userName = value; }
        get { return _userName; }
    }


    public static void removeChat(ChatRoomClass ch)
    {
        chatrooms.Remove(ch);
    }

    public static int generateID()
    {
        int highID = 0;
        if (chatrooms.Count == 0)
            highID = 1;
        else
        {
            foreach(ChatRoomClass chat in chatrooms)
            {
                if (chat.ChatID > highID)
                {
                    highID = chat.ChatID;
                }
            }
            highID++;
        }
        return highID;
    }

}