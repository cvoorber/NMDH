<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="chat.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">

    <asp:ScriptManager ID="scm_main" runat="server" EnablePartialRendering="true" />
    
    <asp:Panel ID="pnl_status" runat="server">
        <asp:Label ID="lbl_status" runat="server" />
        <br /><br />

        <asp:Label ID="lbl_nickname" runat="server" Text="Enter a nickname:" />
        <br />
        <asp:TextBox ID="txt_nickname" runat="server" />
       
        <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="subSubmit" />
    </asp:Panel>

    <asp:Panel ID="pnl_chat" runat="server">
        <asp:Label ID="lbl_nicknameC" runat="server" />
        <br /><br />
        

        <asp:Label ID="lbl" runat="server" Text="Username: Quin" />
        <div id="chatbox" style="width:580px;border:1px solid black;height:300px;">
            <asp:UpdatePanel ID="upl_main" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:BulletedList ID="bl_chatmsg" runat="server" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btn_send" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="tmr_main" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:Timer ID="tmr_main" runat="server" OnTick="subRefresh" />
        </div>

        <asp:TextBox ID="txt_msg" runat="server" TextMode="MultiLine" style="width:500px; height:75px; max-width:500px; max-height:75px;float:left;" />
        <asp:Button ID="btn_send" runat="server" OnClick="subSend" Text="Send" style="width:75px;height:80px;float:left;" />
    </asp:Panel>
</asp:Content>

