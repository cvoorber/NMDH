<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/subAdmin.master" AutoEventWireup="true" CodeFile="searchadmin.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">

    <%-- panel to insert new page info --%>
    <asp:Panel ID="pnl_insert" runat="server">
        <asp:Label ID="lbl_pagetitleI" Text="Page Title: " runat="server" />
        <asp:TextBox ID="txt_pagetitleI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_pagetitleI" runat="server" ControlToValidate="txt_pagetitleI" ErrorMessage="*required" ValidationGroup="insertgroup" />
        <br />
        <asp:Label ID="lbl_keywordsI" runat="server" Text="Keywords (separated by commas): " />
        <asp:TextBox ID="txt_keywordsI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_keywordsI" runat="server" ControlToValidate="txt_keywordsI" ErrorMessage="*required" ValidationGroup="insertgroup" />
        <br />
        <asp:Label ID="lbl_urlI" runat="server" Text="URL: " />
        <asp:TextBox ID="txt_urlI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_urlI" runat="server" ControlToValidate="txt_urlI" ErrorMessage="*required" ValidationGroup="insertgroup" />
        <br />
        <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="subInsert" ValidationGroup="insertgroup" />
        </asp:Panel>
    <asp:Label ID="lbl_search" runat="server" Text="Search Page Keywords" />

    <%-- panel with repeater that shows all keyword records --%>
    <asp:Panel ID="pnl_keys" runat="server">
        <asp:Repeater ID="rpt_keys" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td>Keyword ID</td>
                        <td>Page Title</td>
                        <td>Keywords</td>
                        <td>URL</td>
                        <td>Edit</td>
                        <td>Delete</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td><%#Eval("keyword_id") %></td>
                        <td><%#Eval("page_title") %></td>
                        <td><%#Eval("keywords") %></td>
                        <td><%#Eval("url") %></td>
                        <td><asp:Button ID="btn_edit" runat="server" Text="Edit" OnClick="subEdit" CommandArgument='<%#Eval("keyword_id") %>' /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Edit" OnClick="subDelete"  OnClientClick="return confirm('Are you sure?');" CommandArgument='<%#Eval("keyword_id") %>' /></td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

    <%-- panel that displays update options for edit click --%>
    <asp:Panel ID="pnl_update" runat="server">
        <asp:Repeater ID="rpt_update" runat="server" OnItemCommand="subUpdate">
            <ItemTemplate>
                <asp:HiddenField ID="hdf_keywordID" runat="server" Value='<%#Eval("keyword_id") %>' />
                <asp:Label ID="lbl_keywordU" runat="server" Text='<%# String.Format("Category ID: {0}",Eval("keyword_id")) %>' />
                <br />
                <asp:Label ID="lbl_pagetitleU" runat="server" Text="Page Title: " />
                <asp:TextBox ID="txt_pagetitleU" runat="server" Text='<%#Bind("page_title") %>' />
                <asp:RequiredFieldValidator ID="rfv_pagetitleU" runat="server" ControlToValidate="txt_pagetitleU" ErrorMessage="*required" />
                <br />
                <asp:Label ID="lbl_keywordsU" runat="server" Text="Keywords: " />
                <asp:TextBox ID="txt_keywordsU" runat="server" TextMode="MultiLine" Text='<%#Bind("keywords") %>' />
                <asp:RequiredFieldValidator ID="rfv_keywordsU" runat="server" ControlToValidate="txt_keywordsU" ErrorMessage="*required" />
                <br />
                <asp:Label ID="lbl_urlU" runat="server" Text="URL: " />
                <asp:TextBox ID="txt_urlU" runat="server" Text='<%#Bind("url") %>' />
                <asp:RequiredFieldValidator ID="rfv_urlU" runat="server" ControlToValidate="txt_urlU" ErrorMessage="*required" />
                <br />
                <asp:Button ID="btn_update" runat="server" CommandName="update" Text="Update" />
                <asp:Button ID="btn_cancel" runat="server" CommandName="cancel" Text="Cancel" />
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    <asp:Label ID="lbl_result" runat="server" />
</asp:Content>

