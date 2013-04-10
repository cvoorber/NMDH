<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
<div id="waitTime">
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
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
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
            </article>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

