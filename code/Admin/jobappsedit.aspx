<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobappsedit.aspx.cs" Inherits="Admin_jobappsedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="pnl_apps" runat="server" Visible="false">
           <asp:DataList ID="dtl_apps" runat="server" GridLines="Both">
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
                        <td><%#Eval("j_application_id") %></td>
                        <td><%#Eval("j_first_name") %></td>
                        <td><%#Eval("j_last_name") %></td>
                        <td><%#Eval("j_address") %></td>
                        <td><%#Eval("j_city") %></td>
                        <td><%#Eval("j_province") %></td>
                        <td><%#Eval("j_postal") %></td>
                        <td><%#Eval("j_phone") %></td>
                        <td><%#Eval("j_alt_phone") %></td>
                        <td><%#Eval("j_email") %></td>
                        <td><%#Eval("j_was_employee") %></td>
                        <td><%#Eval("j_is_eligible") %></td>
                        <td><%#Eval("j_of_age") %></td>
                        <td><%#Eval("j_was_convicted") %></td>
                        <td><%#Eval("j_id") %></td>
                        <td><%#Eval("j_resume") %></td>
                        <td><asp:Button ID="btn_update" runat="server" Text="Edit" CommandName="Edit" /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="subDelete" /></td>
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
