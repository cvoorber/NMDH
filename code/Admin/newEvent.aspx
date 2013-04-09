<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newEvent.aspx.cs" Inherits="newEvent" MasterPageFile="~/SubMaster1.master" %>
<%@ Register TagPrefix="Customized" Namespace="ilanaCustom" %>
<%@ Mastertype VirtualPath="~/SubMaster1.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">

<asp:ScriptManager ID="scr_main" runat="server" />
<asp:UpdateProgress ID="udp_main" runat="server">
    <ProgressTemplate>
        <asp:Label ID="lbl_progress" runat="server" Text="please wait..." CssClass="process" />
    </ProgressTemplate>
</asp:UpdateProgress>


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


<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="cld_main" EventName="SelectionChanged" />
        <asp:AsyncPostBackTrigger ControlID="btn_close" EventName="Click" />
    </Triggers>
    <ContentTemplate>
    
        <asp:Calendar ID="cld_main" runat="server" OnDayRender="subRender" OnSelectionChanged="cld_main_SelectionChanged"
            OnVisibleMonthChanged="cld_main_VisibleMonthChanged" DayNameFormat="Full" DayStyle-CssClass="calendarDay" DayStyle-Height="70px" DayStyle-Width="100px" DayStyle-HorizontalAlign="left" />

        <asp:Panel ID="pnl_day" runat="server" CssClass="display_events" Visible="false">
        </asp:Panel>
        <asp:Panel ID="pnl_dayitems" runat="server" CssClass="display_event_items" Visible="false" >
            <asp:Button ID="btn_close" runat="server" CssClass="btn_close" Text="Close" OnClick="hideDay" />
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
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>