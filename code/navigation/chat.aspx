<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="chat.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
    <h1>Why Chat?</h1>
    <p>We know you have a lot of questions about your health, and we want to help! That's why we have nurses on duty 24/7 to answer your most pressing questions from the comfort of your own home</p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">

    <%-- script to make scrollbar on chatwindow scroll down to newest msg on rebind --%>
    <script type="text/javascript">
        function divScroll() {
            var targetDiv = document.getElementById("chatbox");
            targetDiv.scrollTop = targetDiv.scrollHeight;
        }
    </script>
    
    <%--Scriptmanager to handle all ajax functionality --%>
    <asp:ScriptManager ID="scm_main" runat="server" />
    <asp:Label ID="lbl_status" runat="server" />
    <br /><br />

    <%-- initial form for user to enter nickname --%>
    <asp:Panel ID="pnl_status" runat="server">
        <asp:Label ID="lbl_nickname" runat="server" Text="Enter a nickname:" />
        <br />
        <asp:TextBox ID="txt_nickname" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_nickname" runat="server" ControlToValidate="txt_nickname" ErrorMessage="*required" />
       
        <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="subSubmit" />
    </asp:Panel>


    <%-- common message area where messages are shown and updated --%>
    <asp:Panel ID="pnl_chat" runat="server">
        <asp:Label ID="lbl_nicknameC" runat="server" />
        <br /><br />

        <asp:Label ID="lbl" runat="server" Text="Username: Quin" />
        <div id="chatbox" style="width:580px;border:1px solid black;height:300px; overflow-y:scroll;">
            
            <%-- update panel for asynchronously update common message area --%>
            <asp:UpdatePanel ID="upl_main" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                     <asp:Repeater ID="rpt_chat" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="lbl_from" runat="server" Text='<%#Eval("fromuser") + ":" %>' />
                            <asp:Label ID="lbl_time" runat="server" Text='<%# "<" + Eval("timestamp", "{0:hh:mm:ss}") + ">:" %>' />
                            <asp:Label ID="lbl_msg" runat="server" Text='<%#Eval("message") %>' />
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
                <Triggers>
                    <%-- refresh is triggered by send button or timer --%>
                    <asp:AsyncPostBackTrigger ControlID="btn_send" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="tmr_main" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:Timer ID="tmr_main" runat="server" OnTick="subRefresh" Interval="2000" />
        </div>

        <%-- message textbox is ajax'd also to ensure it is cleared upon send button click --%>
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

