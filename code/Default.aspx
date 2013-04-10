<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">

    <%-- Wait Time Estimator --%>
    <aside id="waitTime">
        <asp:Label ID="ttl_estimate" runat="server" Text="E.R. Wait Estimator" SkinID="waitTitle" />
        <br /><br />
        <asp:DataList ID="dtl_main" runat="server">
            <ItemTemplate>
                <asp:Label ID="ttl_estimate" runat="server" Text="Estimation:" SkinID="waitLabel" />
                <asp:Label ID="lbl_estimate" runat="server" Text='<%#Eval("w_estimate") %>' SkinID="waitResults" />
                <asp:Label ID="lbl_details" runat="server" Text=" hours" SkinID="waitResults" />
                <br />
                <asp:Label ID="ttl_update" runat="server" Text="Last Update:" SkinID="waitLabel" />
                <asp:Label ID="lbl_update" runat="server" Text='<%#Eval("w_updated", "{0:t}") %>' SkinID="waitResults" />
                <br /><br />
            </ItemTemplate>
        </asp:DataList>
        <asp:Button ID="btn_show" runat="server" Text="Display/Refresh" OnClick="subUpdate" Font-Size="11" />
    </aside><%-- end "waitTime" aside --%>

    <br />
    <br />
    <h1>Find Us!</h1>
    <iframe width="210" height="210" style="margin:9px;border:1px solid black;" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.ca/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=Nipigon+District+Memorial+Hospital,+125+Hogan+Road,+Nipigon,+ON&amp;aq=0&amp;oq=nipigon&amp;sll=43.656877,-79.32085&amp;sspn=0.531548,1.352692&amp;ie=UTF8&amp;hq=Nipigon+District+Memorial+Hospital,&amp;hnear=Hogan+Rd,+Nipigon,+Thunder+Bay+District,+Ontario&amp;t=m&amp;ll=49.013217,-88.263474&amp;spn=0.028148,0.043087&amp;z=13&amp;iwloc=A&amp;output=embed"></iframe><br /><small><a href="https://maps.google.ca/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=Nipigon+District+Memorial+Hospital,+125+Hogan+Road,+Nipigon,+ON&amp;aq=0&amp;oq=nipigon&amp;sll=43.656877,-79.32085&amp;sspn=0.531548,1.352692&amp;ie=UTF8&amp;hq=Nipigon+District+Memorial+Hospital,&amp;hnear=Hogan+Rd,+Nipigon,+Thunder+Bay+District,+Ontario&amp;t=m&amp;ll=49.013217,-88.263474&amp;spn=0.028148,0.043087&amp;z=13&amp;iwloc=A" style="color:#0000FF;text-align:right; font-size:10pt;">View Larger Map</a></small>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <div style="background:#feff9c;Padding:25px;"><h1>Welcome to Nipigon District Memorial Hospital</h1>
        <img src="img/frontbaby.jpg" width="200px" style="float:left;margin:20px;" alt="baby" />
        <p style="margin-top:20px;">Here at NDMH, our goal is to make your experience with us as beneficial and comfortable as possible. For over 30 years, we've been servicing the Nipigon District and feel privilaged to be a part of such a heartfelt community. Our hospital offers a wide variety of health services</p>
    </div>
    <%-- 2 latest entries from the events(news) table --%> 
    <h1>Latest News</h1>
    <asp:Repeater ID="rpt_news" runat="server">
        <ItemTemplate>
            <article class="blog" style="border:1px solid #CCC;padding:20px;margin-bottom:10px;">
                <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("n_title") %>' Font-Bold="true" Font-Size="16" />&nbsp;&nbsp;Date Posted:
                <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("n_event_date", "{0:d}") %>' Font-Italic="true" Font-Size="13" />
                <asp:Image ID="img_article" runat="server" ImageUrl='<%#Eval("n_image") %>' Style="margin-top:10px;" Width="550" />
                <br />
                <asp:Label ID="lbl_desc" runat="server" Text='<%#Eval("n_description") %>' Font-Size="13" />
                <asp:HyperLink ID="hpl_moreNews" runat="server" Text="READ MORE..." NavigateUrl="~/navigation/newsblog.aspx" Style="margin-left:430px;" Font-Size="12" />
            </article><%-- end "blog" article --%>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

