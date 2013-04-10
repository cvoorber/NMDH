<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="navigation_login" %>


<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <asp:Login ID="logMain" FailureText="Login attempt unsuccessful" FailureAction="RedirectToLoginPage" runat="server" DestinationPageUrl="~/Admin/newsblogCMS.aspx" />
</asp:Content>
