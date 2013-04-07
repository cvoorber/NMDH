<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="admindonations.aspx.cs" Inherits="Admindonations" %>

<asp:Content ID="cnt_addonhead" ContentPlaceHolderID="l_sidebar" Runat="Server">
</asp:Content>
<asp:Content ID="cnt_addonmain" ContentPlaceHolderID="r_content" Runat="Server">
    
    <asp:ListView ID="lsv_main" runat="server" ItemPlaceholderID="plh_main"
     OnItemEditing="subItemEdit" OnItemInserting="subItemInsert" OnItemDeleting="subItemDelete" InsertItemPosition="LastItem">
    <LayoutTemplate>
        <table>
            <thead>
            <tr>
                <td>Blank</td><td>Content</td>
                <td><asp:LinkButton ID="lkb_getedit" runat="server" Text="Insert" CommandName="Insert" /></td>
               
            </tr>
            </thead>
            <tbody>
                <asp:PlaceHolder ID="plh_main" runat="server" />
            </tbody>
        </table>
    </LayoutTemplate>

    <ItemTemplate>
        <tr>
            <td>Item Template</td><td><asp:LinkButton ID="lkb_getedit" runat="server" Text="Edit" CommandName="Edit" /></td>
             <td><asp:LinkButton ID="lkb_delete" runat="server" Text="Delete" CommandName="Delete" /></td>
        </tr>
    </ItemTemplate>

    <EditItemTemplate>
        <tr>
            <td>Edit Template</td>
        </tr>
    
    </EditItemTemplate>

    <InsertItemTemplate>
        <tr>
            <td>Insert Template</td><td><asp:LinkButton ID="lkb_getedit" runat="server" Text="Insert" CommandName="Insert" /></td>
        </tr>
    </InsertItemTemplate>
    
    </asp:ListView>

</asp:Content>

