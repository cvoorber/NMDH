<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="adminfaqs.aspx.cs" Inherits="_Default" %>

<asp:Content ID="cnt_admfaqhead" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
   table tr, table td
    {
        border: 1px solid black;
    }
    
</style>
</asp:Content>
<asp:Content ID="cnt_admfaqmain" ContentPlaceHolderID="content_area" Runat="Server">
    <asp:Repeater ID="rpt_faqadm" runat="server">
     <%--Include Header, Item, Insert, and Edit--%>
    <HeaderTemplate>
      <table >
        <tr>
            <th>
                <asp:Label ID="lbl_idhead" runat="server" Text="ID" />
            </th>
            <th>
                <asp:Label ID="lbl_titlehead" runat="server" Text="FAQ Title" />
            </th>
            <th>
                <asp:Label ID="lbl_contenthead" runat="server" Text="FAQ Content" />
            </th>
            <th>
                <asp:Label ID="lbl_ophead" runat="server" Text="Operations" />
            </th>
            <th>
                <asp:Button ID="btn_faqinsert" runat="server" Text="Insert New Article" CommandName="Insert" 
                OnCommand="subInsert" /> 
            </th>

        </tr>
    </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="lbl_id" runat="server" Text='<%#Eval("ndmh_faq_id") %>' />
                </td>
                <td>
                    <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("ndmh_faq_title") %>' />
                </td>
                <td>
                    <asp:Label ID="lbl_content" runat="server" Text='<%#Eval("ndmh_content") %>' />
                </td>
                <td>
                    <asp:Button ID="btn_edit" runat="server" Text="Edit"  CommandName="Edit" OnCommand="subEdit" />
                    <asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" OnCommand="subDelete" />
                </td>
            </tr>
            </ItemTemplate>
         <FooterTemplate></table></FooterTemplate>
          </asp:Repeater>
    
    <%--This panel gets triggered when an insert is desired to be performed--%>
    <asp:Panel ID="pnl_insert" runat="server" Visible="false">
        <asp:Repeater ID="rpt_insert" runat="server">
        <HeaderTemplate>
        <table>
        </HeaderTemplate>
        <ItemTemplate>
             
                <tr>
                    <td><asp:Label ID="lbl_etitle" runat="server" Text="FAQ Title" /> </td>
                    <td><asp:TextBox ID="txt_etitle" runat="server"   /></td>
                </tr>
                <%--Remember to add in the Text editor AJAX extender--%>
                <<tr>
                    <td><asp:Label ID="lbl_econtent" runat="server" Text="FAQ Content" /> </td>
                    <td><asp:TextBox ID="txt_econtent" runat="server"   /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_esave" runat="server" Text="Save Changes" />  
                    </td>
                    <td>
                        <asp:Button ID="btn_ecancel" runat="server" Text="Cancel" /> 
                    </td>
                </tr>
                </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

    <%--This panel is triggered when an edit is desired--%>
    <asp:Panel ID="pnl_edit" runat="server" Visible="false">
        <asp:Repeater ID="rpt_edit" runat="server">
        <HeaderTemplate>
        <table>
        </HeaderTemplate>
        <ItemTemplate>
             <tr>
                    <td><asp:Label ID="lbl_eid" runat="server" Text="FAQ ID" /> </td>
                    <td><asp:Label ID="lbl_eid2" runat="server" Text='<%#Eval("ndmh_faq_id") %>'  /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lbl_etitle" runat="server" Text="FAQ Title" /> </td>
                    <td><asp:TextBox ID="txt_etitle" runat="server" Text='<%#Eval("ndmh_faq_title") %>'  /></td>
                </tr>
                <%--Remember to add in the Text editor AJAX extender--%>
                <<tr>
                    <td><asp:Label ID="lbl_econtent" runat="server" Text="FAQ Content" /> </td>
                    <td><asp:TextBox ID="txt_econtent" runat="server" Text='<%#Eval("ndmh_faq_content") %>'  /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_esave" runat="server" Text="Save Changes" />  
                    </td>
                    <td>
                        <asp:Button ID="btn_ecancel" runat="server" Text="Cancel" /> 
                    </td>
                </tr>
                </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

   


</asp:Content>

