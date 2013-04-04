﻿<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="adminfaqs.aspx.cs" Inherits="_Default" %>

<asp:Content ID="cnt_admfaqhead" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
   table tr, table td, table th
    {
        border: 1px solid black;
        padding: 15px;
    }
    
    
</style>
</asp:Content>
<asp:Content ID="cnt_admfaqmain" ContentPlaceHolderID="content_area" Runat="Server">
    <asp:Panel ID="pnl_faqadm" runat="server">
    <asp:Repeater ID="rpt_faqadm" runat="server" OnItemDataBound="keyListBind">
     <%--Include Header, Item, Insert, and Edit--%>
    <HeaderTemplate>
    <asp:Button ID="Button1" runat="server" Text="Insert New Article" CommandName="Insert" 
                OnCommand="subInsert" /> 
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
                <asp:Label ID="lbl_keywordshead" runat="server" Text="Search Keywords" />
            </th>
            <th>
                <asp:Label ID="lbl_ophead" runat="server" Text="Operations" />
            </th>

        </tr>
    </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="lbl_id" runat="server" Text='<%#Eval("ndmh_faq_id") %>' />
                    <%--This hidden value field will be used to pass parameter to the child repeater that will load the keyword list--%>
                     <asp:HiddenField ID="hdf_childid" runat="server" Value='<%#Eval("ndmh_faq_id") %>' />
                </td>
                <td>
                    <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("ndmh_faq_title") %>' />
                </td>
                <td>
                    <asp:Label ID="lbl_content" runat="server" Text='<%#Eval("ndmh_content") %>' />
                </td>
                <td>
                <%--Did a child repeater here in order to display an unordered list of keywords--%>
                <asp:Repeater ID="rpt_keylist" runat="server">
                <HeaderTemplate>
                    <ul style="list-style-type: circle; margin-left: 10px; ">
                </HeaderTemplate>
                <ItemTemplate>
                    <li><asp:Label runat="server" ID="lbl_keylist" Text='<%#Eval("faq_keyword") %>' /></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
                    </asp:Repeater>
                </td>
                <td>
                    <asp:Button ID="btn_edit" runat="server" Text="Edit"  CommandName="Edit" OnCommand="subEdit"
                     CommandArgument='<%#Eval("ndmh_faq_id") %>' />
                    <asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" OnCommand="subDelete" 
                    OnClientClick="return confirm('Are you sure you want to delete this FAQ?');" CommandArgument='<%#Eval("ndmh_faq_id") %>'  />
                </td>
                </td>
            </tr>
            </ItemTemplate>
         <FooterTemplate></table></FooterTemplate>
          </asp:Repeater>
          </asp:Panel>
    
    <%--This panel gets triggered when an insert is desired to be performed--%>
    <asp:Panel ID="pnl_insert" runat="server" Visible="false">
    Insert a New FAQ Record Below
         <table>
                <tr>
                    <td><asp:Label ID="lbl_ititle" runat="server" Text="FAQ Title" /> </td>
                    <td><asp:TextBox ID="txt_ititle" runat="server"   /></td>
                </tr>
                <!-- Remember to add in the Text editor AJAX extender-->
                <tr>
                    <td><asp:Label ID="lbl_icontent" runat="server" Text="FAQ Content" /> </td>
                    <td><asp:TextBox ID="txt_icontent" runat="server"   /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_isave" runat="server" Text="Create New FAQ" OnCommand="subInsPanel"
                        CommandName="Create" />  
                    </td>
                    <td>
                        <asp:Button ID="btn_icancel" runat="server" Text="Cancel" OnCommand="subInsPanel" CommandName="Cancel" /> 
                    </td>
                </tr>
                </table>
        
    </asp:Panel>

    <%--This panel is triggered when an edit is desired--%>
    <asp:Panel ID="pnl_edit" runat="server" Visible="false">
    Edit Your FAQ Record Below
        <asp:Repeater ID="rpt_edit" runat="server" OnItemCommand="subEdit">
        <HeaderTemplate>
        <table>
        </HeaderTemplate>
        <ItemTemplate>
             <tr>
                    <td><asp:Label ID="lbl_eid" runat="server" Text="FAQ ID" /> </td>
                    <td><asp:Label ID="lbl_eid2" runat="server" Text='<%#Eval("ndmh_faq_id") %>'  /></td>
                 <asp:HiddenField ID="hdf_eid" runat="server" Value='<%#Eval("ndmh_faq_id") %>' />
                </tr>
                <tr>
                    <td><asp:Label ID="lbl_etitle" runat="server" Text="FAQ Title" /> </td>
                    <td><asp:TextBox ID="txt_etitle" runat="server" Text='<%#Eval("ndmh_faq_title") %>'  /></td>
                </tr>
                <%--Remember to add in the Text editor AJAX extender--%>
                <<tr>
                    <td><asp:Label ID="lbl_econtent" runat="server" Text="FAQ Content" /> </td>
                    <td><asp:TextBox ID="txt_econtent" runat="server" Text='<%#Eval("ndmh_content") %>'  /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btn_esave" runat="server" Text="Save Changes" 
                        CommandName="SaveEdit" />  
                    </td>
                    <td>
                        <asp:Button ID="btn_ecancel" runat="server" Text="Cancel" CommandName="CancelEdit" /> 
                    </td>
                </tr>
                </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

    <asp:Label ID="lbl_execmess" runat="server"  />


</asp:Content>

