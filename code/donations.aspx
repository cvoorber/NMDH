<%@ Page Language="C#" AutoEventWireup="true" CodeFile="donations.aspx.cs" Inherits="donations" MasterPageFile="~/maintemplate.master" %>

<asp:Content ID="form_donate" ContentPlaceHolderID="content_area" Runat="Server">
    <!--This panel will have the general info about the donor when he or she enters it, and clicks
    next this panel will dissapear and the next panel will appear
    I will just put the form items in a panel, and then for the second tier, have another form 
    that is in another panel. Will use JS/AJAX to change from one to the other. The only things
    I will need databound controls for is when you need to pull info from database... for now, just 
    assume something can be hard coded until there is further notice. -->
        <asp:Panel runat="server" ID="pnl_uinfo">
        <!-- Will put main form here -->
        <!--First Name -->
        <asp:Label ID="lbl_fname" runat="server" Text="First Name" />
        <asp:TextBox ID="txt_fname" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_frname" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_fname" />
        <!--Last Name -->
        <asp:Label ID="lbl_lname" runat="server" Text="Last Name" />
        <asp:TextBox ID="txt_lname" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_lname" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_lname" />
        <!--Email Address -->
        <asp:Label ID="lbl_email" runat="server" Text="Email" />
        <asp:TextBox ID="txt_email" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_email" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_email" />
        <!--Address -->
        <asp:Label ID="lbl_address" runat="server" Text="Address" />
        <asp:TextBox ID="txt_address" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_address" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_address" />
        <!--City -->
        <asp:Label ID="lbl_city" runat="server" Text="City" />
        <asp:TextBox ID="txt_city" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_city" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_city" />
        <!--Province -->
        
      <%-- <asp:Label ID="lbl_prov" runat="server" Text="Label" />
       <asp:DropDownList ID="ddl_" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ErrorMessage="RequiredFieldValidator" />--%>
        
        <!--Telephone # -->
        <asp:Label ID="lbl_tel" runat="server" Text="Telephone" />
        <asp:TextBox ID="txt_tel" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_tel" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_tel" />
        <!--Comments -->
        <asp:Label ID="lbl_comments" runat="server" Text="Comments:" />
        <asp:TextBox ID="txt_comments" runat="server" TextMode="MultiLine" />
        <asp:RequiredFieldValidator ID="rfv_comments" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_comments" />    
 

        <asp:Button ID="btn_next" runat="server" Text="Next" />
    </asp:Panel>
    <!-- This Second Panel will include the second round view where the user will submit their credit
    card information ... a couple options I can have here would be that I can process the
    credit card myself in some way, and figure out how to do it so that it is encoded...
    and also, asynchronously when the individual enters their credit card number, after
    the first few numbers are entered, an image of the corresponding card company can appear  -->
    <asp:Panel runat="server" ID="pnl_cred">
    
    </asp:Panel>
   </asp:Content>
    

