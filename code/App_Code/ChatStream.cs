using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChatStream
/// </summary>
public class ChatStream
{
    private int _streamID;
    private int _userID;
    private int _adminID;
    private string _msg;

    public int streamID
    {
        set { _streamID = value; }
        get { return _streamID; }
    }

    public int userID
    {
        set { _userID = value; }
        get { return _userID; }
    }

    public int adminID
    {
        set { _adminID = value; }
        get { return _adminID; }
    }

    public string chatMessage
    {
        set { _msg = value; }
        get { return _msg; }
    }
}