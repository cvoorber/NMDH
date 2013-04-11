<%@ Page Title="" Language="C#" Theme="Theme1" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_area" Runat="Server">
    <div class="searchbox">
    <asp:Label ID="Label1" runat="server" Text="Enter search:" />
    <br />
    <asp:TextBox ID="TextBox1" runat="server" CssClass="searchPageBox" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="subSearch" CssClass="largerButton" />

    <asp:Panel ID="Panel1" runat="server">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
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

