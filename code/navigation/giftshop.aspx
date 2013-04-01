<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="giftshop.aspx.cs" Inherits="giftshop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
    <asp:Label ID="lblCartHeading" runat="server" Text="Transactions and cart info display here" />
    <div id="shoppingCart">
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <asp:Label ID="lblProdHeading" runat="server" Text="Welcome to our Gift Shop!" Font-Bold="true" Font-Size="22" />
    <br /><br />
    <asp:Label ID="Label1" runat="server" Text="*Drag images into shopping cart on left to add*" Font-Size="16" Font-Italic="true" />
    <br /><br />
    <asp:ListView ID="listProducts" runat="server">
        <ItemTemplate>
            <div class="item">
                <asp:Label ID="lblName" runat="server" Text='<%#Eval("p_name") %>' Font-Bold="true" Font-Size="16" />
                <br />
                <asp:Image ID="imgProd" runat="server" ImageUrl='<%#Eval("p_image") %>' CssClass="prodImg" />
                <br />
                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("p_desc") %>' />
                <br /><br />
                <asp:Label ID="lblPriceTitle" runat="server" Text="Price: $" />
                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("p_price") %>' />&nbsp;
                <%--<div class="itemDrop" style="float:right;border:1px solid gray;background:#CCC;padding:4px;">Drag to Cart</div>--%>
                <asp:LinkButton ID="lnk_buy" runat="server" OnClick="subAddItem" Text="Add to Cart" />
            </div>
        </ItemTemplate>
    </asp:ListView>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {

            //creating a draggable item
            $(".item").draggable({ helper: "clone", opacity: "0.8" });

            //creating a drop area and event
            $("#shoppingCart").droppable(
                {
                    accept: ".item",
                    drop: (function (ev, ui) {
                        
                        //creating the drop variable and changing css-class to shrink
                        var droppedItem = $(ui.draggable).clone().removeClass("item").addClass("droppedItemShrink");
                        $("#shoppingCart").append(droppedItem);

                        //creating a Remove link for the item in the shopping cart
                        var removeLink = document.createElement("a");
                        removeLink.innerHTML = "Remove";
                        removeLink.className = "deleteLink";
                        removeLink.href = "#";
                        removeLink.onclick = function () {
                            $("#shoppingCart").children("#" + droppedItem[0].id).fadeOut('slow', function () { $(this).remove(); });
                            $.ajax({
                                type: "POST",
                                url: "giftshop.aspx/RemoveItem",
                                contentType: "application/json; charset=utf-8",
                                data: "{id:'" + productCode + "'}",
                                dataType: "json"
                            });
                        }

                        droppedItem[0].appendChild(removeLink);
                        $(this).append(droppedItem);

                        $.ajax({
                            type: "POST",
                            url: "giftshop.aspx",
                            contentType: "application/json; charset=utf-8",
                            data: "{id:'" + productCode + "'}",
                            dataType: "json"
                        });
                        
                    })
                });

        });
    </script>
</asp:Content>

