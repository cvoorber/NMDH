<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="navigation_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" Runat="Server">
    <asp:Login ID="logMain" runat="server" DestinationPageUrl="~/navigation/giftshop.aspx" CreateUserText="Register" CreateUserUrl="~/navigation/register.aspx" />
</asp:Content>
