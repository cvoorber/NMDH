<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="virtual-tour.aspx.cs" Inherits="_Default" %>

<asp:Content ID="cnt_headvirt" ContentPlaceHolderID="head" Runat="Server">
<%--Leave blank for now--%>
</asp:Content>

<asp:Content ID="cnt_mainvirt" ContentPlaceHolderID="content_area" Runat="Server">

<asp:ScriptManager ID="scm_vtour" runat="server" />
    
    <%--This panel will have the view to choose which floor you want to look at
    Will be hard coded--%> 
    
    <asp:Panel ID="pnl_floor" runat="server" CssClass="tour-box">
    <%--This is a list of floor options - will be a nav style vertical ul for now.--%>
        <asp:Label ID="lbl_floorheading" runat="server" Text="Which Floor Would You Like To Search Through?" />
    <div id="floor-list">
    <ul>
        <li><a href="#">Floor 1</a></li>
        <li><a href="#">Floor 2</a></li>
        <li><a href="#">Floor 3</a></li>
        <li><a href="#">All Floors</a></li>
    </ul>
    </div>
    </asp:Panel><!--/floor-list -->

    <%--This panel will have the list of the different departments that the user would be searching through--%>
    <%--Will use a repeater control, and data from the department listing table--%>
    <asp:Panel ID="pnl_deptchoose" runat="server" CssClass="tour-box" Visible="true">
        <asp:Repeater ID="rpt_deptchoose" runat="server">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
        <li> 
            <asp:LinkButton OnCommand="subChooseCommand" CommandName="PickDept" ID="lkb_deptname" Text='<%#Eval("dl_name") %>' 
            CommandArgument='<%#Eval("dl_id") %>' runat="server" /></li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
        

    </asp:Panel>

    <%--This panel shows the view of the department page--%>
    <%--Will use a repeater control, and data from the department listing table--%>
    <%--Initially, will just do a regular Select-> Where Linq statement .... but in order to get the
    Image, I will need to do a Linq statement that has an inner join -> see p. 970 of text--%>
    <asp:Panel ID="pnl_deptpage" runat="server" CssClass="tour-box" Visible="true">
        <asp:Repeater ID="rpt_deptpage" runat="server" >
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%#Eval("dl_name") %>' />
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>

</asp:Content>

