<%@ Page Language="C#" AutoEventWireup="true" CodeFile="careersAdmin.aspx.cs" Inherits="Admin_careersAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl_title" runat="server" Text="Careers" />
        <br /><br />

        <asp:Menu ID="mnu_career" runat="server" OnMenuItemClick="subShowSection" Orientation="Vertical">
            <Items>
                <asp:MenuItem Value="1" Text="Categories" />
                <asp:MenuItem Value="2" Text="Job Postings" />
                <asp:MenuItem Value="3" Text="Job Applications" />
            </Items>
        </asp:Menu>
        
        <asp:Panel ID="pnl_cat" runat="server" Visible="false">
            
        </asp:Panel>    
        
        <asp:Panel ID="pnl_posts" runat="server" Visible="false">
            
        </asp:Panel>   
        <asp:Panel ID="pnl_apps" runat="server" Visible="false">
            
        </asp:Panel>   
    </div>
    </form>
</body>
</html>
