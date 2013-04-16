<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminchat.aspx.cs" Inherits="_Default" MasterPageFile="~/Admin/subAdmin.master" %>


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
    <%-- script to make scrollbar on chatwindow scroll down to newest msg on rebind --%>
    <script type="text/javascript">
        function divScroll() {
            var targetDiv = document.getElementById("chatbox");
            targetDiv.scrollTop = targetDiv.scrollHeight;
    </script>
    
    
    <%-- main common chat window panel --%>
    <%-- messages are display via a repeater --%>

    <asp:Panel ID="pnl_chat" runat="server">
        <asp:Label ID="lbl_nicknameC" runat="server" />
        <br /><br />
        
        <asp:Label ID="lbl" runat="server" Text="Username: Quin" />
        <div id="chatbox" style="width:580px;border:1px solid black;height:300px; overflow-y:scroll;">
            <asp:UpdatePanel ID="upl_main" runat="server" UpdateMode="Conditional">
                <ContentTemplate> 
                    <asp:Repeater ID="rpt_chat" runat="server">
                        <ItemTemplate>

                      <%-- on each message displayed, name, timestamp are shown  --%>
                            <asp:Label ID="lbl_from" runat="server" Text='<%#Eval("fromuser") + ":" %>' />
                            <asp:Label ID="lbl_time" runat="server" Text='<%# "<" + Eval("timestamp").ToString() + ">:" %>' />
                            <asp:Label ID="lbl_msg" runat="server" Text='<%#Eval("message") %>' />
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
                <Triggers>

                    <%-- common chat window is refreshed automatically and by send button --%>
                    <asp:AsyncPostBackTrigger ControlID="btn_send" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="tmr_main" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:Timer ID="tmr_main" runat="server" OnTick="subRefresh" Interval="2000" />
        </div>

        <%-- chat textbox is encased in updatepanel as to ensure it clears upon message sent --%>
        <asp:UpdatePanel ID="upl_msgbox" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:TextBox ID="txt_msg" runat="server" TextMode="MultiLine" style="width:500px; height:75px; max-width:500px; max-height:75px;float:left;" />
            </ContentTemplate>
            <Triggers>

                <%-- triggered by the same button --%>
                <asp:AsyncPostBackTrigger ControlID="btn_send" EventName="Click" />
            </Triggers>
         </asp:UpdatePanel>
        <asp:Button ID="btn_send" runat="server" OnClick="subSend" Text="Send" style="width:75px;height:80px;float:left;" />
    </asp:Panel>
   <br />

   <%-- button to delete all entries of current chat session from db --%>
   <%-- i've yet to find a way to automate this upon admin closing page --%>
   <asp:Button ID="btn_removechat" runat="server" OnClick="clearChatInDB" Text="Remove Chat" />
</asp:Content>
