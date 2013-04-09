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
    <asp:ListView ID="lsv_main" runat="server" ItemPlaceholderID="plh_main" >
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
            <td><asp:LinkButton ID="lkb_getedit" runat="server" Text="Edit" CommandName="EditView" OnCommand="subEditView" CommandArgument='<%#Eval("d_id") %>' /></td>
             <td><asp:LinkButton ID="lkb_delete" runat="server" Text="Delete" OnCommand="subItemDelete" CommandArgument='<%#Eval("d_id") %>' 
             CommandName="DeleteDon" OnClientClick="return confirm('Are you sure you want to delete this Donation Record?');" /></td>
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
    <%--Put in a data pager here--%>
    
    </asp:ListView>
    </asp:Panel>

    <asp:Panel ID="pnl_insert" runat="server" Visible="false">
    <table>
        
        <tr>
        <td>
            <asp:Button ID="lbl_icreate" runat="server" OnCommand="subInsertAction" CommandName="Create" Text="Create New Record" ValidationGroup="insertView" /></td>
            <td>
                <asp:Button ID="lbl_cancel" runat="server" Text="Cancel" CommandName="Cancel" OnCommand="subInsertAction" /></td>
        </tr>
        <%--First Two rows for first half of info--%>
        <tr>
            <td>Mailing First Name</td><td>Mailing Last Name</td><td>Memory</td><td>Donation Amount</td>
            <td>Donor Email</td>
        </tr>
        <tr>
            
                
                <td><asp:Textbox ID="txt_imfname" runat="server"  />
                 <asp:RequiredFieldValidator ID="rfv_imfname" runat="server" ErrorMessage="*Required" ControlToValidate="txt_imfname" 
                 ValidationGroup="insertView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_imlname" runat="server"  />
                <asp:RequiredFieldValidator ID="rfv_imlname" runat="server" ErrorMessage="*Required" ControlToValidate="txt_imlname" 
                 ValidationGroup="insertView" Display="Dynamic" /></td>
                <td><asp:Textbox ID="txt_imemory" runat="server"  />
                </td>
                <td><asp:Textbox ID="txt_idonamnt" runat="server"  />
                <asp:RequiredFieldValidator ID="rfv_idonamnt" runat="server" ErrorMessage="*Required" ControlToValidate="txt_idonamnt" 
                 ValidationGroup="insertView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_iemail" runat="server"  />
                <asp:RequiredFieldValidator ID="rfv_iemail" runat="server" ErrorMessage="*Required" ControlToValidate="txt_iemail" 
                 ValidationGroup="insertView" Display="Dynamic" />
                </td>
                
        </tr>

        <%--Second Two rows for second half of info--%>
        <tr>
            <td>Mailing Address</td><td>Mailing City</td><td>Mailing Prov/State</td><td>Mailing Postal/ZIP</td>
            <td>Billing Name</td><td>Credit Card Number</td>
        </tr>
        <tr>
            <td><asp:Textbox ID="txt_imaddress" runat="server"  />
            <asp:RequiredFieldValidator ID="rfv_imaddress" runat="server" ErrorMessage="*Required" ControlToValidate="txt_imaddress" 
                 ValidationGroup="insertView" Display="Dynamic" />
            </td>
                <td><asp:Textbox ID="txt_imcity" runat="server"  />
                <asp:RequiredFieldValidator ID="rfv_imcity" runat="server" ErrorMessage="*Required" ControlToValidate="txt_imcity" 
                 ValidationGroup="insertView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_improvst" runat="server"  />
                <asp:RequiredFieldValidator ID="rfv_improvst" runat="server" ErrorMessage="*Required" ControlToValidate="txt_improvst" 
                 ValidationGroup="insertView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_impostzip" runat="server"  />
                <asp:RequiredFieldValidator ID="rfv_impostzip" runat="server" ErrorMessage="*Required" ControlToValidate="txt_impostzip" 
                 ValidationGroup="insertView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_ibname" runat="server"  />
                <asp:RequiredFieldValidator ID="rfv_ibname" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ibname" 
                 ValidationGroup="insertView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_iccnumber" runat="server"  />
                <asp:RequiredFieldValidator ID="rfv_iccnumber" runat="server" ErrorMessage="*Required" ControlToValidate="txt_iccnumber" 
                 ValidationGroup="insertView" Display="Dynamic" />
                </td>
                
        </tr>
        <%--Third two rows of data--%>
        <tr>
            <td>CC Expiry Date</td><td>Billing Address</td><td>Billing City</td><td>Billing Prov/State</td>
            <td>Billing Country</td>
        </tr>
        <tr>
            <td><asp:Textbox ID="txt_iccedpiry" runat="server"  />
            
            </td>
            <td><asp:Textbox ID="txt_ibaddress" runat="server"  />
            <asp:RequiredFieldValidator ID="rfv_ibaddress" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ibaddress" 
                 ValidationGroup="insertView" Display="Dynamic" />
            </td>
            <td><asp:Textbox ID="txt_ibcity" runat="server"  />
            <asp:RequiredFieldValidator ID="rfv_ibcity" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ibcity" 
                 ValidationGroup="insertView" Display="Dynamic" />
            </td>
            <td><asp:Textbox ID="txt_ibprovstate" runat="server"  />
            <asp:RequiredFieldValidator ID="rfv_ibprovstate" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ibprovstate" 
                 ValidationGroup="insertView" Display="Dynamic" />
            </td>
            <td><asp:Textbox ID="txt_ibcountry" runat="server"  />
            <asp:RequiredFieldValidator ID="rfv_ibcountry" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ibcountry" 
                 ValidationGroup="insertView" Display="Dynamic" />
            </td>
        </tr>
    </table>
    </asp:Panel>

    <asp:Panel ID="pnl_edit" runat="server" Visible="false">
        <asp:Repeater ID="rpt_edit" runat="server" OnItemCommand="subEditAction">
        <ItemTemplate>
           <table>
            <tr>
            <td><asp:LinkButton ID="lkb_getedit" runat="server"  Text="Update" CommandArgument='<%#Eval("d_id") %>' 
            CommandName="Update" ValidationGroup="editView" /></td>
             <td><asp:LinkButton ID="lkb_cancel" runat="server" Text="Cancel" CommandName="Cancel" /></td>
        </tr>
        <%--First Two rows for first half of info--%>
        <tr>
            <td>Mailing First Name</td><td>Mailing Last Name</td><td>Memory</td><td>Donation Amount</td>
            <td>Donor Email</td>
        </tr>
        <tr>
            
                
                <td><asp:Textbox ID="txt_emfname" runat="server" Text='<%#Eval("d_fname") %>' />
                <asp:RequiredFieldValidator ID="rfv_emfname" runat="server" ErrorMessage="*Required" ControlToValidate="txt_emfname" 
                 ValidationGroup="editView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_emlname" runat="server" Text='<%#Eval("d_lname") %>' />
                <asp:RequiredFieldValidator ID="rfv_emlname" runat="server" ErrorMessage="*Required" ControlToValidate="txt_emlname" 
                 ValidationGroup="editView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_ememory" runat="server" Text='<%#Eval("d_in_memory_of") %>' />
                </td>
                <td><asp:Textbox ID="txt_edonamnt" runat="server" Text='<%#Eval("d_amount") %>' />
                <asp:RequiredFieldValidator ID="rfv_edonamnt" runat="server" ErrorMessage="*Required" ControlToValidate="txt_edonamnt" 
                 ValidationGroup="editView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_eemail" runat="server" Text='<%#Eval("d_email") %>' />
                <asp:RequiredFieldValidator ID="rfv_eemail" runat="server" ErrorMessage="*Required" ControlToValidate="txt_eemail" 
                 ValidationGroup="editView" Display="Dynamic" />
                </td>
                
        </tr>

        <%--Second Two rows for second half of info--%>
        <tr>
            <td>Mailing Address</td><td>Mailing City</td><td>Mailing Prov/State</td><td>Mailing Postal/ZIP</td>
            <td>Billing Name</td><td>Credit Card Number</td>
        </tr>
        <tr>
            <td><asp:Textbox ID="txt_emaddress" runat="server" Text='<%#Eval("d_address_mailing") %>' />
            <asp:RequiredFieldValidator ID="rfv_emaddress" runat="server" ErrorMessage="*Required" ControlToValidate="txt_emaddress" 
                 ValidationGroup="editView" Display="Dynamic" />
            </td>
                <td><asp:Textbox ID="txt_emcity" runat="server" Text='<%#Eval("d_city_mailing") %>' />
                <asp:RequiredFieldValidator ID="rfv_emcity" runat="server" ErrorMessage="*Required" ControlToValidate="txt_emcity" 
                 ValidationGroup="editView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_emprovst" runat="server" Text='<%#Eval("d_provstate_mailing") %>' />
                <asp:RequiredFieldValidator ID="rfv_emprovst" runat="server" ErrorMessage="*Required" ControlToValidate="txt_emprovst" 
                 ValidationGroup="editView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_empostzip" runat="server" Text='<%#Eval("d_postzip_mailing") %>' />
                <asp:RequiredFieldValidator ID="rfv_empostzip" runat="server" ErrorMessage="*Required" ControlToValidate="txt_empostzip" 
                 ValidationGroup="editView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_ebname" runat="server" Text='<%#Eval("d_name_billing") %>' />
                <asp:RequiredFieldValidator ID="rfv_ebname" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ebname" 
                 ValidationGroup="editView" Display="Dynamic" />
                </td>
                <td><asp:Textbox ID="txt_eccnumber" runat="server" Text='<%#Eval("d_credit_number") %>' />
                <asp:RequiredFieldValidator ID="rfv_eccnumber" runat="server" ErrorMessage="*Required" ControlToValidate="txt_eccnumber" 
                 ValidationGroup="editView" Display="Dynamic" />
                </td>
                
        </tr>
        <%--Third two rows of data--%>
        <tr>
            <td>CC Expiry Date</td><td>Billing Address</td><td>Billing City</td><td>Billing Prov/State</td>
            <td>Billing Country</td>
        </tr>
        <tr>
            <td><asp:Textbox ID="txt_eccedpiry" runat="server" Text='<%#Eval("d_credit_expiry") %>' /></td>
            <td><asp:Textbox ID="txt_ebaddress" runat="server" Text='<%#Eval("d_address_billing") %>' />
            <asp:RequiredFieldValidator ID="rfv_ebaddress" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ebaddress" 
                 ValidationGroup="editView" Display="Dynamic" />
            </td>
            <td><asp:Textbox ID="txt_ebcity" runat="server" Text='<%#Eval("d_city_billing") %>' />
            <asp:RequiredFieldValidator ID="rfv_ebcity" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ebcity" 
                 ValidationGroup="editView" Display="Dynamic" />
            </td>
            <td><asp:Textbox ID="txt_ebprovstate" runat="server" Text='<%#Eval("d_provstate_billing") %>' />
            <asp:RequiredFieldValidator ID="rfv_ebprovstate" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ebprovstate" 
                 ValidationGroup="editView" Display="Dynamic" />
            </td>
            <td><asp:Textbox ID="txt_ebcountry" runat="server" Text='<%#Eval("d_country_billing") %>' />
            <asp:RequiredFieldValidator ID="rfv_ebcountry" runat="server" ErrorMessage="*Required" ControlToValidate="txt_ebcountry" 
                 ValidationGroup="editView" Display="Dynamic" />
            </td>
        </tr>
        </table>
        </ItemTemplate>

        </asp:Repeater>

    </asp:Panel>


    <asp:Label ID="lbl_execmess" runat="server"  />

</asp:Content>

