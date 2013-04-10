<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="virtual-tour.aspx.cs" Inherits="_Default" %>


<asp:Content ID="cnt_mainvirt" ContentPlaceHolderID="r_content" Runat="Server">

<iframe width="425" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.ca/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=Nipigon+District+Memorial+Hospital,+Hogan+Road,+Nipigon,+ON&amp;aq=0&amp;oq=nipigon+distri&amp;sll=49.303974,-84.738438&amp;sspn=15.343367,43.286133&amp;ie=UTF8&amp;hq=Nipigon+District+Memorial+Hospital,&amp;hnear=Hogan+Rd,+Nipigon,+Thunder+Bay+District,+Ontario&amp;t=m&amp;ll=49.025263,-88.262787&amp;spn=0.039397,0.072956&amp;z=13&amp;iwloc=A&amp;output=embed"></iframe><br /><small><a href="https://maps.google.ca/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=Nipigon+District+Memorial+Hospital,+Hogan+Road,+Nipigon,+ON&amp;aq=0&amp;oq=nipigon+distri&amp;sll=49.303974,-84.738438&amp;sspn=15.343367,43.286133&amp;ie=UTF8&amp;hq=Nipigon+District+Memorial+Hospital,&amp;hnear=Hogan+Rd,+Nipigon,+Thunder+Bay+District,+Ontario&amp;t=m&amp;ll=49.025263,-88.262787&amp;spn=0.039397,0.072956&amp;z=13&amp;iwloc=A" style="color:#0000FF;text-align:left">View Larger Map</a></small>
<br /><br />
<asp:ScriptManager ID="scm_vtour" runat="server" />
    
    <%--This panel will have the view to choose which floor you want to look at
    Will be hard coded--%> 
    
    <asp:Panel ID="pnl_floor" runat="server" CssClass="tour-box">
    <%--This is a list of floor options - will be a nav style vertical ul for now.--%>
        <asp:Label ID="lbl_floorheading" runat="server" Text="Which Floor Would You Like To Search Through?" />
    <div id="floor-list">
    <ul>
        <li><asp:LinkButton ID="lnb_fl1" runat="server" Text="Floor 1" OnCommand="subChooseFloor" CommandName="ChooseFloor"
         CommandArgument="floor1" /></li>
        <li><asp:LinkButton ID="lnb_fl2" runat="server" Text="Floor 2" CommandName="ChooseFloor"
         CommandArgument="floor2" OnCommand="subChooseFloor" /></li>
        <li><asp:LinkButton ID="lnb_fl3" runat="server" Text="Floor 3" CommandName="ChooseFloor"
         CommandArgument="floor3" OnCommand="subChooseFloor" /></li>
        <li><asp:LinkButton ID="lnb_flall" runat="server" Text="All Floors" CommandName="ChooseFloor"
         CommandArgument="floorall" OnCommand="subChooseFloor" /></li>
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
            CommandArgument='<%#Eval("dl_id") %>' runat="server" Font-Size="Large" /></li>
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
                Department Name: <asp:Label ID="lbl_pgname" runat="server" Text='<%#Eval("dl_name") %>' Font-Bold="true" /><br />
                Floor Number: <asp:Label ID="lbl_pgfloor" runat="server" Text='<%#Eval("dl_floor_no") %>' Font-Bold="true" /> <br />
                Room Number: <asp:Label ID="lbl_pgroom" runat="server" Text='<%#Eval("dl_room_no") %>' Font-Bold="true" /> <br />
                Phone Extension: <asp:Label ID="lbl_pgextension" runat="server" Text='<%#Eval("dl_extention") %>' Font-Bold="true" /><br />
                <asp:Image ID="img_pgimg" runat="server" AlternateText='<%#Eval("dl_img_alt") %>' ImageUrl='<%#Eval("dl_img_url") %>' /> <br />
                Description: <asp:Label ID="lbl_pgdesc" runat="server" Text='<%#Eval("dl_description") %>' BorderColor="Black"  />
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>

</asp:Content>

