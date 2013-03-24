<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="giftshop.aspx.cs" Inherits="giftshop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
    <asp:Label ID="lblCartHeading" runat="server" Text="Transactions and cart info display here" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <asp:Label ID="lblProdHeading" runat="server" Text="Welcome to our Gift Shop!" Font-Bold="true" Font-Size="22" />
    <br /><br />
    <asp:ListView ID="listProducts" runat="server">
        <ItemTemplate>
            <div style="float:left;width:200px;height:320px;border:1px solid gray;padding:20px 30px;margin:15px 15px;">
                <asp:Label ID="lblName" runat="server" Text='<%#Eval("p_name") %>' Font-Bold="true" Font-Size="16" />
                <br />
                <asp:Image ID="imgProd" runat="server" ImageUrl='<%#Eval("p_image") %>' Width="199" Height="200" />
                <br />
                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("p_desc") %>' Font-Size="13" />
                <br /><br />
                <asp:Label ID="lblPriceTitle" runat="server" Text="Price: $" Font-Size="14" />
                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("p_price") %>' Font-Size="14" />
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>

