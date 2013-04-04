<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="giftshop.aspx.cs" Inherits="giftshop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
    <asp:Label ID="lblCartHeading" runat="server" Text="Transactions and cart info display here" />
    <div id="shoppingCart">
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <asp:Label ID="lblProdHeading" runat="server" Text="Welcome to our Gift Shop!" Font-Bold="true" Font-Size="22" />
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text="*Select from the items below*" Font-Size="16" Font-Italic="true" />
    <br /><br />
    <asp:ListView ID="listProducts" runat="server" OnItemCommand="subAdmin">
        <ItemTemplate>
            <div class="item">
                <asp:HiddenField ID="hdf_prod" runat="server" Value='<%#Eval("p_id") %>' />
                <asp:Label ID="lblName" runat="server" Text='<%#Eval("p_name") %>' Font-Bold="true" Font-Size="16" />
                <br />
                <asp:Image ID="imgProd" runat="server" ImageUrl='<%#Eval("p_image") %>' CssClass="prodImg" />
                <br />
                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("p_desc") %>' />
                <br /><br />
                <asp:Label ID="lblPriceTitle" runat="server" Text="Price: $" />
                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("p_price") %>' />&nbsp;
                <asp:LinkButton ID="lnk_buy" runat="server" CommandName="addItem" Text="Add to Cart" />
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>

