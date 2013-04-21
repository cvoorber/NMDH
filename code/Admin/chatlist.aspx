<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chatlist.aspx.cs" Inherits="chatlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="scm_main" runat="server" />
        Current Users online:
        <br />
        <asp:UpdatePanel ID="upl_main" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:Repeater runat="server" ID="rpt_chatlist">
                    <ItemTemplate>
                        <asp:HyperLink ID="hl_user" runat="server" Text='<%# this.GetDataItem().ToString() %>' Target="_blank" 
                                NavigateUrl='<%# String.Format("~/adminchat.aspx?user={0}", this.GetDataItem().ToString()) %>' />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="lbl_result" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="tmr_main" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="tmr_main" runat="server" OnTick="subTick" Interval="1000" />
        
    </div>
    </form>
</body>
</html>
