<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobcatedit.aspx.cs" Inherits="Admin_careersAdmin" %>

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
        
        <asp:Panel ID="pnl_cats" runat="server">
            <asp:DataList ID="dtl_cats" runat="server" GridLines="Both">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Category ID</th>
                            <th>Category Name</th>
                            <th>Update</th>
                            <th>Delete</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("j_category_id") %></td>
                        <td><%#Eval("j_category_name") %></td>
                        <td><asp:Button ID="btn_update" runat="server" Text="Edit" CommandName="Edit" /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </asp:Panel>    
        
        
        
        <asp:Panel ID="pnl_update" runat="server">
        
        </asp:Panel>   
    </div>
    </form>
</body>
</html>
