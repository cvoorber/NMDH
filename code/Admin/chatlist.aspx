<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chatlist.aspx.cs" Inherits="chatlist" MasterPageFile="~/Admin/subAdmin.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <div>
    <asp:ScriptManager ID="scm_main" runat="server" />
        Current Users online:
        <br />
        <asp:UpdatePanel ID="upl_main" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:Repeater runat="server" ID="rpt_chatlist">
                    <ItemTemplate>
                        <asp:HyperLink ID="hl_user" runat="server" Text='<%# this.GetDataItem().ToString() %>' Target="_blank" 
                                NavigateUrl='<%# String.Format("~/Admin/adminchat.aspx?user={0}", this.GetDataItem().ToString()) %>' />
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
</asp:Content>