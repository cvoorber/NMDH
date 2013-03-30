<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobpostsedit.aspx.cs" Inherits="Admin_jobpostsedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div
        <asp:Panel ID="pnl_jobs" runat="server" Visible="false">
            <asp:DataList ID="dtl_jobs" runat="server" GridLines="Both">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Job ID</th>
                            <th>Title</th>
                            <th>Description</th>
                            <th>Requirements</th>
                            <th>Post Date</th>
                            <th>Expiry Date</th>
                            <th>Category ID</th>
                            <th>Update</th>
                            <th>Delete</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("j_id") %></td>
                        <td><%#Eval("j_title") %></td>
                        <td><%#Eval("j_description") %></td>
                        <td><%#Eval("j_requirements") %></td>
                        <td><%#Eval("j_posted_date","{0:MM/dd/yyyy}") %></td>
                        <td><%#Eval("j_expires","{0:MM/dd/yyyy}") %></td>
                        <td><%#Eval("j_category_id") %></td>
                        <td><asp:Button ID="btn_update" runat="server" Text="Edit" CommandName="Edit" /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </asp:Panel>   
    
    </div>
    </form>
</body>
</html>
