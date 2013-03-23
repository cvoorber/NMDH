<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsblogCMS.aspx.cs" Inherits="Admin_newsblogCMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl_message" runat="server" />
        <br />
        <br />
        <asp:Label ID="lbl_insert" runat="server" Text="Insert an Article" Font-Bold="true" />
        <br />
        <asp:Label ID="lbl_titleI" runat="server" Text="Title" AssociatedControlID="txt_titleI" />
        <br />
        <asp:TextBox ID="txt_titleI" runat="server" />
        <br />
        <asp:Label ID="lbl_descI" runat="server" Text="Description" AssociatedControlID="txt_descI" />
        <br />
        <asp:TextBox ID="txt_descI" runat="server" />
        <br />
        <asp:Label ID="lbl_imageI" runat="server" Text="Image" AssociatedControlID="txt_imageI" />
        <br />
        <asp:TextBox ID="txt_imageI" runat="server" />
        <br />
        <asp:Label ID="lbl_contactidI" runat="server" Text="Contact ID" AssociatedControlID="txt_contactidI" />
        <br />
        <asp:TextBox ID="txt_contactidI" runat="server" />
        <br />
        <asp:Label ID="lbl_linkI" runat="server" Text="Link" AssociatedControlID="txt_linkI" />
        <br />
        <asp:TextBox ID="txt_linkI" runat="server" />
        <br />
        <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="subInsert" />
        <br />
        <hr />
        <br />
        <asp:DropDownList ID="ddl_main" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subChange" />
        <br />
        <br />

        <asp:ListView ID="lv_main" runat="server" OnItemCommand="subAdmin">
            <LayoutTemplate>
                <table cellpadding="3" cellspacing="5">
                    <thead>
                        <tr>
                            <th>Event/News Title</th>
                            <th>Image</th>
                            <th>Contact ID</th>
                            <th>Link</th>
                            <th>Description</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdf_idE" runat="server" Value='<%#Eval("n_id") %>' />
                        <asp:TextBox ID="txt_titleE" runat="server" Text='<%#Bind("n_title") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_imageE" runat="server" Text='<%#Bind("n_image") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_contactidE" runat="server" Text='<%#Bind("n_contact_id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_linkE" runat="server" Text='<%#Bind("n_link") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="txt_descE" runat="server" Text='<%#Bind("n_description") %>' TextMode="MultiLine" Columns="40" Rows="4" />
                    </td>
                    <tr>
                    <td>
                    </td>
                        <td>
                        <asp:LinkButton ID="lb_update" runat="server" Text="Update" CommandName="subUpdate" BackColor="LightGray" Font-Size="14" Style="padding:5px;" BorderWidth="1" BorderColor="Black" />
                    
                        <asp:LinkButton ID="lb_delete" runat="server" Text="Delete" CommandName="subDelete" OnClientClick="return confirm('Are you sure you want to delete this record?');" BackColor="LightGray" Font-Size="14" Style="padding:5px;" BorderWidth="1" BorderColor="Black" />
                    </td>
                    </tr>
            </ItemTemplate>
        </asp:ListView>

    </div>
    </form>
</body>
</html>
