<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminCalendar.aspx.cs" Inherits="calendar" MasterPageFile="~/Admin/subAdmin.master" %>
<%@ Register TagPrefix="Customized" Namespace="ilanaCustom" %>
<%@ Mastertype VirtualPath="~/Admin/subAdmin.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">

<Customized:eventClass ID="custom_events" runat="server" OnCustomEvent="subSubmit" /> 


<asp:Repeater ID="dtv_events" runat="server">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("rb_title") %>' Font-Size="Larger" Font-Bold="true" CssClass="eventTable" />
    <table class="eventTable">
        <tr>
            <th><asp:Label ID="lbl_lstart" runat="server" Text='Time: ' /></th>
            <td><asp:Label ID="lbl_start" runat="server" Text='<%#Eval("rb_start", "{0:h:mm tt}") %>' /> to <asp:Label ID="lbl_end" runat="server" Text='<%#Eval("rb_end", "{0:h:mm tt}") %>' /></td>
        </tr>
                
        <tr>
            <th><asp:Label ID="lbl_ldesc" runat="server" Text='Details:' /></th>
            <td><asp:Label ID="lbl_desc" runat="server" Text='<%#Eval("rb_description") %>' /></td>
        </tr>
                
        <tr>
            <th><asp:Label ID="lbl_lcontact" runat="server" Text='Contact:' /></th>
            <td><asp:Label ID="lbl_contact" runat="server" Text='<%#Eval("ndmh_staff_listing.sl_fname") %>' /> 
            (<asp:Label ID="Label1" runat="server" Text='<%#Eval("ndmh_staff_listing.sl_position") %>' />)
                at <a href='mailto:<%#Eval("ndmh_staff_listing.sl_email") %>' target="_blank"><%#Eval("ndmh_staff_listing.sl_email") %></a></td>
        </tr>
        </table>
    </ItemTemplate>
</asp:Repeater>

</asp:Content>