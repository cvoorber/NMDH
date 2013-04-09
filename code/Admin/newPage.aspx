<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newPage.aspx.cs" MasterPageFile="~/Admin/subAdmin.master" Inherits="newPage" ValidateRequest="false" %>
<%@ Mastertype VirtualPath="~/Admin/subAdmin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
<asp:Label ID="output" runat="server" />
<br />
<asp:LinkButton ID="lbn_new" runat="server" Text="New Page" OnClick="showNew" />

<asp:Panel ID="pnl_new" runat="server" Visible="false" CssClass="pagePanel">
    <asp:Label ID="lbl_head" runat="server" Text="Add a New Page" Font-Bold="true" Font-Size="Large" />
<table>
    <tr>
        <td><asp:Label ID="lbl_type" runat="server" Text="Page Type: " /></td>
        <td><asp:DropDownList ID="ddl_type" runat="server" /></td>
    </tr>
    <tr>
        <td><asp:Label ID="lbl_title" runat="server" Text="Page Title: " /></td>
        <td><asp:TextBox ID="txt_title" runat="server" /></td>
    </tr>    
    <tr>
        <td><asp:Label ID="lbl_content" runat="server" Text="Page Content: " /></td>
        <td><asp:TextBox ID="txt_content" runat="server" TextMode="MultiLine" /></td>
    </tr>
</table>
    <asp:CheckBox ID="chk_publish" runat="server" Text="Publish Immediately" Checked="true" />
    <br />
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="subSubmit" />
    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="subCancel" />
</asp:Panel>

<asp:Panel ID="pnl_all" runat="server" CssClass="pagePanel">
    <asp:Repeater runat="server" ID="rpt_all" OnItemCommand="subEdit">
        <HeaderTemplate>
            <table id="pagesTable" rules="rows">
                <tr>
                    <th>Page Title</th>
                    <th>Section</th>
                    <th>Published</th>
                    <th></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr>
            <td>
                <asp:Label runat="server" ID="lbl_title" Text='<%# Eval("gp_title") %>' />
            </td>
            <td>
                <asp:Label runat="server" ID="lbl_section" Text='<%# Eval("gp_section") %>' />
            </td>
            <td>
                <asp:CheckBox runat="server" ID="chk_active" Checked='<%# Eval("gp_active") %>' Enabled="false" />
            </td>
            <td>
                <asp:LinkButton runat="server" ID="btn_edit" Text="Edit" CommandArgument='<%# Eval("gp_id") %>' />    
            </td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Panel>

<asp:Panel ID="pnl_edit" runat="server" Visible="false" CssClass="pagePanel">
    <asp:DetailsView ID="dtv_edit" runat="server" AutoGenerateRows="false" DefaultMode="Edit" OnItemCommand="subChange" OnModeChanging="modeChange">
        <Fields>
            <asp:TemplateField>
                <EditItemTemplate>
                <table>
                    <tr>
                        <td>Active:</td>
                        <td><asp:CheckBox runat="server" ID="chk_activeE" Checked='<%# Bind("gp_active") %>' /></td>
                    </tr>
                    <tr>
                        <td>Title:</td>
                        <td><asp:TextBox runat="server" ID="txt_title" Text='<%# Bind("gp_title") %>' /></td>
                    </tr>
                    <tr>
                        <td>Section:</td>
                        <td><asp:DropDownList runat="server" ID="ddl_section" /></td>
                    </tr>
                    <tr><td>Content:</td></tr>
                </table>
                    <asp:TextBox runat="server" ID="txt_content" Text='<%# Bind("gp_content") %>' TextMode="MultiLine" CssClass="editContent" />
                <asp:Button runat="server" ID="btn_save" Text="Save" CommandArgument='<%# Bind("gp_id") %>' CommandName="save" />
                <asp:Button runat="server" ID="btn_cancel" Text="Cancel" CommandArgument='<%# Bind("gp_id") %>' CommandName="cancel" CausesValidation="false" />
                <asp:Button runat="server" ID="btn_delete" Text="Delete" CommandArgument='<%# Bind("gp_id") %>' CommandName="delet" OnClientClick="confirm('Are you sure you want to delete this page? This action cannot be undone!');" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
</asp:Panel>
</asp:Content>
