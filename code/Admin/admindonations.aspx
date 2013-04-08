<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="admindonations.aspx.cs" Inherits="Admindonations" %>

<asp:Content ID="cnt_addonhead" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="cnt_addonmain" ContentPlaceHolderID="content_area" Runat="Server">
    
    <asp:Panel ID="pnl_main" runat="server">
    <asp:ListView ID="lsv_main" runat="server" ItemPlaceholderID="plh_main"
     OnItemEditing="subItemEdit"  OnItemDeleting="subItemDelete" >
    <LayoutTemplate>
        <table>
            <thead>
            <th>
                <asp:LinkButton ID="btn_insert" Text="Insert New Record" runat="server" OnCommand="subInsertView" CommandName="InsertView" />
                
               
            </th>
            </thead>
            <tbody>
                <asp:PlaceHolder ID="plh_main" runat="server" />
            </tbody>
        </table>
    </LayoutTemplate>

    <ItemTemplate>
        <tr>
            <td>Item Template</td><td><asp:LinkButton ID="lkb_getedit" runat="server" Text="Edit" CommandName="Edit" /></td>
             <td><asp:LinkButton ID="lkb_delete" runat="server" Text="Delete" CommandName="Delete" /></td>
        </tr>
        <%--First Two rows for first half of info--%>
        <tr>
            <td>Donation ID</td><td>Mailing First Name</td><td>Mailing Last Name</td><td>Memory</td><td>Donation Amount</td>
            <td>Donor Email</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_donid" runat="server" Text='<%#Eval("d_id") %>' /></td>
                <td><asp:Label ID="lbl_mfname" runat="server" Text='<%#Eval("d_fname") %>' /></td>
                <td><asp:Label ID="lbl_mlname" runat="server" Text='<%#Eval("d_lname") %>' /></td>
                <td><asp:Label ID="lbl_memory" runat="server" Text='<%#Eval("d_in_memory_of") %>' /></td>
                <td><asp:Label ID="lbl_donamnt" runat="server" Text='<%#Eval("d_amount") %>' /></td>
                <td><asp:Label ID="lbl_email" runat="server" Text='<%#Eval("d_email") %>' /></td>
                
        </tr>

        <%--Second Two rows for second half of info--%>
        <tr>
            <td>Mailing Address</td><td>Mailing City</td><td>Mailing Prov/State</td><td>Mailing Postal/ZIP</td>
            <td>Billing Name</td><td>Credit Card Number</td>
        </tr>
        <tr>
            <td><asp:Label ID="lbl_maddress" runat="server" Text='<%#Eval("d_address_mailing") %>' /></td>
                <td><asp:Label ID="lbl_mcity" runat="server" Text='<%#Eval("d_city_mailing") %>' /></td>
                <td><asp:Label ID="lbl_mprovst" runat="server" Text='<%#Eval("d_provstate_mailing") %>' /></td>
                <td><asp:Label ID="lbl_mpostzip" runat="server" Text='<%#Eval("d_postzip_mailing") %>' /></td>
                <td><asp:Label ID="lbl_bname" runat="server" Text='<%#Eval("d_name_billing") %>' /></td>
                <td><asp:Label ID="lbl_ccnumber" runat="server" Text='<%#Eval("d_credit_number") %>' /></td>
                
        </tr>
        <%--Third two rows of data--%>
        <tr>
            <td>CC Expiry Date</td><td>Billing Address</td><td>Billing City</td><td>Billing Prov/State</td>
            <td>Billing Country</td>
        </tr>
        <tr>
            <td><asp:Label ID="lbl_ccedpiry" runat="server" Text='<%#Eval("d_credit_expiry") %>' /></td>
            <td><asp:Label ID="lbl_baddress" runat="server" Text='<%#Eval("d_address_billing") %>' /></td>
            <td><asp:Label ID="lbl_bcity" runat="server" Text='<%#Eval("d_city_billing") %>' /></td>
            <td><asp:Label ID="lbl_bprovstate" runat="server" Text='<%#Eval("d_provstate_billing") %>' /></td>
            <td><asp:Label ID="lbl_bcountry" runat="server" Text='<%#Eval("d_country_billing") %>' /></td>
        </tr>
    </ItemTemplate>

    <EditItemTemplate>
         <tr>
            <td>Item Template</td><td><asp:LinkButton ID="lkb_getedit" runat="server" Text="Edit" CommandName="Edit" /></td>
             <td><asp:LinkButton ID="lkb_delete" runat="server" Text="Delete" CommandName="Delete" /></td>
        </tr>
        <%--First Two rows for first half of info--%>
        <tr>
            <td>Donation ID</td><td>Mailing First Name</td><td>Mailing Last Name</td><td>Memory</td><td>Donation Amount</td>
            <td>Donor Email</td>
        </tr>
        <tr>
            <td>
                <asp:Textbox ID="txt_edonid" runat="server" Text='<%#Eval("d_id") %>' /></td>
                <td><asp:Textbox ID="txt_emfname" runat="server" Text='<%#Eval("d_fname") %>' /></td>
                <td><asp:Textbox ID="txt_emlname" runat="server" Text='<%#Eval("d_lname") %>' /></td>
                <td><asp:Textbox ID="txt_ememory" runat="server" Text='<%#Eval("d_in_memory_of") %>' /></td>
                <td><asp:Textbox ID="txt_edonamnt" runat="server" Text='<%#Eval("d_amount") %>' /></td>
                <td><asp:Textbox ID="txt_eemail" runat="server" Text='<%#Eval("d_email") %>' /></td>
                
        </tr>

        <%--Second Two rows for second half of info--%>
        <tr>
            <td>Mailing Address</td><td>Mailing City</td><td>Mailing Prov/State</td><td>Mailing Postal/ZIP</td>
            <td>Billing Name</td><td>Credit Card Number</td>
        </tr>
        <tr>
            <td><asp:Textbox ID="txt_emaddress" runat="server" Text='<%#Eval("d_address_mailing") %>' /></td>
                <td><asp:Textbox ID="txt_emcity" runat="server" Text='<%#Eval("d_city_mailing") %>' /></td>
                <td><asp:Textbox ID="txt_emprovst" runat="server" Text='<%#Eval("d_provstate_mailing") %>' /></td>
                <td><asp:Textbox ID="txt_empostzip" runat="server" Text='<%#Eval("d_postzip_mailing") %>' /></td>
                <td><asp:Textbox ID="txt_ebname" runat="server" Text='<%#Eval("d_name_billing") %>' /></td>
                <td><asp:Textbox ID="txt_eccnumber" runat="server" Text='<%#Eval("d_credit_number") %>' /></td>
                
        </tr>
        <%--Third two rows of data--%>
        <tr>
            <td>CC Expiry Date</td><td>Billing Address</td><td>Billing City</td><td>Billing Prov/State</td>
            <td>Billing Country</td>
        </tr>
        <tr>
            <td><asp:Textbox ID="txt_eccedpiry" runat="server" Text='<%#Eval("d_credit_expiry") %>' /></td>
            <td><asp:Textbox ID="txt_ebaddress" runat="server" Text='<%#Eval("d_address_billing") %>' /></td>
            <td><asp:Textbox ID="txt_ebcity" runat="server" Text='<%#Eval("d_city_billing") %>' /></td>
            <td><asp:Textbox ID="txt_ebprovstate" runat="server" Text='<%#Eval("d_provstate_billing") %>' /></td>
            <td><asp:Textbox ID="txt_ebcountry" runat="server" Text='<%#Eval("d_country_billing") %>' /></td>
        </tr>
    
    </EditItemTemplate>

    <%--Put in a data pager here--%>
    
    </asp:ListView>
    </asp:Panel>

    <asp:Panel ID="pnl_insert" runat="server" Visible="false">
    <table>
        
        <%--First Two rows for first half of info--%>
        <tr>
            <td>Donation ID</td><td>Mailing First Name</td><td>Mailing Last Name</td><td>Memory</td><td>Donation Amount</td>
            <td>Donor Email</td>
        </tr>
        <tr>
            <td>
                <asp:Textbox ID="txt_idonid" runat="server"  /></td>
                <td><asp:Textbox ID="txt_imfname" runat="server"  /></td>
                <td><asp:Textbox ID="txt_imlname" runat="server"  /></td>
                <td><asp:Textbox ID="txt_imemory" runat="server"  /></td>
                <td><asp:Textbox ID="txt_idonamnt" runat="server"  /></td>
                <td><asp:Textbox ID="txt_iemail" runat="server"  /></td>
                
        </tr>

        <%--Second Two rows for second half of info--%>
        <tr>
            <td>Mailing Address</td><td>Mailing City</td><td>Mailing Prov/State</td><td>Mailing Postal/ZIP</td>
            <td>Billing Name</td><td>Credit Card Number</td>
        </tr>
        <tr>
            <td><asp:Textbox ID="txt_imaddress" runat="server"  /></td>
                <td><asp:Textbox ID="txt_imcity" runat="server"  /></td>
                <td><asp:Textbox ID="txt_improvst" runat="server"  /></td>
                <td><asp:Textbox ID="txt_impostzip" runat="server"  /></td>
                <td><asp:Textbox ID="txt_ibname" runat="server"  /></td>
                <td><asp:Textbox ID="txt_iccnumber" runat="server"  /></td>
                
        </tr>
        <%--Third two rows of data--%>
        <tr>
            <td>CC Expiry Date</td><td>Billing Address</td><td>Billing City</td><td>Billing Prov/State</td>
            <td>Billing Country</td>
        </tr>
        <tr>
            <td><asp:Textbox ID="txt_iccedpiry" runat="server"  /></td>
            <td><asp:Textbox ID="txt_ibaddress" runat="server"  /></td>
            <td><asp:Textbox ID="txt_ibcity" runat="server"  /></td>
            <td><asp:Textbox ID="txt_ibprovstate" runat="server"  /></td>
            <td><asp:Textbox ID="txt_ibcountry" runat="server"  /></td>
        </tr>
    </table>
    </asp:Panel>

</asp:Content>

