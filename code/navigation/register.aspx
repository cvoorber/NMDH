<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="navigation_register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" Runat="Server">
    <asp:CreateUserWizard ID="cuwMain" runat="server" ContinueDestinationPageUrl="~/navigation/login.aspx" />
</asp:Content>

