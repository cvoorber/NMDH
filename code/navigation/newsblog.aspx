<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="newsblog.aspx.cs" Inherits="newsblog" %>
<%@ Mastertype VirtualPath="~/SubMaster1.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
<asp:Label ID="lbl" Runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <article class="news">
        <asp:GridView ID="grd_main" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("n_title") %>' Font-Bold="true" Font-Size="16" />
                        <br />
                        <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("n_event_date") %>' Font-Italic="true" />
                        <br />
                        <asp:Label ID="lbl_desc" runat="server" Text='<%#Eval("n_description") %>' Font-Size="13" />
                        <br /> <br /> 
                    </ItemTemplate>
                    <FooterTemplate>
                        <div class="footer_bar"></div>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </article>
</asp:Content>

