<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newPage.aspx.cs" MasterPageFile="~/Admin/subAdmin.master" Inherits="newPage" %>
<%@ Mastertype VirtualPath="~/Admin/subAdmin.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">

<!-- prepare the ajax toolkit -->
<AJAX:ToolkitScriptManager runat="server" />

<!-- label indicates success or failure -->
<asp:Label ID="output" runat="server" />
<br />

<!-- show the insert page panel -->
<asp:LinkButton ID="lbn_new" runat="server" Text="New Page" OnClick="showNew" />

<!-- panel for new page -->
<asp:Panel ID="pnl_new" runat="server" Visible="false" CssClass="pagePanel">
    <asp:Label ID="lbl_head" runat="server" Text="Add a New Page" Font-Bold="true" Font-Size="Large" />
<table>
    <tr>
        <td><asp:Label ID="lbl_type" runat="server" Text="Page Type: " /></td>
        <td>
            <!-- select the type of page being entered, this is required -->
            <asp:DropDownList ID="ddl_type" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_typeI" runat="server" ControlToValidate="ddl_type" InitialValue="Select" ValidationGroup="insert" Text="*required" ForeColor="Red" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td><asp:Label ID="lbl_title" runat="server" Text="Page Title: " /></td>
        <td>
            <!-- text title, required -->
            <asp:TextBox ID="txt_title" runat="server" MaxLength="23" />
            <asp:RequiredFieldValidator ID="rfv_titleI" runat="server" ControlToValidate="txt_title" ValidationGroup="insert" Text="*required" ForeColor="Red" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="rev_titleI" runat="server" ControlToValidate="txt_title" ValidationExpression="^[a-zA-Z '-]{1,23}$" ValidationGroup="insert" Text="*must contain letters only and be less than 23 characters" ForeColor="Red" Display="Dynamic" />
        </td>
    </tr>    
    <tr>
        <td><asp:Label ID="lbl_content" runat="server" Text="Page Content: " /></td>
        <td><asp:RequiredFieldValidator ID="rfv_contentI" runat="server" ControlToValidate="txt_content" ValidationGroup="insert" Text="*required" ForeColor="Red" Display="Dynamic" /> </td>
    </tr>
    <tr>
        <td></td>
        <td class="pagecontentClass">
            <!-- content textbox, required and allows for styling with the help of the HtmlEditorExtender -->
            <AJAX:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txt_content" EnableSanitization="false" />
            <asp:TextBox ID="txt_content" runat="server" TextMode="MultiLine" Width="400" Height="200" CssClass="editContent" />
        </td>
    </tr>
</table>
    <!-- is the page ready for public display? -->
    <asp:CheckBox ID="chk_publish" runat="server" Text="Publish Immediately" Checked="true" />
    <br />
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="subSubmit" ValidationGroup="insert" />
    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="subCancel" CausesValidation="false" />
</asp:Panel>

<!-- display a list of page titles, with their respective section and publish status -->
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

<!-- display one page to be edited/deleted -->
<asp:Panel ID="pnl_edit" runat="server" Visible="false" CssClass="pagePanel">
    <asp:DetailsView 
    ID="dtv_edit" 
    runat="server" 
    AutoGenerateRows="false" 
    DefaultMode="Edit" 
    OnItemCommand="subChange" 
    OnModeChanging="modeChange">
        <Fields>
            <asp:TemplateField>
                <EditItemTemplate>
                <table>
                    <tr>
                        <td>Published:</td>
                        <!-- is the page available to public? -->
                        <td><asp:CheckBox runat="server" ID="chk_activeE" Checked='<%# Bind("gp_active") %>' /></td>
                    </tr>
                    <tr>
                        <td>Title:</td>
                        <td>
                            <!-- title is required and must contain only strings -->
                            <asp:TextBox runat="server" ID="txt_title" Text='<%# Bind("gp_title") %>' MaxLength="23" />
                            <asp:RequiredFieldValidator ID="rfv_titleE" runat="server" ControlToValidate="txt_title" ValidationGroup="edit" Text="*required" ForeColor="Red" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="rev_titleE" runat="server" ControlToValidate="txt_title" ValidationExpression="^[a-zA-Z '-]{1,23}$" ValidationGroup="edit" Text="*must contain letters only and be less than 23 characters" ForeColor="Red" Display="Dynamic" />
                        </td>
                    </tr>
                    <tr>
                        <td>Section:</td>
                        <td>
                            <!-- drop down for page section, also required -->
                            <asp:DropDownList runat="server" ID="ddl_section" />
                            <asp:RequiredFieldValidator ID="rfv_typeE" runat="server" ControlToValidate="ddl_section" InitialValue="Select" ValidationGroup="edit" Text="*required" ForeColor="Red" Display="Dynamic" />
                        </td>
                    </tr>
                    <tr><td>Content:</td></tr>
                </table>
                    <!-- content section is required and contains an HTML Extender -->
                    <AJAX:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txt_content" EnableSanitization="false" />
                    <asp:TextBox runat="server" ID="txt_content" Text='<%# Bind("gp_content") %>' TextMode="MultiLine" CssClass="editContent" />
                    <asp:RequiredFieldValidator ID="rfv_contentE" runat="server" ControlToValidate="txt_content" ValidationGroup="edit" Text="*required" ForeColor="Red" Display="Dynamic" />
                    <br /><br />
                <asp:Button runat="server" ID="btn_save" Text="Save" CommandArgument='<%# Bind("gp_id") %>' CommandName="save" ValidationGroup="edit" />
                <asp:Button runat="server" ID="btn_cancel" Text="Cancel" CommandArgument='<%# Bind("gp_id") %>' CommandName="cancel" CausesValidation="false" />
                <asp:Button runat="server" ID="btn_delete" Text="Delete" CommandArgument='<%# Bind("gp_id") %>' CommandName="delet" OnClientClick="confirm('Are you sure you want to delete this page? This action cannot be undone!');" CausesValidation="false" />
                </EditItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
</asp:Panel>
</asp:Content>
