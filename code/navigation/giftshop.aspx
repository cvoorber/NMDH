<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="giftshop.aspx.cs" Inherits="giftshop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
    <asp:Label ID="lblCartHeading" runat="server" Text="Transactions and cart info display here" />
    <div id="shoppingCart">
        <div>Shoes - <asp:LinkButton runat="server" ID="btnAddShirt" OnClick="btnAddShoes_Click">Add To Cart</asp:LinkButton></div>  
  
        <div>Shirt - <asp:LinkButton runat="server" ID="btnAddShorts" OnClick="btnAddShirt_Click">Add To Cart</asp:LinkButton></div>  
        <div>Pants - <asp:LinkButton runat="server" ID="btnAddShoes" OnClick="btnAddPants_Click">Add To Cart</asp:LinkButton></div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <asp:Label ID="lblProdHeading" runat="server" Text="Welcome to our Gift Shop!" Font-Bold="true" Font-Size="22" />
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text="*Drag images into shopping cart on left to add*" Font-Size="16" Font-Italic="true" />
    <br /><br />
    <asp:ListView ID="listProducts" runat="server">
        <ItemTemplate>
            <div class="item" style="float:left;width:200px;height:320px;border:1px solid gray;padding:20px 30px;margin:15px 15px;background:#FFF;cursor:hand;cursor:grab;cursor:-moz-grab;cursor:-webkit-grab;">
                <asp:Label ID="lblName" runat="server" Text='<%#Eval("p_name") %>' Font-Bold="true" Font-Size="16" />
                <br />
                <asp:Image ID="imgProd" runat="server" ImageUrl='<%#Eval("p_image") %>' Width="199" Height="200" />
                <br />
                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("p_desc") %>' Font-Size="13" />
                <br /><br />
                <asp:Label ID="lblPriceTitle" runat="server" Text="Price: $" Font-Size="14" />
                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("p_price") %>' Font-Size="14" />&nbsp;
                <div class="itemDrop" style="float:right;font-size:14px;border:1px solid gray;background:#CCC;padding:4px;">Drag to Cart</div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {

            $(".item").draggable({ helper: "clone" });

            $("#shoppingCart").droppable(
                {
                    accept: ".item",
                    drop: (function (ev, ui) {

                        var droppedItem = $(ui.draggable).clone();
                        $("#shoppingCart").append(droppedItem);
                        addToList();
                    })
                });

        });
    </script>
</asp:Content>

