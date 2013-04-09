<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
<div id="waitTime">
    <asp:Label ID="ttl_estimate" runat="server" Text="E.R. Wait Estimator" SkinID="waitTitle" />
    <br /><br />
    <asp:DataList ID="dtl_main" runat="server">
        <ItemTemplate>
            <asp:Label ID="ttl_estimate" runat="server" Text="Estimation:" SkinID="waitLabel" />
            <asp:Label ID="lbl_estimate" runat="server" Text='<%#Eval("w_estimate") %>' SkinID="waitResults" />
            <asp:Label ID="lbl_details" runat="server" Text=" hours" SkinID="waitResults" />
            <br />
            <asp:Label ID="ttl_update" runat="server" Text="Last Update:" SkinID="waitLabel" />
            <asp:Label ID="lbl_update" runat="server" Text='<%#Eval("w_updated", "{0:t}") %>' SkinID="waitResults" />
            <br /><br />
        </ItemTemplate>
    </asp:DataList>
    <asp:Button ID="btn_show" runat="server" Text="Display/Refresh" OnClick="subUpdate" Font-Size="11" />
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
</asp:Content>

