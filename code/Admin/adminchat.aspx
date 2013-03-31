<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminchat.aspx.cs" Inherits="Admin_adminchat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="scm_main" runat="server" />
    <style>
        #commonWindow 
        {
            width: 400px;
            height: 300px;
            border: 1px solid black;
            
        }
    </style>
    <asp:Timer ID="tmr_main" runat="server" OnTick="subTick" Interval="1000" />


    Username: <asp:TextBox ID="txt_uname" runat="server" />
    <div id="commonWindow">
       <asp:UpdatePanel ID="udp_main" runat="server">
            <ContentTemplate>
                <asp:BulletedList ID="bl_messages" runat="server" Width="400px"/>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="tmr_main" EventName="Tick" />
            </Triggers>
       </asp:UpdatePanel>
       
    </div>
    <br />
    <asp:TextBox ID="txt_message" runat="server" Width="400px" Height="60px" TextMode="MultiLine" />
    <br />
    <asp:Button ID="btn_send" runat="server" OnClick="subSend"  Text="Send" Width="60px" Height="60px"/>

    </div>
    </form>
</body>
</html>
