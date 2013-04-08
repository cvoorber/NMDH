<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newPage.aspx.cs" MasterPageFile="~/SubMaster1.master" Inherits="newPage" %>
<%@ Mastertype VirtualPath="~/SubMaster1.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <asp:Label ID="lbl_head" runat="server" Text="Add a New Page" />

    <br />

    <asp:Label ID="lbl_type" runat="server" Text="Page Type: " />
    <asp:DropDownList ID="ddl_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="setType" />
    
    <br />

    <asp:Label ID="lbl_title" runat="server" Text="Page Title: " />
    <asp:TextBox ID="txt_title" runat="server" />
    
    <br />

    <asp:Label ID="lbl_content" runat="server" Text="Page Content: " />
    <asp:TextBox ID="txt_content" runat="server" TextMode="MultiLine" />

    <br />

    <asp:CheckBox ID="chk_publish" runat="server" Text="Publish Immediately" Checked="true" />

    <br />

    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="subSubmit" />

    <br /><br />

    <asp:Label ID="output" runat="server" />
    
</asp:Content>
