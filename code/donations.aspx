<%@ Page Language="C#" AutoEventWireup="true" CodeFile="donations.aspx.cs" Inherits="donations" MasterPageFile="~/maintemplate.master"  %>

<asp:Content ID="form_donate" ContentPlaceHolderID="content_area" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
    <!--This panel will have the general info about the donor when he or she enters it, and clicks
    next this panel will dissapear and the next panel will appear
    I will just put the form items in a panel, and then for the second tier, have another form 
    that is in another panel. Will use JS/AJAX to change from one to the other. The only things
    I will need databound controls for is when you need to pull info from database... for now, just 
    assume something can be hard coded until there is further notice. -->
    <asp:Label ID="lbl_mainheading" runat="server" Text="Every donation you make helps!" CssClass="page-heading" />
    <asp:UpdatePanel id="ajup_uinfo" runat="server" updatemode="conditional">
    <ContentTemplate>
    <asp:Panel runat="server" ID="pnl_uinfo" CssClass="donate-box">
        <!-- Will put main form here -->
        
        <!--First Name -->
        <asp:Label ID="lbl_fname" runat="server" Text="First Name" />
        <asp:TextBox ID="txt_fname" runat="server" /><br /><br />
        <asp:RequiredFieldValidator ID="rfv_fname" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_fname" />
        
        <!--Last Name -->
        <asp:Label ID="lbl_lname" runat="server" Text="Last Name" />
        <asp:TextBox ID="txt_lname" runat="server" /><br /><br />
        <asp:RequiredFieldValidator ID="rfv_lname" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_lname" />
        
        <!--Email Address -->
        <asp:Label ID="lbl_email" runat="server" Text="Email" />
        <asp:TextBox ID="txt_email" runat="server" /><br /><br />
        <asp:RequiredFieldValidator ID="rfv_email" runat="server" ErrorMessage="*Required" ControlToValidate="txt_email" />


        
        <asp:Label ID="lbl_mem" runat="server" Text="In Memory of"  />
        <asp:TextBox ID="txt_mem" runat="server" TextMode="MultiLine" /> <br /><br />  
        <%--Not Required A Required Field
        
        <%--Donation Amount--%>
        <asp:Label ID="lbl_donate" runat="server" Text="Donation Amount"  />
        <asp:TextBox ID="txt_donate" runat="server"  /><br /><br />
        <asp:RequiredFieldValidator ID="rfv_donate" runat="server" ErrorMessage="*Required" ControlToValidate="txt_donate" />
        <!-- Put in a validator for $ -->

       
        
        
        <!--Address -->
        <asp:Label ID="lbl_address" runat="server" Text="Address" />
        <asp:TextBox ID="txt_address" runat="server" /><br /><br />
        <asp:RequiredFieldValidator ID="rfv_address" runat="server" ErrorMessage="*Required" ControlToValidate="txt_address" />
        
        <!--City -->
        <asp:Label ID="lbl_city" runat="server" Text="City" />
        <asp:TextBox ID="txt_city" runat="server" /><br /><br />
        <asp:RequiredFieldValidator ID="rfv_city" runat="server" ErrorMessage="*Required" ControlToValidate="txt_city" />
        
        <!--Country-->
        <asp:Label ID="lbl_country" runat="server" Text="Country" />
            <asp:DropDownList ID="ddl_country" runat="server" OnSelectedIndexChanged="subCountryDisplayProvPost" AutoPostBack="true"  
             /><br /><br />
            <!-- Have to put data source into the ddl later, once I get the table set up -->
            <!-- Also will have to add in some events on select Including one to enable the province/state list and ZIP vs
            postal code -->
            <!-- Will need to do DDL validation as well -->

        <!--Province/ State -->
       <asp:Label ID="lbl_provstate" runat="server" Text="Prov/State" Visible="false" /><!-- Dependent on country -->
       <asp:DropDownList ID="ddl_provstate" runat="server" Visible="false" /><br /><br />
        <!-- This one will be a bit trickier, as it will be based on the selection made for country -->
        

        <!-- Postal Code/ZIP -->
            <asp:Label ID="lbl_postzip" runat="server" Text="PostalCode/ZIP" Visible="false" /><!-- dependent upon country -->
            <asp:TextBox ID="txt_postzip" runat="server" Visible="false" /><br /><br />
            <asp:RequiredFieldValidator ID="rfv_postzip" runat="server" ErrorMessage="*Required" ControlToValidate="txt_postzip" />

        
        <!--Comments -->
        <asp:Label ID="lbl_comments" runat="server" Text="Comments:" />
        <asp:TextBox ID="txt_comments" runat="server" TextMode="MultiLine" /><br /><br />
        <asp:RequiredFieldValidator ID="rfv_comments" runat="server" ErrorMessage="*Required" ControlToValidate="txt_comments" />    
 

        <asp:Button ID="btn_uinext" runat="server" Text="Next" OnClick="subNextUiClick"    />
    </asp:Panel>
    <%--</ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="btn_uinext" EventName="Click" />
    <asp:AsyncPostBackTrigger ControlID="ddl_country" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>--%>
    
    
    <!-- This Second Panel will include the second round view where the user will submit their credit
    card information ... a couple options I can have here would be that I can process the
    credit card myself in some way, and figure out how to do it so that it is encoded...
    and also, asynchronously when the individual enters their credit card number, after
    the first few numbers are entered, an image of the corresponding card company can appear  -->
    <%--<asp:UpdatePanel ID="ajup_credit" runat="server" UpdateMode="Conditional">
    <ContentTemplate>--%>
    <asp:Panel runat="server" ID="pnl_credit" CssClass="donate-box" Visible="false">
 
    <!-- Radio Button to see if billing information is the same as mailing address -->
        <asp:RadioButton ID="rbt_cred" runat="server" Checked="false" OnCheckedChanged="subTransferInfo" />
    
    <!-- Name - Text Box -->
    
    <asp:Label ID="lbl_credname" runat="server" Text="Billing Name" />
        <asp:TextBox ID="txt_credname" runat="server" /><br /><br />
        <asp:RequiredFieldValidator ID="rfv_credname" runat="server" ErrorMessage="*Required" 
        ControlToValidate="txt_credname" />

    <!-- Billing Address - Text Box -->
    <asp:Label ID="lbl_credaddress" runat="server" Text="Billing Address" />
        <asp:TextBox ID="txt_credaddress" runat="server" /><br /><br />
        <asp:RequiredFieldValidator ID="rfv_credaddress" runat="server" ErrorMessage="*Required" ControlToValidate="txt_credaddress" />

    <!-- Billing City - Text Box -->
    <asp:Label ID="lbl_credcity" runat="server" Text="City" />
        <asp:TextBox ID="txt_credcity" runat="server" /><br /><br />
        <asp:RequiredFieldValidator ID="rfv_credcity" runat="server" ErrorMessage="*Required" ControlToValidate="txt_credcity" />

    <!-- Billing Country - DDL -->
    <asp:Label ID="lbl_credcountry" runat="server" Text="Country" />
    <asp:DropDownList ID="ddl_credcountry" runat="server"  /><br /><br />

    <!-- Billing Province/State - DDL -->
    <asp:Label ID="lbl_credprovstate" runat="server" Text="Prov/State" /><!-- Dependent on country -->
       <asp:DropDownList ID="ddl_credprovstate" runat="server" /><br /><br />


    <!-- Billing PostalCode/ZIP - Text Box *** Label and Validation Dynamically Changes based on Country -->
    <%--<asp:Label ID="lbl_credpostzip" runat="server" Text="PostalCode/ZIP" /><!-- dependent upon country -->
            <asp:TextBox ID="txt_credpostzip" runat="server" /><br /><br />
            <asp:RequiredFieldValidator ID="rfv_credpostzip" runat="server" ErrorMessage="*Required" ControlToValidate="txt_credpostzip" />--%>

    <!-- Credit Card Number - Text Box *** Validation, Image Generation based on first few numbers, Encription -->
    <asp:Label ID="lbl_crednumber" runat="server" Text="Credit Card Number" /><!-- dependent upon country -->
            <asp:TextBox ID="txt_crednumber" runat="server" /><br /><br />
            <asp:RequiredFieldValidator ID="rfv_crednumber" runat="server" ErrorMessage="*Required" ControlToValidate="txt_crednumber" />
    
    <!-- Image choice of mastercard, visa or Amex, based on first few digits .... if it isn't one of them, have a popup that
    says sorry that type of card isn't accepted.
    will have to insert url based on type of card. -->
        <asp:Image ID="img_cred" runat="server" />
    
    <!-- Back of Card Code -->
     <asp:Label ID="lbl_credcode" runat="server" Text="Back of Card Code" /><!-- dependent upon country -->
            <asp:TextBox ID="txt_credcode" runat="server" /><br /><br />
            <asp:RequiredFieldValidator ID="rfv_credcode" runat="server" ErrorMessage="*Required" ControlToValidate="txt_credcode" />
   
    <!-- Next Button -->
   <asp:Button ID="btn_creditnext" runat="server" Text="Next" OnCommand="subNextCredClick"   />

    </asp:Panel>
    <%--</ContentTemplate>
    <Triggers><asp:AsyncPostBackTrigger ControlID="btn_creditnext" EventName="Click" /></Triggers>
    </asp:UpdatePanel>--%>
   
   
   <!-- the third panel will be a confirmation page that shows the submitted information, and upon submit an email receipt
   will get sent to the donor... there is an option for the donor name to show up on the homepage but that will contigent
   on time to finish it I will try and encode the credit card info -->
    <%--<asp:UpdatePanel ID="ajup_confirm" runat="server" UpdateMode="Conditional">
    <ContentTemplate>--%>
    <asp:Panel runat="server" ID="pnl_confirm" CssClass="donate-box" Visible="false">
    
    <!-- Use a data bound control here in order to display the records from the fist page -->
        Confirmation name <br />
        <!-- Confirmation Name -->
        <asp:Label ID="lbl_confname" runat="server"  /><br /><br />

        Donation Amount <br />
        <!-- Donation Amount -->
        <asp:Label ID="lbl_confamount" runat="server"  /><br /><br />

        Mailing Address <br />
        <!-- Mailing Address -->
        <asp:Label ID="lbl_confaddress" runat="server"  /><br /><br />

        Mailing Country <br />
        <!-- Mailing Country -->
        <asp:Label ID="lbl_confcountry" runat="server"  /><br /><br />

        Mailing Province/State <br />
        <!-- Mailing Province/State -->
        <asp:Label ID="lbl_confprovstate" runat="server"  /><br /><br />

        Email <br />
        <!-- Email Address -->
        <asp:Label ID="lbl_confemail" runat="server"  /><br /><br />

        Credit Card Number <br />
        <!-- Credit Card Number -->
        <asp:Label ID="lbl_confcnumber" runat="server"  />
    
    
    <!-- Include a Submit button -->

    <!-- Include a Cancel button -->
     
    </asp:Panel>
    <%--</ContentTemplate>
    <Triggers></Triggers>
    </asp:UpdatePanel>--%>

    <%--Will Have the image at bottom of the screen, but worry about this later - it will become clearer as you proceed through the
    form stages--%>
     </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="btn_uinext" EventName="Click" />
    <asp:AsyncPostBackTrigger ControlID="ddl_country" EventName="SelectedIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="btn_creditnext" EventName="Click" />

    </Triggers>
    </asp:UpdatePanel>
   </asp:Content>
   
