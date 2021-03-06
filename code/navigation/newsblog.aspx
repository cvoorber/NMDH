﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="newsblog.aspx.cs" Inherits="newsblog" %>
<%@ Mastertype VirtualPath="~/SubMaster1.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
    <asp:Label ID="lbl_heading" runat="server" Text="Share Your Comment!" Font-Size="20px" ForeColor="GrayText" />
    <asp:Label ID="lbl_message" runat="server" />
    <br /><br />
    <%-- form for public users to insert comments --%>
    <div class="insertComment">
        <asp:Label ID="lbl_nameI" runat="server" Text="Name:" AssociatedControlID="txt_nameI" Font-Bold="true" />
        <asp:TextBox ID="txt_nameI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_nameI" runat="server" Text="*Required" Display="Dynamic" ForeColor="Red" ValidationGroup="subComm" ControlToValidate="txt_nameI" style="clear:both;margin-left:45px;" />
        <br />
        <asp:Label ID="lbl_emailI" runat="server" Text="Email:" AssociatedControlID="txt_emailI" Font-Bold="true" />
        <asp:TextBox ID="txt_emailI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_emailI" runat="server" Text="*Required" Display="Dynamic" ForeColor="Red" ValidationGroup="subComm" ControlToValidate="txt_emailI" style="clear:both;margin-left:45px;" />
        <br /><br />
        <asp:Label ID="lbl_commentI" runat="server" Text="Comment:" AssociatedControlID="txt_commentI" Font-Bold="true" />
        <asp:TextBox ID="txt_commentI" runat="server" TextMode="MultiLine" Width="200" Height="100" MaxLength="500" />
        <asp:RequiredFieldValidator ID="rfv_commentI" runat="server" Text="*Required" Display="Dynamic" ForeColor="Red" ValidationGroup="subComm" ControlToValidate="txt_commentI" style="clear:both;" />
        <br /><br />
        <asp:HiddenField ID="hidden_id" runat="server" Value='<%#Eval("n_id") %>' />
        <asp:Button ID="btn_submit" runat="server" Text="Submit Comment" OnClick="subInsert" Font-Bold="true" ValidationGroup="subComm" />
        <br /><br />
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <div class="news">
    <%-- DDL for user selection of specific article --%>
    <p>Choose an article to display: <asp:DropDownList ID="ddl_main" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subChange" /></p>
        <%-- Gridview displaying selected article --%>
        <asp:GridView ID="grd_main" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <article class="blog">
                            <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("n_title") %>' Font-Bold="true" Font-Size="16" />&nbsp;&nbsp;Date Posted:
                            <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("n_event_date", "{0:d}") %>' Font-Italic="true" />
                            <asp:Image ID="img_article" runat="server" ImageUrl='<%#Eval("n_image") %>' Style="margin-top:10px;" Width="550" />
                            <br />
                            <asp:Label ID="lbl_desc" runat="server" Text='<%#Eval("n_description") %>' Font-Size="13" />
                        </article>
                        <hr /><br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <%-- Repeater displaying the comments associated with selected article --%>
        <asp:Label ID="lbl_commheading" runat="server" Text="User Comments" Font-Size="20px" ForeColor="GrayText" />
        <asp:Repeater ID="rpt_main" runat="server">
            <ItemTemplate>
                <div class="userComment">
                    <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("n_id") %>' />
                    <span style="font-style:italic; font-weight:bold;"><asp:Label ID="lbl_name" runat="server" Text='<%#Eval("comm_name") %>' /> said:</span>
                    <br />
                    <asp:Label ID="lbl_comment" runat="server" Text='<%#Eval("comm_text") %>' />
                    <br />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

