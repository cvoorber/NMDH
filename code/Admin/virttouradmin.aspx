<%@ Page Title="Virtual Tour Admin" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="virttouradmin.aspx.cs" Inherits="AdminVirtTour"
 %>

<asp:Content ID="cnt_vtadminhead" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css" >
    table, table tr
    {
        border: 2px solid black;
    }
    table td
    {
        border: 1px solid black;
    }
</style>
</asp:Content>
<asp:Content ID="cnt_vtadminmain" ContentPlaceHolderID="content_area" Runat="Server">
   <asp:Panel ID="pnl_main" runat="server">
           
    <asp:DataList ID="dtl_main" runat="server" DataKeyField="dl_id" >
    <HeaderTemplate>
        <asp:Button ID="btn_insert" runat="server" Text="Create New Record" CommandName="Insert" OnCommand="subInsertView" />
    </HeaderTemplate>
   <ItemTemplate>
   
       <table>
           
       <%--Row for name, id and operations--%>
       <tr>
       <td>Name:&nbsp;  <asp:Label ID="Label1" runat="server" Text='<%#Eval("dl_name") %>' /></td>
       <td>ID: &nbsp;<asp:Label ID="Label2" runat="server" Text='<%#Eval("dl_id") %>' /></td>
       <td><asp:Button ID="btn_edit" runat="server" Text="Edit" CommandName="Edit" OnCommand="subEditView" 
        CommandArgument='<%#Eval("dl_id") %>' /></td>
       <td><asp:Button ID="btn_del" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this FAQ?');"
        CommandName="Delete" OnCommand="subDelete" CommandArgument='<%#Eval("dl_id") %>' /></td>
       </tr>


       <%--Two rows for first half of other records--%>
       
       <tr>
       <td>Phone Extension</td>
       
       <td>Days Open</td>
       <td>Floor Number</td>
       <td>Room Number</td>
       </tr>
       <tr>
       <td><asp:Label ID="lbl_exten" runat="server" Text='<%#Eval("dl_extention") %>' /></td>
       
       <td><asp:Label ID="lbl_dyopen" runat="server" Text='<%#Eval("dl_days_open") %>' /></td>
       <td><asp:Label ID="lbl_flnum" runat="server" Text='<%#Eval("dl_floor_no") %>' /></td>
       <td><asp:Label ID="lbl_rmnum" runat="server" Text='<%#Eval("dl_room_no") %>' /></td>
       </tr>

       <%--Two rows for first half of other records--%>
       <tr>
       <td>Department Description</td>
       <td>Image URL</td>
       <td>Image ALT value</td>
       <td>Image Desc value</td>
       <td>Image Width</td>
       <td>Image Height</td>
       
       </tr>
       <tr>
       <td><asp:Label ID="lbl_depdesc" runat="server" Text='<%#Eval("dl_description") %>' /></td>
       <td><asp:Label ID="lbl_imgurl" runat="server" Text='<%#Eval("dl_img_url") %>' /></td>
       <td><asp:Label ID="lbl_imgalt" runat="server" Text='<%#Eval("dl_img_alt") %>' /></td>
       <td><asp:Label ID="lbl_imgdesc" runat="server" Text='<%#Eval("dl_img_desc") %>' /></td>
       <td><asp:Label ID="lbl_imgwid" runat="server" Text='<%#Eval("dl_img_width") %>' /></td>
       <td><asp:Label ID="lbl_imgheig" runat="server" Text='<%#Eval("dl_img_height") %>' /></td>
       </tr>
       
       </table>
    </ItemTemplate>

    

    <FooterTemplate>
    <%--When you click on the insert button you will see a simple repeater control where you can enter a new record--%>

    </FooterTemplate>

    <%--Add in a repeater control down here that will be the insert template.--%>


    </asp:DataList>
    </asp:Panel>
    
    <asp:Panel ID="pnl_edit" runat="server" Visible="false">
    
    <%--Put a form view control here that will be the edit template--%>
    <asp:Repeater ID="rpt_edit" runat="server"   OnItemCommand="subEditViewCommand"   >
    <ItemTemplate>
    <div>
       Name:&nbsp;
       <asp:Textbox ID="txt_ename" runat="server" Text='<%#Eval("dl_name") %>' /><br />
       ID: &nbsp;
       <asp:Textbox ID="txt_eid" runat="server" Text='<%#Eval("dl_id") %>' />
           <asp:Button ID="btn_update" runat="server" Text="Update" CommandName="Update" />
           <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CommandName="Cancel" />
       </div>
        <table >
       <%--Two rows for first half of other records--%>
       <tr>
       <td>Phone Extension</td>
       
       <td>Days Open</td>
       <td>Floor Number</td>
       <td>Room Number</td>
       </tr>
       <tr>
       <td><asp:Textbox ID="txt_eexten" runat="server" Text='<%#Eval("dl_extention") %>' /></td>
       
       <td><asp:Textbox ID="txt_edyopen" runat="server" Text='<%#Eval("dl_days_open") %>' /></td>
       <td><asp:Textbox ID="txt_eflnum" runat="server" Text='<%#Eval("dl_floor_no") %>' /></td>
       <td><asp:Textbox ID="txt_ermnum" runat="server" Text='<%#Eval("dl_room_no") %>' /></td>
       </tr>

       <%--Two rows for first half of other records--%>
       <tr>
       <td>Department Description</td>
       <td>Image URL</td>
       <td>Image ALT value</td>
       <td>Image Desc value</td>
       <td>Image Width</td>
       <td>Image Height</td>
       
       </tr>
       <tr>
       <td><asp:Textbox ID="txt_edepdesc" runat="server" Text='<%#Eval("dl_description") %>' /></td>
       <td><asp:Textbox ID="txt_eimgurl" runat="server" Text='<%#Eval("dl_img_url") %>' /></td>
       <td><asp:Textbox ID="txt_eimgalt" runat="server" Text='<%#Eval("dl_img_alt") %>' /></td>
       <td><asp:Textbox ID="txt_eimgdesc" runat="server" Text='<%#Eval("dl_img_desc") %>' /></td>
       <td><asp:Textbox ID="txt_eimgwid" runat="server" Text='<%#Eval("dl_img_width") %>' /></td>
       <td><asp:Textbox ID="txt_eimgheig" runat="server" Text='<%#Eval("dl_img_height") %>' /></td>
       </tr>
       
       </table>
    </ItemTemplate>
    <%--<PagerTemplate>

        <asp:LinkButton ID="lkb_prev" runat="server" Text="Previous" CommandName="Page" CommandArgument="Prev" />
        <br />
        <asp:LinkButton ID="lkb_next" runat="server" Text="Next" CommandName="Page" CommandArgument="Next" />
    </PagerTemplate>--%>
    </asp:Repeater>
    </asp:Panel>

    <%--Put a panel here that just has a bunch of textboxes that will be the insert template--%>



    <asp:Label ID="lbl_execmess" runat="server"  />

    <asp:Panel ID="pnl_insert" runat="server" Visible="false">
    <table >
       <%--Two rows for first half of other records--%>
       <tr>
       <td>
           <asp:Button ID="btn_isave" runat="server" Text="Save" CommandName="Save" OnCommand="subInsertAction" /></td>
           <td><asp:Button ID="btn_icancel" runat="server" Text="Cancel" CommandName="Cancel" OnCommand="subInsertAction" /></td>
       </tr>
       <tr><td>Name: <asp:Textbox ID="txt_iname" runat="server" /> </td></tr>
       <tr>
       <td>Phone Extension</td>
       
       <td>Days Open</td>
       <td>Floor Number</td>
       <td>Room Number</td>
       </tr>
       <tr>
       <td><asp:Textbox ID="txt_iexten" runat="server"  /></td>
       
       <td><asp:Textbox ID="txt_idyopen" runat="server"  /></td>
       <td><asp:Textbox ID="txt_iflnum" runat="server"  /></td>
       <td><asp:Textbox ID="txt_irmnum" runat="server"  /></td>
       </tr>

       <%--Two rows for first half of other records--%>
       <tr>
       <td>Department Description</td>
       <td>Image URL</td>
       <td>Image ALT value</td>
       <td>Image Desc value</td>
       <td>Image Width</td>
       <td>Image Height</td>
       
       </tr>
       <tr>
       <td><asp:Textbox ID="txt_idepdesc" runat="server"  /></td>
       <td><asp:Textbox ID="txt_iimgurl" runat="server"  /></td>
       <td><asp:Textbox ID="txt_iimgalt" runat="server"  /></td>
       <td><asp:Textbox ID="txt_iimgdesc" runat="server"  /></td>
       <td><asp:Textbox ID="txt_iimgwid" runat="server"  /></td>
       <td><asp:Textbox ID="txt_iimgheig" runat="server"  /></td>
       </tr>
       
       </table>
    </asp:Panel>


</asp:Content>

