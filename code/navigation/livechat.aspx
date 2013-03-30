<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="livechat.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <asp:Label ID="lbl_chatstatus" runat="server" />
    <br />
    
    <asp:Label ID="lbl_nickname" runat="server" Text="Enter a nickname:" />
    <asp:TextBox ID="txt_nickname" runat="server" />
    <asp:Button ID="btn_launch" runat="server" Text="Launch Chat" OnClick="subLaunch" />

</asp:Content>

