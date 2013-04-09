<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminchat.aspx.cs" Inherits="Admin_adminchat" MasterPageFile="~/Admin/subAdmin.master" %>

<asp:Content ID="ct_main" ContentPlaceHolderID="r_content" runat="server" >
    <asp:ScriptManager ID="scm_main" runat="server" />
    <style>
        #commonWindow 
        {
            width: 400px;
            height: 300px;
            border: 1px solid black;
            
        }
    </style>
    <asp:Timer ID="tmr_main" runat="server" OnTick="subTick" Interval="1500" />


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
    <asp:UpdatePanel ID="udp_send" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TextBox ID="txt_message" runat="server" Width="400px" Height="60px" TextMode="MultiLine" />
            <br />
            <asp:Button ID="btn_send" runat="server" OnClick="subSend"  Text="Send" Width="60px" Height="60px"/>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn_send" EventName="Click" />
        </Triggers>
     </asp:UpdatePanel>       
</asp:Content>
