<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/subAdmin.master" AutoEventWireup="true" CodeFile="giftshopCMS.aspx.cs" Inherits="Admin_giftshopCMS" %>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">

    <%-- Area to insert new giftshop products --%>
    <div id="insertProd" style="width:40%;margin:0 5px 30px 30px;padding:0 20px;border:1px solid #CCC;">
            <br />
        <asp:Label ID="lbl_message" runat="server" />
            <br />
        <asp:Label ID="lbl_insert" runat="server" Text="Insert New Product:" Font-Bold="true" Font-Size="14" />
            <br />
            <br />
        <asp:Label ID="lbl_nameI" runat="server" Text="Name" AssociatedControlID="txt_nameI" />
            <br />
        <asp:TextBox ID="txt_nameI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_nameI" runat="server" Text="*required" ControlToValidate="txt_nameI" ValidationGroup="insert" />
            <br />
        <asp:Label ID="lbl_descI" runat="server" Text="Description" AssociatedControlID="txt_descI" />
            <br />
        <asp:TextBox ID="txt_descI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_descI" runat="server" Text="*required" ControlToValidate="txt_descI" ValidationGroup="insert" />
            <br />
        <asp:DropDownList ID="ddl_imageI" runat="server" />&nbsp;**Images can be uploaded below
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*required" ControlToValidate="txt_descI" ValidationGroup="insert" />
            <br />
        <asp:Label ID="lbl_priceI" runat="server" Text="Price" AssociatedControlID="txt_priceI" />
            <br />
        <asp:TextBox ID="txt_priceI" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_priceI" runat="server" Text="*required" ControlToValidate="txt_priceI" ValidationGroup="insert" />
        <asp:CompareValidator ID="cpv_priceI" runat="server" Text="*Not a number" ControlToValidate="txt_priceI" Operator="DataTypeCheck" Type="Currency" ValidationGroup="insert" Display="Dynamic" />
            <br />
        <asp:Button ID="btn_insert" runat="server" Text="Insert" CommandName="Insert" OnCommand="subAdmin" ValidationGroup="insert" />
            <br />
            <br />
    </div><%-- end insertProd --%>

    <%-- Area to view/edit the current giftshop products --%>
    <div id="editProd" style="width:70%;padding:20px;margin:0 5px 30px 10px;border:1px solid #CCC;">
        <asp:Label ID="lbl_editMsg" runat="server" />
        <%-- the "view" panel --%>
        <asp:Panel ID="pnl_all" runat="server">
            <asp:Label ID="lbl_editTitle" runat="server" Text="List of Current Giftshop Items" Font-Bold="true" Font-Size="14" />
            <br /><br />
            <table id="editTable" cellpadding="5" cellspacing="3">
                <thead style="font-weight:bold;background-color:#d3d3d3;">
                    <tr style="height:20px;font-size:16px;text-align:left;">
                        <th style="width:200px"><asp:Label ID="lbl_nameProd" runat="server" Text="Item Name" /></th>
                        <th style="width:100px"><asp:Label ID="lbl_editProd" runat="server" Text="Edit" /></th>
                        <th style="width:100px"><asp:Label ID="lbl_deleteProd" runat="server" Text="Delete" /></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt_all" runat="server">
                        <ItemTemplate>
                            <tr style="height:30px;font-size:16px;">
                                <td><%#Eval("p_name") %></td>
                                <td><asp:LinkButton ID="btn_update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%#Eval("p_id") %>' OnCommand="subAdmin" /></td>
                                <td><asp:LinkButton ID="btn_delete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("p_id") %>' OnCommand="subAdmin" /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>

        <%-- the "update" panel --%>
        <asp:Panel ID="pnl_update" runat="server">
            <asp:Label ID="lbl_updateTitle" runat="server" Text="Updating this product:" Font-Bold="true" Font-Size="14" />
            <br /><br />
            <table cellpadding="2" cellspacing="3">
                <thead style="font-weight:bold;">
                    <tr>
                        <th><asp:Label ID="lbl_nameU" runat="server" Text="Name" /></th>
                        <th><asp:Label ID="lbl_descU" runat="server" Text="Description" /></th>
                        <th><asp:Label ID="lbl_priceU" runat="server" Text="Price" /></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt_update" runat="server" OnItemCommand="subUpDel">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("p_id") %>' />
                                <td><asp:TextBox ID="txt_nameU" runat="server" Text='<%#Eval("p_name") %>' /></td>
                                <td><asp:TextBox ID="txt_descU" runat="server" Text='<%#Eval("p_desc") %>' TextMode="MultiLine" /></td>
                                <td><asp:TextBox ID="txt_priceU" runat="server" Text='<%#Eval("p_price") %>' /></td>
                            </tr>
                            <tr>
                                <td><asp:RequiredFieldValidator ID="rfv_nameU" runat="server" Text="*required" ControlToValidate="txt_nameU" ValidationGroup="update" /></td>
                                <td><asp:RequiredFieldValidator ID="rfv_descU" runat="server" Text="*required" ControlToValidate="txt_descU" ValidationGroup="update" /></td>
                                <td>
                                <asp:RequiredFieldValidator ID="rfv_priceU" runat="server" Text="*required" ControlToValidate="txt_priceU" ValidationGroup="update" />
                                <asp:CompareValidator ID="cpv_priceU" runat="server" Text="*Not a number" ControlToValidate="txt_priceU" Operator="DataTypeCheck" Type="Currency" ValidationGroup="update" Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btn_doUpdate" runat="server" Text="Update" CommandName="Update" ValidationGroup="update" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>

        <%-- the "delete" panel --%>
        <asp:Panel ID="pnl_delete" runat="server">
            <asp:Label ID="lbl_deleteTitle" runat="server" Text="Deleting this product:" Font-Bold="true" Font-Size="14" />
            <br /><br />
            <table cellpadding="2" cellspacing="3">
                <thead style="font-weight:bold;">
                    <tr>
                        <td colspan="4" align="center" style="color:Red;">
                            <asp:Label ID="lbl_delete" runat="server" Text="Are you sure you want to delete this item?" />
                        </td>
                    </tr>
                    <tr>
                        <th><asp:Label ID="lbl_nameD" runat="server" Text="Name" /></th>
                        <th><asp:Label ID="lbl_descD" runat="server" Text="Description" /></th>
                        <th><asp:Label ID="lbl_priceD" runat="server" Text="Price" /></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpt_delete" runat="server" OnItemCommand="subUpDel">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="hdf_id" runat="server" Value='<%#Eval("p_id") %>' />
                                <td><asp:Label ID="lbl_proNameDel" runat="server" Text='<%#Eval("p_name") %>' /></td>
                                <td><asp:Label ID="lbl_proDescDel" runat="server" Text='<%#Eval("p_desc") %>' /></td>
                                <td><asp:Label ID="lbl_proPriceDel" runat="server" Text='<%#Eval("p_price") %>' /></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btn_doDelete" runat="server" Text="Delete" CommandName="Delete" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btn_doCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>

    </div><%-- end editProd --%>

    <div id="imageUpload" style="clear:both;margin:30px 0 40px 30px;">
        
        <%-- displays the success/failure message for the uploader --%>
        <asp:Label ID="lbl_msg" runat="server" />

        <%-- file uploader -puts images into the img folder -stores the path in the ndmh_uploads table --%>
        <asp:Label ID="lbl_heading" runat="server" Text="Use this form to upload images for use in the giftshop or newsblog." Font-Italic="true"  Font-Size="14" />
        <br />
        <asp:Label ID="Label1" runat="server" />
        <br /><br />
        <asp:Label ID="lbl_imagefile" runat="server" Text="Image File:" AssociatedControlID="FileUploader" />
        <asp:FileUpload ID="FileUploader" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_fileupload" runat="server" Text="*Required" ControlToValidate="FileUploader" ValidationGroup="insertImg" />
        <br />
        <asp:Label ID="lbl_imagename" runat="server" Text="Image Name:" AssociatedControlID="txt_imagename" />
        <asp:TextBox ID="txt_imagename" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_imagename" runat="server" Text="*Required" ControlToValidate="txt_imagename" ValidationGroup="insertImg" />
        <br /><br />
        <asp:Button ID="btnAdd" runat="server" Text="Upload Image" OnClick="subImage" ValidationGroup="insertImg" />
        <br /><br />
        <hr />
        <br />

        <%-- This allows the user to see what images are in the system --%>
        <asp:DataList ID="dtl_main" runat="server" RepeatLayout="Flow">
            <HeaderTemplate>
                <asp:Label ID="lbl_header" runat="server" Text="Below are the images which have been uploaded **They may appear distorted here**" Font-Italic="true"  Font-Size="14" />
                <br /><br />
            </HeaderTemplate>
            <ItemTemplate>
                <div class="upImages">
                    <asp:Label ID="lbl_name" runat="server" Text="Image Name:" Font-Bold="true" />&nbsp;
                    <asp:Label ID="lbl_name2" runat="server" Text='<%#Eval("ImageName")%>' Font-Italic="true" Font-Size="15" />
                    <br /><br />
                    <asp:Image ID="img_ad" runat="server" ImageUrl='<%#Eval("ImageURL")%>' Width="400" Height="400" />
                    <br />
                </div><%-- end upImages --%>
            </ItemTemplate>
        </asp:DataList>

    </div><%-- end imageUpload --%>
</asp:Content>

