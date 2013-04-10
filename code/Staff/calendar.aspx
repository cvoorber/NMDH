<%@ Page Language="C#" AutoEventWireup="true" CodeFile="calendar.aspx.cs" Inherits="calendar" MasterPageFile="~/subMaster1.master" %>
<%@ Register TagPrefix="Customized" Namespace="ilanaCustom" %>
<%@ Mastertype VirtualPath="~/Admin/subAdmin.master" %>

<asp:Content runat="server" ContentPlaceHolderID="l_sidebar">
    <asp:LoginStatus ID="lgs_admin" runat="server" CssClass="loginStatus" Font-Size="12pt" Height="30"  />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="r_content" Runat="Server">

<asp:ScriptManager ID="scr_main" runat="server" />

<!-- update panel is very slow... this indicates to the user that something is expected to happen shortly -->
<asp:UpdateProgress ID="udp_main" runat="server">
    <ProgressTemplate>
        <asp:Label ID="lbl_progress" runat="server" Text="please wait..." CssClass="process" />
    </ProgressTemplate>
</asp:UpdateProgress>

<!-- the custom control is made visible when the "new" button is clicked, using AJAX -->
<asp:UpdatePanel ID="udp_new" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btn_new" EventName="Click" /> 
    </Triggers>
    <ContentTemplate>
        <asp:Button ID="btn_new" runat="server" Text="New Event" OnClick="pnlShow" CausesValidation="false" CssClass="btn_new" />
        <asp:Panel ID="pnl_new" runat="server" Visible="false">  
            <Customized:eventClass ID="custom_events" runat="server" OnCustomEvent="subSubmit" /> 
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<!-- this update panel contains the calendar as well as a hidden panel that displays the events of one day when a day is selected -->
<asp:UpdatePanel ID="upd_calendar" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="cld_main" EventName="SelectionChanged" />
        <asp:AsyncPostBackTrigger ControlID="btn_close" EventName="Click" />
    </Triggers>
    <ContentTemplate>
    
        <asp:Calendar 
            ID="cld_main" 
            runat="server" 
            OnDayRender="subRender" 
            OnSelectionChanged="cld_main_SelectionChanged" 
            DayNameFormat="Full" 
            DayStyle-CssClass="calendarDay" 
            DayStyle-Height="70px" 
            DayStyle-Width="100px" 
            DayStyle-HorizontalAlign="left" />

        <!-- this panel is just a grey translucent background that disables the background -->
        <asp:Panel ID="pnl_day" runat="server" CssClass="display_events" Visible="false">
        </asp:Panel>

        <!-- contains the display of a day's events -->
        <asp:Panel ID="pnl_dayitems" runat="server" CssClass="display_event_items" Visible="false" >

            <!-- hide the day display -->
            <asp:Button ID="btn_close" runat="server" CssClass="btn_close" Text="Close" OnClick="hideDay" />

            <!-- list of that day's events -->
            <asp:Repeater ID="dtv_events" runat="server">
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
                
                    <tr><!-- displays as "Contact: John (Director of Operations) at john.doe@ndmh.com" where the email is a mailto link-->
                        <th><asp:Label ID="lbl_lcontact" runat="server" Text='Contact:' /></th>
                        <td><asp:Label ID="lbl_contact" runat="server" Text='<%#Eval("ndmh_staff_listing.sl_fname") %>' /> 
                        (<asp:Label ID="Label1" runat="server" Text='<%#Eval("ndmh_staff_listing.sl_position") %>' />)
                         at <a href='mailto:<%#Eval("ndmh_staff_listing.sl_email") %>' target="_blank"><%#Eval("ndmh_staff_listing.sl_email") %></a></td>
                    </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>