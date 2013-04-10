<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminCalendar.aspx.cs" Inherits="calendar" MasterPageFile="~/Admin/subAdmin.master" %>
<%@ Register TagPrefix="Customized" Namespace="ilanaCustom" %>
<%@ Mastertype VirtualPath="~/Admin/subAdmin.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">

<!-- custom control to add a new event to the calendar -->
<Customized:eventClass ID="custom_events" runat="server" OnCustomEvent="subSubmit" /> 

<!-- change the events being displayed based on their date -->
<asp:DropDownList ID="ddl_view" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subSort" />

<!-- display a list of the events with a button to view and/or delete each one -->
<asp:DataGrid ID="dg_all" runat="server" AutoGenerateColumns="false" OnItemCommand="subView" HeaderStyle-Font-Bold="true">
    <Columns>
        <asp:TemplateColumn HeaderText="Title" >
            <ItemTemplate>
                <%#Eval("rb_title") %>
            </ItemTemplate>
        </asp:TemplateColumn>
        
        <asp:TemplateColumn HeaderText="Date">
            <ItemTemplate>
                <%#Eval("rb_start", "{0:MMMM dd, yyyy}")%>
            </ItemTemplate>
        </asp:TemplateColumn>
        
        <asp:TemplateColumn HeaderText="Start">
            <ItemTemplate>
                <%#Eval("rb_start", "{0:h:mm tt}") %>
            </ItemTemplate>
        </asp:TemplateColumn>

        <asp:TemplateColumn HeaderText="End">
            <ItemTemplate>
                <%#Eval("rb_end", "{0:h:mm tt}")%>
            </ItemTemplate>
        </asp:TemplateColumn>
       
        <asp:TemplateColumn>
            <ItemTemplate>
                <asp:LinkButton ID="lb_view" runat="server" CommandArgument='<%#Eval("rb_id") %>' Text="View" CausesValidation="false" />                
            </ItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</asp:DataGrid>

<!-- this panel displays one event that is selected above, displays modally -->
<asp:Panel ID="pnl_day" runat="server" CssClass="display_events" Visible="false"></asp:Panel>

<!-- show the individual event selected -->
<asp:Panel ID="pnl_dayitems" runat="server" CssClass="display_event_items" Visible="false" >

    <!-- go back to all events -->
    <asp:Button ID="btn_close" runat="server" CssClass="btn_close" Text="Close" OnClick="hideDay" CausesValidation="false" />

    <!-- display the event -->
    <asp:Repeater ID="dtv_events" runat="server" OnItemCommand="subDelete">
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
            <tr>
                <asp:LinkButton ID="lb_delete" runat="server" Text="Delete" CommandArgument='<%#Eval("rb_id") %>' CausesValidation="false" OnClientClick="confirm('Are you sure you want to delete this event? This action cannot be undone.');" />
            </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
</asp:Panel>

</asp:Content>