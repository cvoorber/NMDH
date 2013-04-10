<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="chat.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">

    <script type="text/javascript">
        function divScroll() {
            var targetDiv = document.getElementById("chatbox");
            targetDiv.scrollTop = targetDiv.scrollHeight;
        }
    </script>
    
    <asp:ScriptManager ID="scm_main" runat="server" />
    
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
        <div id="chatbox" style="width:580px;border:1px solid black;height:300px; overflow-y:scroll;">
            <asp:UpdatePanel ID="upl_main" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                     <asp:Repeater ID="rpt_chat" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="lbl_from" runat="server" Text='<%#Eval("fromuser") + ":" %>' />
                            <asp:Label ID="lbl_time" runat="server" Text='<%# "<" + Eval("timestamp").ToString() + ">:" %>' />
                            <asp:Label ID="lbl_msg" runat="server" Text='<%#Eval("message") %>' />
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btn_send" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="tmr_main" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:Timer ID="tmr_main" runat="server" OnTick="subRefresh" Interval="2000" />
        </div>
        <asp:UpdatePanel ID="upl_msgbox" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:TextBox ID="txt_msg" runat="server" TextMode="MultiLine" style="width:500px; height:75px; max-width:500px; max-height:75px;float:left;" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btn_send" EventName="Click" />
            </Triggers>    
        </asp:UpdatePanel>
        <asp:Button ID="btn_send" runat="server" OnClick="subSend" Text="Send" style="width:75px;height:80px;float:left;" />
    </asp:Panel>
</asp:Content>

