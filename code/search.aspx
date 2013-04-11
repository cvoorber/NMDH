<%@ Page Title="" Language="C#" Theme="Theme1" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_area" Runat="Server">
    <div class="searchbox">
    <asp:Label ID="lbl_slabel" runat="server" Text="Enter search:" />
    <br />
    <asp:TextBox ID="txt_search" runat="server" CssClass="searchPageBox" />
    <br />
    <asp:Button ID="btn_search" runat="server" Text="Submit" OnClick="subSearch" CssClass="largerButton" />

    <asp:Panel ID="pnl_result" runat="server">
        <asp:Repeater ID="rpt_result" runat="server">
            <HeaderTemplate>
                <asp:Label ID="lbl" runat="server" Text="Results: " />
                <ol>
            </HeaderTemplate>
            <ItemTemplate>
                <li><asp:HyperLink ID="hl_result" runat="server" NavigateUrl='<%#Eval("url") %>' Text='<%#Eval("page_title") %>' /></li>
            </ItemTemplate>
            <FooterTemplate>
                </ol>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
    </div>
</asp:Content>
