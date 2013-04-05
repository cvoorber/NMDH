<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="viewcart.aspx.cs" Inherits="navigation_viewcart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_area" Runat="Server">
<asp:Panel ID="pnl_order" runat="server">
    <h1>NDMH Giftshop - Your Current Shopping Cart</h1>
    <asp:HyperLink ID="hyp_return" runat="server" Text="Continue Shopping" NavigateUrl="giftshop.aspx" Font-Size="14" Style="margin-left:10px;" />
    <br />
    <br />  
    <asp:GridView runat="server" ID="gridCart" AutoGenerateColumns="false" EmptyDataText="Your Shopping Cart is empty." GridLines="None" Width="100%" CellPadding="5" CellSpacing="5" ShowFooter="true" DataKeyNames="ProductId" OnRowDataBound="gridCart_RowDataBound" OnRowCommand="gridCart_RowCommand" Font-Size="12" CssClass="cartStyle" RowStyle-Height="60" BackColor="White">  
        <HeaderStyle Font-Size="15" Font-Bold="true" HorizontalAlign="Left" BackColor="#11c1a2" ForeColor="#000" Height="25" />  
        <FooterStyle Font-Size="15" Font-Bold="true" HorizontalAlign="Right" BackColor="#6C6B66" ForeColor="#FFFFFF" Height="25" /> 
        <AlternatingRowStyle BackColor="LightGray" />  
        <Columns>
            <asp:BoundField DataField="Description" HeaderText="Description" />  
            <asp:TemplateField HeaderText="Quantity">  
                <ItemTemplate>  
                    <asp:TextBox runat="server" ID="txt_quantity" Columns="5" Text='<%# Eval("Quantity") %>'></asp:TextBox>&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="btnRemove" Text="Remove All" CommandName="Remove" CommandArgument='<%# Eval("ProductId") %>' style="font-size:14px;"></asp:LinkButton>
                </ItemTemplate>  
            </asp:TemplateField>  
            <asp:BoundField DataField="UnitPrice" HeaderText="Price" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />  
            <asp:BoundField DataField="TotalPrice" HeaderText="Total" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />  
        </Columns>  
    </asp:GridView>
    <br />  
    <asp:Button runat="server" ID="btnUpdateCart" Text="Update Cart" Style="float:right;" OnClick="btnSubUpdate" />  
    <br /><br />
    <asp:Button runat="server" ID="btnCheckout" Text="Checkout" Style="float:right;" OnClick="btnSubCheckout" />
</asp:Panel>

<asp:Panel ID="pnl_checkout" runat="server" Style="margin-left:150px;">
<span style="float:left;">Not Ready for Committment? Click here --></span><asp:Button ID="btn_backtocart" runat="server" Text="Return To Cart" OnClick="backtocart" />
    <br /><br />
    <h1>Ready to Checkout? Please Fill in the Form Below.</h1>
    <asp:Label ID="lbl_sendErr" runat="server" />
    <table width="550">
        <tr>
            <%-- Name field --%>
            <td><asp:Label ID="lbl_name" runat="server" Text="Full Name on Credit Card:  " AssociatedControlID="txt_name" /></td>
            <td><asp:TextBox ID="txt_name" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_name" runat="server" ControlToValidate="txt_name" Text="*Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="subForm" /></td>
        </tr>
        <tr>
            <%-- Credit card field --%>
            <td><asp:Label ID="lbl_credit" runat="server" Text="Credit Card Number:  " AssociatedControlID="txt_credit" /></td>
            <td><asp:TextBox ID="txt_credit" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_credit" runat="server" ControlToValidate="txt_credit" Text="*Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="subForm" />
            <asp:RegularExpressionValidator ID="rev_credit" runat="server" Text="Invalid Credit Card Number" ControlToValidate="txt_credit" Display="Dynamic" ValidationExpression="^((67\d{2})|(4\d{3})|(5[1-5]\d{2})|(6011))-?\s?\d{4}-?\s?\d{4}-?\s?\d{4}|3[4,7]\d{13}$" ErrorMessage="Please enter a valid credit card number." ValidationGroup="subForm" /></td>
        </tr>
        <tr>
            <%-- Expiry field --%>
            <td><asp:Label ID="lbl_expiry" runat="server" Text="Expiry Date:  " AssociatedControlID="txt_expiry" /></td>
            <td><asp:TextBox ID="txt_expiry" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_expiry" runat="server" ControlToValidate="txt_expiry" Text="*Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="subForm" /></td>
        </tr>
        <tr>
            <%-- CVV field --%>
            <td><asp:Label ID="lbl_cvv" runat="server" Text="CVV Security:  " AssociatedControlID="txt_cvv" /></td>
            <td><asp:TextBox ID="txt_cvv" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_cvv" runat="server" ControlToValidate="txt_cvv" Text="*Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="subForm" /></td>
        </tr>
        <tr>
            <%-- Address field --%>
            <td><asp:Label ID="lbl_address" runat="server" Text="Address:  " AssociatedControlID="txt_address" /></td>
            <td><asp:TextBox ID="txt_address" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_address" runat="server" ControlToValidate="txt_address" Text="*Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="subForm" /></td>
        </tr>
        <tr>
            <%-- City field --%>
            <td><asp:Label ID="lbl_city" runat="server" Text="City:  " AssociatedControlID="txt_city" /></td>
            <td><asp:TextBox ID="txt_city" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_city" runat="server" ControlToValidate="txt_city" Text="*Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="subForm" /></td>
        </tr>
        <tr>
            <%-- Postal Code field --%>
            <td><asp:Label ID="lbl_postal" runat="server" Text="Postal Code:  " AssociatedControlID="txt_postal" /></td>
            <td><asp:TextBox ID="txt_postal" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_postal" runat="server" ControlToValidate="txt_postal" Text="*Required" Display="Dynamic" SetFocusOnError="true" ValidationGroup="subForm" />
            <asp:RegularExpressionValidator ID="rev_postal" runat="server" Text="Invalid Postal Code" ControlToValidate="txt_postal" Display="Dynamic" ValidationExpression="^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]{1}\d{1}[A-Za-z]{1}\d{1}[A-Za-z]{1}\d{1}$" ErrorMessage="Please enter a valid postal code." ValidationGroup="subForm" /></td>
        </tr>
        <tr>
            <%-- Province field --%>
            <td><asp:Label ID="lbl_province" runat="server" Text="Province:  " /></td>
            <td><asp:DropDownList ID="ddl_province" runat="server" AutoPostBack="false">
                    <asp:ListItem Value="0" Text="*Please Choose*" />
                    <asp:ListItem Value="AB" Text="Alberta" />
                    <asp:ListItem Value="BC" Text="British Columbia" />
                    <asp:ListItem Value="MB" Text="Manitoba" />
                    <asp:ListItem Value="NB" Text="New Brunswick" />
                    <asp:ListItem Value="NL" Text="Newfoundland & Labrador" />
                    <asp:ListItem Value="NT" Text="Northwest Territories" />
                    <asp:ListItem Value="NS" Text="Nova Scotia" />
                    <asp:ListItem Value="NU" Text="Nunavut" />
                    <asp:ListItem Value="ON" Text="Ontario" />
                    <asp:ListItem Value="PE" Text="Prince Edward Island" />
                    <asp:ListItem Value="QC" Text="Quebec" />
                    <asp:ListItem Value="SK" Text="Saskatchewan" />
                    <asp:ListItem Value="YT" Text="Yukon Territory" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfv_province" runat="server" Text="*Required" ErrorMessage="Province is required" ControlToValidate="ddl_province" Display="Dynamic" SetFocusOnError="true" ValidationGroup="subForm" />
                <asp:RegularExpressionValidator ID="rev_province" runat="server" Text="*Invalid" ControlToValidate="ddl_province" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^([ \u00c0-\u01ffa-zA-Z'])+$" ValidationGroup="subForm" />
                            </td>
        </tr>
        <tr>
            <%-- Email field --%>
            <td><asp:Label ID="lbl_email" runat="server" Text="Email address:  " AssociatedControlID="txt_email" /></td>
            <td><asp:TextBox ID="txt_email" runat="server" />
            <%-- regular express check for email --%>
            <asp:RegularExpressionValidator ID="rev_email" runat="server" Text="Invalid email" ControlToValidate="txt_email" Display="Dynamic" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ErrorMessage="Please enter a valid email address." ValidationGroup="subForm" />
            <asp:RequiredFieldValidator ID="rfv_email" runat="server" Text="*Required" ControlToValidate="txt_email" Display="Dynamic" SetFocusOnError="true" ValidationGroup="subForm" /></td>
        </tr>
        <tr>
            <%-- Email repeat field --%>
            <td><asp:Label ID="lbl_emailrepeat" runat="server" Text="Email confirm:  " AssociatedControlID="txt_emailrepeat" /></td>
            <td><asp:TextBox ID="txt_emailrepeat" runat="server" />
            <asp:RequiredFieldValidator ID="rfv_emailrepeat" runat="server" Text="*Required" ControlToValidate="txt_emailrepeat" Display="Dynamic" SetFocusOnError="true" ValidationGroup="subForm" />
            <%-- comparing to previous email --%>
            <asp:CompareValidator ID="cov_email" runat="server" Text="*Email addresses do NOT match!" ControlToValidate="txt_emailrepeat" ControlToCompare="txt_email" Operator="Equal" ValidationGroup="subForm" /></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btn_clear" runat="server" Text="Clear Form" OnClick="clearForm" />&nbsp;&nbsp;<asp:Button ID="btn_submit" runat="server" Text="Submit" ValidationGroup="subForm" OnClientClick="return confirm('Confirm Purchase?');" OnClick="subOrder" /></td>
        </tr>
    </table>
    <br />
    <asp:ValidationSummary ValidationGroup="subForm" ID="vds_1" runat="server" HeaderText="The Form Contains Errors" ForeColor="Red" />    
</asp:Panel>
</asp:Content>

