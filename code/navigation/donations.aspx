<%@ Page Language="C#" AutoEventWireup="true" CodeFile="donations.aspx.cs" Inherits="donations" MasterPageFile="~/maintemplate.master"  %>
<asp:Content ID="cnt_headdonate" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
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
        <asp:TextBox ID="txt_fname" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_fname" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_fname" ValidationGroup="mailingView" Display="Dynamic" /><br /><br />
        
        <!--Last Name -->
        <asp:Label ID="lbl_lname" runat="server" Text="Last Name" />
        <asp:TextBox ID="txt_lname" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_lname" runat="server" 
        ErrorMessage="*Required" ControlToValidate="txt_lname" ValidationGroup="mailingView" Display="Dynamic" /><br /><br />
        
        <!--Email Address -->
        <asp:Label ID="lbl_email" runat="server" Text="Email" />
        <asp:TextBox ID="txt_email" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_email" runat="server" ErrorMessage="*Required" ControlToValidate="txt_email"
        ValidationGroup="mailingView" Display="Dynamic" />
       
        
        <asp:RegularExpressionValidator ID="rev_email" runat="server" ErrorMessage="*Please Enter Valid Email Address" 
        ValidationGroup="mailingView" Display="Dynamic" ValidationExpression="^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$" ControlToValidate="txt_email"/>
        <br /><br />


        
        <asp:Label ID="lbl_mem" runat="server" Text="In Memory of"  />
        <asp:TextBox ID="txt_mem" runat="server" TextMode="MultiLine" /> <br /><br />  
        <%--Not Required A Required Field
        
        <%--Donation Amount--%>
        <asp:Label ID="lbl_donate" runat="server" Text="Donation Amount (Numeric value, in CDN Dollars)"  />
        <asp:TextBox ID="txt_donate" runat="server"  />
        <asp:RequiredFieldValidator ID="rfv_donate" runat="server" ErrorMessage="*Required" ControlToValidate="txt_donate"
        ValidationGroup="mailingView" Display="Dynamic"   />
        <asp:CompareValidator ID="cmv_donate" runat="server"  ControlToValidate="txt_donate" Operator="DataTypeCheck"  Type="Double"
        ErrorMessage="*Please enter Numeric value of donation (in CDN dollars)" ValidationGroup="mailingView" /><br /><br />
        <!-- Put in a validator for $ -->

       
        
        
        <!--Address -->
        <asp:Label ID="lbl_address" runat="server" Text="Address" />
        <asp:TextBox ID="txt_address" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_address" runat="server" ErrorMessage="*Required" ControlToValidate="txt_address"
        ValidationGroup="mailingView" Display="Dynamic" /><br /><br />
        
        <!--City -->
        <asp:Label ID="lbl_city" runat="server" Text="City" />
        <asp:TextBox ID="txt_city" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_city" runat="server" ErrorMessage="*Required" ControlToValidate="txt_city"
        ValidationGroup="mailingView" Display="Dynamic" /><br /><br />
        
        <!--Country-->
        <asp:Label ID="lbl_country" runat="server" Text="Country" />
            <asp:DropDownList ID="ddl_country" runat="server" OnSelectedIndexChanged="subCountryDisplayProvPost" AutoPostBack="true"  
             />
        
             <br /><br />
            <!-- Have to put data source into the ddl later, once I get the table set up -->
            <!-- Also will have to add in some events on select Including one to enable the province/state list and ZIP vs
            postal code -->
            <!-- Will need to do DDL validation as well -->

        <!--Province/ State -->
       <asp:Label ID="lbl_provstate" runat="server" Text="Prov/State" Visible="false" /><!-- Dependent on country -->
       <asp:DropDownList ID="ddl_provstate" runat="server" Visible="false"   /><br /><br />
        <!-- This one will be a bit trickier, as it will be based on the selection made for country -->
        <%--Hold off on validation here, because not everyone will have this--%>

        <!-- Postal Code/ZIP -->
            <asp:Label ID="lbl_postzip" runat="server" Text="PostalCode/ZIP" Visible="false" /><!-- dependent upon country -->
            <asp:TextBox ID="txt_postzip" runat="server" Visible="false"  />
           <%--Required Field validation if the country is either US or Canada--%>
        <asp:RequiredFieldValidator ID="rfv_postzip" Display="Dynamic" ValidationGroup="mailingView" runat="server" ErrorMessage="*Required" 
        Enabled="false" ControlToValidate="txt_postzip" />
        <%--Zip Code Regex validation if the country is US--%>
        <asp:RegularExpressionValidator ID="rev_postzipus" runat="server" Display="Dynamic" ErrorMessage="*Please enter a valid ZIP Code" ValidationGroup="mailingView"
        ControlToValidate="txt_postzip" Enabled="false" ValidationExpression="^\d{5}$" />
        <%--Postal Code Regex validation if the country is Canada--%>
        <asp:RegularExpressionValidator ID="rev_postzipcdn" runat="server" Display="Dynamic" ErrorMessage="*Please enter a valid Postal Code" ValidationGroup="mailingView"
        ControlToValidate="txt_postzip" Enabled="false" ValidationExpression="^([A-Za-z]\d[A-Za-z][-]?\d[A-Za-z]\d)" /><br /><br />
 

        <asp:Button ID="btn_uinext" runat="server" Text="Next" OnClick="subNextUiClick" ValidationGroup="mailingView"    />
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
 
    <!-- Button to see if billing information is the same as mailing address -->
        <asp:Button ID="btn_cred" runat="server" Text="*"  OnClick="subTransferInfo" />
    * Click here if billing information is the same as mailing info <br /><br />
    <!-- Name - Text Box -->
    
    <asp:Label ID="lbl_credname" runat="server" Text="Billing Name" />
        <asp:TextBox ID="txt_credname" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_credname" runat="server" ErrorMessage="*Required" 
        ControlToValidate="txt_credname" ValidationGroup="billingView" Display="Dynamic" /><br /><br />

    <!-- Billing Address - Text Box -->
    <asp:Label ID="lbl_credaddress" runat="server" Text="Billing Address" />
        <asp:TextBox ID="txt_credaddress" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_credaddress" runat="server" ErrorMessage="*Required" ControlToValidate="txt_credaddress"
        ValidationGroup="billingView" Display="Dynamic" /><br /><br />

    <!-- Billing City - Text Box -->
    <asp:Label ID="lbl_credcity" runat="server" Text="City" />
        <asp:TextBox ID="txt_credcity" runat="server" />
        <asp:RequiredFieldValidator ID="rfv_credcity" runat="server" ErrorMessage="*Required" ControlToValidate="txt_credcity"
        ValidationGroup="billingView" Display="Dynamic" /><br /><br />

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
            <asp:TextBox ID="txt_crednumber" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_crednumber" runat="server" ErrorMessage="*Required" ControlToValidate="txt_crednumber"
            ValidationGroup="billingView" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="rev_crednumber" runat="server" ErrorMessage="*Please Enter Valid Credit Card Number" 
        ValidationGroup="billingView" ControlToValidate="txt_crednumber" Display="Dynamic" 
        ValidationExpression="^((4\d{3})|(5[1-5]\d{2})|(6011))-?\d{4}-?\d{4}-?\d{4}|3[4,7]\d{13}$" />
            <br /><br />
    
    
    
    
   
    <!-- Next Button -->
   <asp:Button ID="btn_creditnext" runat="server" Text="Next" OnCommand="subNextCredClick" ValidationGroup="billingView"   />

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
        Donation/Mailing Info: <br /><br />
        First Name:&nbsp;
         <asp:Label ID="lbl_mfname" runat="server"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Last Name:&nbsp;
         <asp:Label ID="lbl_mlname" runat="server"  /><br /><br />
        In Memory of:&nbsp;
         <asp:Label ID="lbl_mmemory" runat="server"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        Donation Amount:&nbsp;
        <!-- Donation Amount -->
        <asp:Label ID="lbl_confamount" runat="server"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        Mailing Address:&nbsp;
        <!-- Mailing Address -->
        <asp:Label ID="lbl_maddress" runat="server"  /><br /><br />

        Mailing Country:&nbsp;
        <!-- Mailing Country -->
        <asp:Label ID="lbl_mcountry" runat="server"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        Mailing Province/State:&nbsp;
        <!-- Mailing Province/State -->
        <asp:Label ID="lbl_mprovstate" runat="server"  /><br /><br />

        Mailing Postal/ZIP:&nbsp;
         <asp:Label ID="lbl_mpostzip" runat="server"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Mailing City:&nbsp;
         <asp:Label ID="lbl_mcity" runat="server"  /><br /><br />
        Email:&nbsp;
        <!-- Email Address -->
        <asp:Label ID="lbl_confemail" runat="server"  /><br /><br />

        Billing Info:<br /><br />
         
        Billing Name:&nbsp;
        <!-- Confirmation Name -->
        <asp:Label ID="lbl_billname" runat="server"  />&nbsp;&nbsp;

        Credit Card Number:&nbsp;
        <!-- Credit Card Number -->
        <asp:Label ID="lbl_confcnumber" runat="server"  /><br /><br />

       <%-- Don't Worry about this for now--%>
        <%--Credit Card Expiry Date:--%>

        Billing Address:&nbsp;
         <asp:Label ID="lbl_baddress" runat="server"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Billing City:&nbsp;
         <asp:Label ID="lbl_bcity" runat="server"  /><br /><br />
        Billing Country:&nbsp;
         <asp:Label ID="lbl_bcountry" runat="server"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Billing Province/State:&nbsp;
         <asp:Label ID="lbl_bprovstate" runat="server"  /><br /><br />
        <%--Hold off on this one for now, till I get things totally working properly--%>
       <%-- Billing Postal/ZIP:--%>


    
    
    <!-- Include a Submit button -->
        <asp:Button ID="btn_submit" runat="server" Text="Submit" OnCommand="subConfPgAction" CommandName="Submit" />&nbsp;&nbsp;
    <!-- Include a Cancel button -->
    <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnCommand="subConfPgAction" CommandName="Cancel" />
     
    </asp:Panel>
    <%--</ContentTemplate>
    <Triggers></Triggers>
    </asp:UpdatePanel>--%>

    <%--Will Have the image at bottom of the screen, but worry about this later - it will become clearer as you proceed through the
    form stages--%>
    <asp:Label ID="lbl_execmess" runat="server"  />
     </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="btn_uinext" EventName="Click" />
    <asp:AsyncPostBackTrigger ControlID="ddl_country" EventName="SelectedIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="btn_creditnext" EventName="Click" />
    <asp:asyncpostbacktrigger controlid="btn_submit" eventname="command" />
    <asp:asyncpostbacktrigger controlid="btn_cancel" eventname="command" />
    <asp:AsyncPostBackTrigger ControlID="btn_cred" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>

    
   </asp:Content>
   
