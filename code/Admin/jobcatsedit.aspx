<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobcatsedit.aspx.cs" Inherits="Admin_careersAdmin" %>

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

        <asp:Menu ID="mnu_career" runat="server" Orientation="Vertical">
            <Items>
                <asp:MenuItem Value="1" Text="Categories" />
                <asp:MenuItem Value="2" Text="Job Postings" />
                <asp:MenuItem Value="3" Text="Job Applications" />
            </Items>
        </asp:Menu>
        
        <asp:Panel ID="pnl_insert" runat="server">
            <asp:Label Text="Category Name: " runat="server" />
            <asp:TextBox ID="txt_catNameI" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_catNameI" runat="server" ControlToValidate="txt_catNameI" ErrorMessage="*required" ValidationGroup="insertgroup" />
            <br />
            <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="subInsert" ValidationGroup="insertgroup" />
        </asp:Panel>

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
                        <td><asp:Button ID="btn_edit" runat="server" Text="Edit" OnClick="subEdit" CommandArgument='<%#Eval("j_category_id") %>' /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" OnClick="subDelete" OnClientClick="return confirm('Are you sure?');" CommandArgument='<%#Eval("j_category_id") %>' /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </asp:Panel>    
        
        
        
        <asp:Panel ID="pnl_update" runat="server">
            <asp:DataList ID="dtl_update" runat="server" OnItemCommand="subUpdate">
                <ItemTemplate>
                    <asp:HiddenField ID="hdf_jcatID" runat="server" Value='<%#Eval("j_category_id") %>' />
                    <asp:Label ID="lbl_jid" runat="server" Text='<%# String.Format("Category ID: {0}",Eval("j_category_id")) %>' />
                    <br />
                    <asp:Label runat="server" Text="Category Name: " />
                    <asp:TextBox id="txt_update" runat="server" Text='<%#Bind("j_category_name") %>' />
                    <asp:RequiredFieldValidator ID="rfv_catname" runat="server" ControlToValidate="txt_update" ErrorMessage="*required" />
                    <br />
                    <asp:Button ID="btn_update" runat="server" CommandName="update" Text="Update" />
                    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CommandName="cancel" />
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>   
        <asp:Label ID="lbl_result" runat="server" />
    </div>
    </form>
</body>
</html>
