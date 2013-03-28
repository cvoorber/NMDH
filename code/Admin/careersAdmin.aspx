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
        
        <asp:Panel ID="pnl_cats" runat="server">
            <asp:DataList ID="dtl_cats" runat="server">
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
                        <td><asp:Button ID="btn_update" runat="server" Text="Update" /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </asp:Panel>    
        
        <asp:Panel ID="pnl_jobs" runat="server" Visible="false">
            <asp:DataList ID="dtl_jobs" runat="server">
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
                        <td><asp:Button ID="btn_update" runat="server" Text="Update" /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </asp:Panel>   
        <asp:Panel ID="pnl_apps" runat="server" Visible="false">
           <asp:DataList ID="dtl_apps" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Application ID</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Address</th>
                            <th>City</th>
                            <th>Province</th>
                            <th>Postal Code</th>
                            <th>Phone</th>
                            <th>Alt. Phone</th>
                            <th>Email</th>
                            <th>Is/Was Employee</th>
                            <th>Can Work in Canada</th>
                            <th>18 and Over</th>
                            <th>Convicted of Felony</th>
                            <th>Job ID</th>
                            <th>Resume File</th>
                            <th>Update</th>
                            <th>Delete</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>Application ID</td>
                        <td>First Name</td>
                        <td>Last Name</td>
                        <td>Address</td>
                        <td>City</td>
                        <td>Province</td>
                        <td>Postal Code</td>
                        <td>Phone</td>
                        <td>Alt. Phone</td>
                        <td>Email</td>
                        <td>Is/Was Employee</td>
                        <td>Can Work in Canada</td>
                        <td>18 and Over</td>
                        <td>Convicted of Felony</td>
                        <td>Job ID</td>
                        <td>Resume File</td>
                        <td><asp:Button ID="btn_update" runat="server" Text="Update" /></td>
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
