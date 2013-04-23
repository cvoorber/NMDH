<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="giftshop.aspx.cs" Inherits="giftshop" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_area" Runat="Server">
<div id="giftshop">
    <div id="giftHeadings">
        <%-- heading for the giftshop and link to current session's cart --%>
        <asp:Label ID="lblProdHeading" runat="server" Text="Welcome to our Gift Shop!" Font-Bold="true" Font-Size="22" style="float:left;" />
        <asp:HyperLink ID="hpl_cart" runat="server" NavigateUrl="~/navigation/viewcart.aspx" Text="View Shopping Cart" Font-Size="16" style="float:right;" />
    </div>
    <div id="giftContents">
        <%-- displaying products available for purchase --%>
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
                    <asp:LinkButton ID="lnk_buy" runat="server" CommandName="addItem" Text="Add to Cart" style="float:right;" Font-Size="12" />
                </div><%-- end "item" div --%>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
</asp:Content>

