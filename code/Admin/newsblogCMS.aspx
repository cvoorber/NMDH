<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsblogCMS.aspx.cs" Inherits="Admin_newsblogCMS" MasterPageFile="~/Admin/subAdmin.master" %>

<asp:Content runat="server" ContentPlaceHolderID="r_content">
        <asp:Label ID="lbl_message" runat="server" />
        <br />
        <br />
        <asp:Label ID="lbl_insert" runat="server" Text="Insert an Article" Font-Bold="true" Font-Size="16" />
        <br /><br />
        <asp:Label ID="lbl_titleI" runat="server" Text="Title" AssociatedControlID="txt_titleI" />
        <br />
        <asp:TextBox ID="txt_titleI" runat="server" />
        <br />
        <asp:Label ID="lbl_imageI" runat="server" Text="Image" AssociatedControlID="ddl_image" />
        <br />
        <asp:DropDownList ID="ddl_image" runat="server" />&nbsp;**Images can be uploaded below
        <br />
        <asp:Label ID="lbl_contactidI" runat="server" Text="Contact ID" AssociatedControlID="txt_contactidI" />
        <br />
        <asp:TextBox ID="txt_contactidI" runat="server" />
        <br />
        <asp:Label ID="lbl_descI" runat="server" Text="Description" AssociatedControlID="txt_descI" />
        <br />
        <asp:TextBox ID="txt_descI" runat="server" TextMode="MultiLine" Columns="70" Rows="8" />
        <br />
        <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="subInsert" />
        <br />
        <br />
        <hr />
        <asp:Label ID="lbl_editHeading" runat="server" Text="Choose an item from the drop down list to edit/delete." Font-Bold="true" Font-Size="16" />
        <br />
        <asp:DropDownList ID="ddl_main" runat="server" AutoPostBack="true" OnSelectedIndexChanged="subChange" />
        <br /><br />

        <asp:ListView ID="lv_main" runat="server" OnItemCommand="subAdmin">
            <ItemTemplate>
                <asp:HiddenField ID="hdf_idE" runat="server" Value='<%#Eval("n_id") %>' />
                <asp:Label ID="lbl_titleE" runat="server" Text="News Article Title" />
                <br />
                <asp:TextBox ID="txt_titleE" runat="server" Text='<%#Bind("n_title") %>' />
                <br />
                <asp:Label ID="lbl_imageE" runat="server" Text="Image" />
                <br />
                <asp:TextBox ID="txt_imageE" runat="server" Text='<%#Bind("n_image") %>' />
                <br />
                <asp:Label ID="lbl_contactidE" runat="server" Text="Contact ID" />
                <br />
                <asp:TextBox ID="txt_contactidE" runat="server" Text='<%#Bind("n_contact_id") %>' />
                <br />
                <asp:Label ID="lbl_descE" runat="server" Text="Description/Body" />
                <br />
                <asp:TextBox ID="txt_descE" runat="server" Text='<%#Bind("n_description") %>' TextMode="MultiLine" Columns="70" Rows="8" />
                <br /><br />
                <asp:LinkButton ID="lb_update" runat="server" Text="Update" CommandName="subUpdate" BackColor="LightGray" Font-Size="12" Style="border-radius:6px;padding:5px;margin-top:10px;" BorderWidth="1" BorderColor="Black" />
                &nbsp;&nbsp;
                <asp:LinkButton ID="lb_delete" runat="server" Text="Delete" CommandName="subDelete" OnClientClick="return confirm('Are you sure you want to delete this record?');" BackColor="LightGray" Font-Size="12" Style="border-radius:6px;padding:5px;margin-top:10px;" BorderWidth="1" BorderColor="Black" />
            </ItemTemplate>
        </asp:ListView>

        <div id="imageUpload" style="clear:both;margin:30px 0 40px 30px;">
        <asp:Label ID="lbl_msg" runat="server" />

        <%-- This is a file uploader that puts images into the Images folder and stores the path in the ad_images table --%>

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