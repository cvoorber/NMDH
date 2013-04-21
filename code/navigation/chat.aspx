<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.min.js" ></script>
    <script type="text/javascript" >
        function divScroll() {
            //var movDiv = document.getElementById("chatbox");
            //movDiv.scrollTop = movDiv.scrollHeight;

            var h = $('#chatbox')[0].scrollHeight;
            $('#chatbox').scrollTop(h);
        }
    </script>
    <style type="text/css">
        .go-below
        {
            clear: both;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="scm_main" runat="server" />
        <asp:UpdatePanel ID="upl_form" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnl_form" runat="server" Enabled="false">
                    <asp:Label runat="server" Text="Nickname: " />
                    <asp:TextBox runat="server" ID="txt_nickname" />
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="*required" ControlToValidate="txt_nickname" />
                    <asp:CustomValidator runat="server" ControlToValidate="txt_nickname" ErrorMessage="*must contain no spaces" OnServerValidate="subValidate" />
                    <br />
                    <asp:Button runat="server" ID="btn_submit" OnClick="subSubmit" Text="Submit" />
                    <br /><br />
                    <asp:Label ID="lbl_status" runat="server" />
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="tmr_main" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="tmr_main" runat="server" OnTick="subCheck" Interval="2000" />


        <asp:Panel ID="pnl_chat" runat="server">
            <asp:Label ID="lbl_nlbl" runat="server" Text="Username: " />
            <asp:Label ID="lbl_nickname" runat="server" />
            <br />
            <asp:UpdatePanel ID="upl_connect" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <asp:Label ID="lbl_chatto" runat="server" />
                    <br />
                    <div id="chatbox" style="width:580px;border:1px solid black;height:300px; overflow-y:scroll;">
            
                        <%-- update panel for asynchronously update common message area --%>
                        <asp:UpdatePanel ID="upl_chat" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                 <asp:Repeater ID="rpt_chat" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_from" runat="server" Text='<%#Eval("fromuser") + ":" %>' />
                                        <asp:Label ID="lbl_time" runat="server" Text='<%# "<" + Eval("timestamp", "{0:hh:mm:ss}") + ">:" %>' />
                                        <asp:Label ID="lbl_msg" runat="server" Text='<%#Eval("message") %>' />
                                        <br />
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Label ID="lbl_status2" runat="server" />
                            </ContentTemplate>
                            <Triggers>
                                <%-- refresh is triggered by send button or timer --%>
                                <asp:AsyncPostBackTrigger ControlID="btn_send" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="tmr_chat" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:Timer ID="tmr_chat" runat="server" OnTick="subRefresh" Interval="2000" />
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
                    <br /><br /> 
                    <asp:Label ID="lbl_constatus" runat="server" CssClass="go-below" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="tmr_connect" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:Timer runat="server" ID="tmr_connect" OnTick="subConnect" Interval="2000" />   
        </asp:Panel>
        
    </div>
    </form>
</body>
</html>
