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
       <td><asp:Button ID="btn_del" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this Department Record?');"
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
       <asp:Textbox ID="txt_ename" runat="server" Text='<%#Eval("dl_name") %>' />
       
        <asp:RequiredFieldValidator ID="rfv_ename" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ename" 
                 ValidationGroup="editView" Display="Dynamic" /><br />
       ID: &nbsp;
       <asp:Label ID="lbl_eid" runat="server" Text='<%#Eval("dl_id") %>' />
        <asp:HiddenField ID="hdf_eid" runat="server" Value='<%#Eval("dl_id") %>' />
           <asp:Button ID="btn_update" runat="server" Text="Update" CommandName="Update" ValidationGroup="editView" />
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
       <td><asp:Textbox ID="txt_eexten" runat="server" Text='<%#Eval("dl_extention") %>' />
       <asp:RequiredFieldValidator ID="rfv_eexten" runat="server" ErrorMessage="*Required" ControlToValidate="txt_eexten" 
                 ValidationGroup="editView" Display="Dynamic" />
                 <asp:RangeValidator ID="rgv_eexten" runat="server" ErrorMessage="*Please enter a 4 digit number"
           MinimumValue="1000"  MaximumValue="9999" Type="Integer" ValidationGroup="editView" ControlToValidate="txt_eexten" /></td>
       
       <td><asp:Textbox ID="txt_edyopen" runat="server" Text='<%#Eval("dl_days_open") %>' />
       <asp:RequiredFieldValidator ID="rfv_edyopen" runat="server" ErrorMessage="*Required" ControlToValidate="txt_edyopen" 
                 ValidationGroup="editView" Display="Dynamic" /></td>
       <td><asp:Textbox ID="txt_eflnum" runat="server" Text='<%#Eval("dl_floor_no") %>' />
       <asp:RequiredFieldValidator ID="rfv_eflnum" runat="server" ErrorMessage="*Required" ControlToValidate="txt_eflnum" 
                 ValidationGroup="editView" Display="Dynamic" />
                 <asp:RangeValidator ID="rgv_eflnum" runat="server" ErrorMessage="*Please enter a number between 1 and 3" ControlToValidate="txt_eflnum"
           MinimumValue="1"  MaximumValue="3" Type="Integer" ValidationGroup="editView" /></td>
       <td><asp:Textbox ID="txt_ermnum" runat="server" Text='<%#Eval("dl_room_no") %>' />
       <asp:RequiredFieldValidator ID="rfv_ermnum" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ermnum" 
                 ValidationGroup="editView" Display="Dynamic" />
        <asp:RangeValidator ID="rgv_ermnum" runat="server" ErrorMessage="*Please enter a valid room number" ControlToValidate="txt_ermnum"
           MinimumValue="100"  MaximumValue="399" Type="Integer" ValidationGroup="editView" />
       </td>
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
       <td><asp:Textbox ID="txt_edepdesc" runat="server" Text='<%#Eval("dl_description") %>' />
       <asp:RequiredFieldValidator ID="rfv_edepdesc" runat="server" ErrorMessage="*Required" ControlToValidate="txt_edepdesc" 
                 ValidationGroup="editView" Display="Dynamic" />
       </td>
       <td><asp:Textbox ID="txt_eimgurl" runat="server" Text='<%#Eval("dl_img_url") %>' />
       <asp:RequiredFieldValidator ID="rfv_eimgurl" runat="server" ErrorMessage="*Required" ControlToValidate="txt_eimgurl" 
                 ValidationGroup="editView" Display="Dynamic" />
       </td>
       <td><asp:Textbox ID="txt_eimgalt" runat="server" Text='<%#Eval("dl_img_alt") %>' />
       <asp:RequiredFieldValidator ID="rfv_eimgalt" runat="server" ErrorMessage="*Required" ControlToValidate="txt_eimgalt" 
                 ValidationGroup="editView" Display="Dynamic" />
       </td>
       <td><asp:Textbox ID="txt_eimgdesc" runat="server" Text='<%#Eval("dl_img_desc") %>' />
       <asp:RequiredFieldValidator ID="rfv_eimgdesc" runat="server" ErrorMessage="*Required" ControlToValidate="txt_eimgdesc" 
                 ValidationGroup="editView" Display="Dynamic" />
       </td>
       <td><asp:Textbox ID="txt_eimgwid" runat="server" Text='<%#Eval("dl_img_width") %>' />
       <asp:RequiredFieldValidator ID="rfv_eimgwid" runat="server" ErrorMessage="*Required" ControlToValidate="txt_eimgwid" 
                 ValidationGroup="editView" Display="Dynamic" />
         <asp:CompareValidator ID="cmv_eimgwid" runat="server"  ControlToValidate="txt_eimgwid" Operator="DataTypeCheck"  Type="Integer"
        ErrorMessage="*Please enter an integer" ValidationGroup="editView" />
       </td>
       <td><asp:Textbox ID="txt_eimgheig" runat="server" Text='<%#Eval("dl_img_height") %>' />
       <asp:RequiredFieldValidator ID="rfv_eimgheig" runat="server" ErrorMessage="*Required" ControlToValidate="txt_eimgheig" 
                 ValidationGroup="editView" Display="Dynamic" />
        <asp:CompareValidator ID="cmv_eimgheig" runat="server"  ControlToValidate="txt_eimgheig" Operator="DataTypeCheck"  Type="Integer"
        ErrorMessage="*Please enter an integer" ValidationGroup="editView" />
       </td>
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
           <asp:Button ID="btn_isave" runat="server" Text="Save" CommandName="Save" OnCommand="subInsertAction" ValidationGroup="insertView" /></td>
           <td><asp:Button ID="btn_icancel" runat="server" Text="Cancel" CommandName="Cancel" OnCommand="subInsertAction" /></td>
       </tr>
       <tr><td>Name: <asp:Textbox ID="txt_iname" runat="server" /> 
       <asp:RequiredFieldValidator ID="rfv_iname" runat="server" ErrorMessage="*Required" ControlToValidate="txt_iname" 
                 ValidationGroup="insertView" Display="Dynamic" />
       </td></tr>
       <tr>
       <td>Phone Extension</td>
       
       <td>Days Open</td>
       <td>Floor Number</td>
       <td>Room Number</td>
       </tr>
       <tr>
       <td><asp:Textbox ID="txt_iexten" runat="server"  />
       <asp:RequiredFieldValidator ID="rfv_iexten" runat="server" ErrorMessage="*Required" ControlToValidate="txt_iexten" 
                 ValidationGroup="insertView" Display="Dynamic" />
           <asp:RangeValidator ID="rgv_iexten" runat="server" ErrorMessage="*Please enter a 4 digit number" ControlToValidate="txt_iexten"
           MinimumValue="1000"  MaximumValue="9999" Type="Integer" ValidationGroup="insertView" /></td>
       
       <td><asp:Textbox ID="txt_idyopen" runat="server"  />
       <asp:RequiredFieldValidator ID="rfv_idyopen" runat="server" ErrorMessage="*Required" ControlToValidate="txt_idyopen" 
                 ValidationGroup="insertView" Display="Dynamic" />
       </td>
       <td><asp:Textbox ID="txt_iflnum" runat="server"  />
       <asp:RequiredFieldValidator ID="rfv_iflnum" runat="server" ErrorMessage="*Required" ControlToValidate="txt_iflnum" 
                 ValidationGroup="insertView" Display="Dynamic" />
        <asp:RangeValidator ID="rgv_iflnum" runat="server" ErrorMessage="*Please enter a number between 1 and 3" ControlToValidate="txt_iflnum"
           MinimumValue="1"  MaximumValue="3" Type="Integer" ValidationGroup="insertView" />
       </td>
       <td><asp:Textbox ID="txt_irmnum" runat="server"  />
       <asp:RequiredFieldValidator ID="rfv_irmnum" runat="server" ErrorMessage="*Required" ControlToValidate="txt_irmnum" 
                 ValidationGroup="insertView" Display="Dynamic" />
                 <asp:RangeValidator ID="rgv_irmnum" runat="server" ErrorMessage="*Please enter a valid room number" ControlToValidate="txt_irmnum"
           MinimumValue="100"  MaximumValue="399" Type="Integer" ValidationGroup="insertView" />
       </td>
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
       <td><asp:Textbox ID="txt_idepdesc" runat="server"  />
       <asp:RequiredFieldValidator ID="rfv_idepdesc" runat="server" ErrorMessage="*Required" ControlToValidate="txt_idepdesc" 
                 ValidationGroup="insertView" Display="Dynamic" />
       </td>
       <td><asp:Textbox ID="txt_iimgurl" runat="server"  />
       <asp:RequiredFieldValidator ID="rfv_iimgurl" runat="server" ErrorMessage="*Required" ControlToValidate="txt_iimgurl" 
                 ValidationGroup="insertView" Display="Dynamic" />
       </td>
       <td><asp:Textbox ID="txt_iimgalt" runat="server"  />
       <asp:RequiredFieldValidator ID="rfv_iimgalt" runat="server" ErrorMessage="*Required" ControlToValidate="txt_iimgalt" 
                 ValidationGroup="insertView" Display="Dynamic" />
       </td>
       <td><asp:Textbox ID="txt_iimgdesc" runat="server"  />
       <asp:RequiredFieldValidator ID="rfv_iimgdesc" runat="server" ErrorMessage="*Required" ControlToValidate="txt_iimgdesc" 
                 ValidationGroup="insertView" Display="Dynamic" />
       </td>
       <td><asp:Textbox ID="txt_iimgwid" runat="server"  />
       <asp:RequiredFieldValidator ID="rfv_iimgwid" runat="server" ErrorMessage="*Required" ControlToValidate="txt_iimgwid" 
                 ValidationGroup="insertView" Display="Dynamic" />
        <asp:CompareValidator ID="cmv_iimgwid" runat="server"  ControlToValidate="txt_iimgwid" Operator="DataTypeCheck"  Type="Integer"
        ErrorMessage="*Please enter an integer" ValidationGroup="insertView" />
       </td>
       <td><asp:Textbox ID="txt_iimgheig" runat="server"  />
       <asp:RequiredFieldValidator ID="rfv_iimgheig" runat="server" ErrorMessage="*Required" ControlToValidate="txt_iimgheig" 
                 ValidationGroup="insertView" Display="Dynamic" />
        <asp:CompareValidator ID="cmv_iimgheig" runat="server"  ControlToValidate="txt_iimgheig" Operator="DataTypeCheck"  Type="Integer"
        ErrorMessage="*Please enter an integer" ValidationGroup="insertView" />
       </td>
       </tr>
       
       </table>
    </asp:Panel>


</asp:Content>

