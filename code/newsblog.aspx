<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="newsblog.aspx.cs" Inherits="newsblog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
    <asp:Label ID="lbl_heading" runat="server" Text="Share Your Comment!" Font-Size="20px" ForeColor="GrayText" />
    <asp:Label ID="lbl_message" runat="server" />
    <br /><br />
    <aside class="insertComment">
        <asp:Label ID="lbl_nameI" runat="server" Text="Name:" AssociatedControlID="txt_nameI" Font-Bold="true" />
        <asp:TextBox ID="txt_nameI" runat="server" />
        <br />
        <asp:Label ID="lbl_emailI" runat="server" Text="Email:" AssociatedControlID="txt_emailI" Font-Bold="true" />
        <asp:TextBox ID="txt_emailI" runat="server" />
        <br />
        <asp:Label ID="lbl_commentI" runat="server" Text="Comment:" AssociatedControlID="txt_commentI" Font-Bold="true" />
        <asp:TextBox ID="txt_commentI" runat="server" TextMode="MultiLine" Width="230" Height="100" MaxLength="500" />
        <br />
        <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("n_id") %>' />
        <asp:Button ID="btn_submit" runat="server" Text="Submit Comment" OnClick="subInsert" Font-Bold="true" />
        <br /><br />
    </aside>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <section class="news">
    <p>Choose an article to display: <asp:DropDownList ID="ddl_main" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subChange" /></p>
        <asp:GridView ID="grd_main" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <article class="blog">
                            <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("n_title") %>' Font-Bold="true" Font-Size="16" />
                            <br />
                            <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("n_event_date") %>' Font-Italic="true" />
                            <br />
                            <asp:Label ID="lbl_desc" runat="server" Text='<%#Eval("n_description") %>' Font-Size="13" />
                        </article>
                        <hr /><br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

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
    </section>
</asp:Content>

