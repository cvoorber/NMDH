<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobappsedit.aspx.cs" Inherits="Admin_jobappsedit" MasterPageFile="~/Admin/subAdmin.master" %>

<asp:Content runat="server" ContentPlaceHolderID="r_content">
    <script type="text/javascript">
        function confirmMessage() {
            return confirm("Are you sure? The associated resume file will be deleted as well.");
        }
    </script>

    <h1><asp:Label ID="lbl_title" runat="server" Text="Careers" /></h1>

    <%-- Insert form was consciously taken out. 
        Does not make sense to allow inserting of a job application 
    --%>
    
    <asp:Panel ID="pnl_apps" runat="server">
           <asp:DataList ID="dtl_apps" runat="server" GridLines="Both">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Application ID</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Address</th>
                            <th>City</th>
                            <th>Province</th>
                            <th>Postal Code</th>
                            <th>Phone</th>
                            <th>Alt. Phone</th>
                            <th>Email</th>
                            <th>Is/Was Employee</th>
                            <th>Can Work in Canada</th>
                            <th>18 and Over</th>
                            <th>Convicted of Felony</th>
                            <th>Job ID</th>
                            <th>Resume File</th>
                            <th>Date Applied</th>
                            <th>Update</th>
                            <th>Delete</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("j_application_id") %></td>
                        <td><%#Eval("j_first_name") %></td>
                        <td><%#Eval("j_last_name") %></td>
                        <td><%#Eval("j_address") %></td>
                        <td><%#Eval("j_city") %></td>
                        <td><%#Eval("j_province") %></td>
                        <td><%#Eval("j_postal") %></td>
                        <td><%#Eval("j_phone") %></td>
                        <td><%#Eval("j_alt_phone") %></td>
                        <td><%#Eval("j_email") %></td>
                        <td><%#Eval("j_was_employee") %></td>
                        <td><%#Eval("j_is_eligible") %></td>
                        <td><%#Eval("j_of_age") %></td>
                        <td><%#Eval("j_was_convicted") %></td>
                        <td><%#Eval("j_id") %></td>
                        <td><%#Eval("j_resume") %></td>
                        <td><%#Eval("j_date_applied") %></td>
                        <td><asp:Button ID="btn_update" runat="server" Text="Edit" OnClick="subEdit" CommandArgument='<%#Eval("j_application_id") %>' /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" OnClick="subDelete" OnClientClick="confirmMessage();" CommandArgument='<%#Eval("j_application_id") %>' /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </asp:Panel>
        
        <asp:Panel ID="pnl_update" runat="server">
            <asp:DataList ID="dtl_update" runat="server" OnItemCommand="subUpdate">
                <ItemTemplate>
                    <asp:Label ID="lbl_jidU" runat="server" Text='<%#Eval("j_application_id") %>' />
                    <br />
                    <asp:Label ID="lbl_fnameU" runat="server" Text="First Name: " />
                    <asp:TextBox ID="txt_fnameU" runat="server" Text='<%#Bind("j_first_name") %>' />
                    <asp:RequiredFieldValidator ID="rfv_fnameU" runat="server" ControlToValidate="txt_fnameU" ErrorMessage="*required" />
                    <br />
        
                    <asp:Label ID="lbl_lnameU" runat="server" Text="Last Name: " />
                    <asp:TextBox ID="txt_lnameU" runat="server" Text='<%#Bind("j_last_name") %>' />
                    <asp:RequiredFieldValidator ID="rfv_lnameU" runat="server" ControlToValidate="txt_lnameU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="lbl_addressU" runat="server" Text="Address: " />
                    <asp:TextBox ID="txt_addressU" runat="server" Text='<%#Bind("j_address") %>' />
                    <asp:RequiredFieldValidator ID="rfv_addressU" runat="server" ControlToValidate="txt_addressU" ErrorMessage="*required" />
                    <br />
            
                    <asp:Label ID="lbl_cityU" runat="server" Text="City: " />
                    <asp:TextBox ID="txt_cityU" runat="server" Text='<%#Bind("j_city") %>' />
                    <asp:RequiredFieldValidator ID="rfv_cityU" runat="server" ControlToValidate="txt_cityU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="lbl_provinceU" runat="server" Text="Province: " />
                    <asp:TextBox ID="txt_provinceU" runat="server" Text='<%#Bind("j_province") %>' />
                    <asp:RequiredFieldValidator ID="rfv_provinceU" runat="server" ControlToValidate="txt_provinceU" ErrorMessage="*required" />
                    <br />
                    
                    <asp:Label ID="lbl_postalU" runat="server" Text="Postal Code: " />
                    <asp:TextBox ID="txt_postalU" runat="server" Text='<%#Bind("j_postal") %>' />
                    <asp:RequiredFieldValidator ID="rfv_postalU" runat="server" ControlToValidate="txt_postalU" ErrorMessage="*required" />
                    <asp:RegularExpressionValidator ID="reg_postalU" runat="server" ControlToValidate="txt_postalU" ErrorMessage="*invalid postal code (e.g., m4m3b2,m4m-3b2,M4M 3B2)" ValidationExpression="^[a-zA-Z]\d[a-zA-Z](\s|-)?\d[a-zA-Z]\d$" />
                    <br />

                    <asp:Label ID="lbl_phoneU" runat="server" Text="Phone Number: " />
                    <asp:TextBox ID="txt_phoneU" runat="server" Text='<%#Bind("j_phone") %>' />
                    <asp:RequiredFieldValidator ID="rfv_phoneU" runat="server" ControlToValidate="txt_phoneU" ErrorMessage="*required" />
                    <asp:RegularExpressionValidator ID="reg_phoneU" runat="server" ControlToValidate="txt_phoneU" ErrorMessage="*invalid phone number (e.g., 4166666666, 416-666-6666, 416 666 6666)" ValidationExpression="^[2-9]\d{2}(\s|-)?\d{3}(\s|-)?\d{4}$" />
                    <br />

                    <asp:Label ID="lbl_altphoneU" runat="server" Text="Alt. Phone: " />
                    <asp:TextBox ID="txt_altphoneU" runat="server" Text='<%#Bind("j_alt_phone") %>' />
                    <asp:CustomValidator ID="ctv_altphoneU" runat="server" ControlToValidate="txt_altphoneU" ErrorMessage="*invalid phone number (e.g., 4166666666, 416-666-6666, 416 666 6666)" ClientValidationFunction="subValidatePhone" />
                    <br />

                    <asp:Label ID="lbl_emailU" runat="server" Text="Email: " />
                    <asp:TextBox ID="txt_emailU" runat="server" Text='<%#Bind("j_email") %>' />
                    <asp:RequiredFieldValidator ID="rfv_emailU" runat="server" ControlToValidate="txt_emailU" ErrorMessage="*required" />
                    <asp:RegularExpressionValidator ID="reg_emailU" runat="server" ControlToValidate="txt_emailU" ErrorMessage="*invalid email (e.g., abc@fafsf.com)" ValidationExpression="^[^@ ]+@[^@ ]+\.[^@ \.]+$" />
                    <br />

                    <asp:Label ID="lbl_employeeU" runat="server" Text="Was Employee: " />
                    <asp:DropDownList ID="ddl_employeeU" runat="server" SelectedValue='<%#Eval("j_was_employee") %>'>
                        <asp:ListItem Value="y" Text="Yes" />
                        <asp:ListItem Value="n" Text="No" />
                    </asp:DropDownList>
                    <br />

                    <asp:Label ID="lbl_eligibleU" runat="server" Text="Is Eligible: " />
                    <asp:DropDownList ID="ddl_eligibleU" runat="server" SelectedValue='<%#Eval("j_is_eligible") %>'>
                        <asp:ListItem Value="y" Text="Yes" />
                        <asp:ListItem Value="n" Text="No" />
                    </asp:DropDownList>
                    <br />

                    <asp:Label ID="lbl_ageU" runat="server" Text="Is of Age: " />
                    <asp:DropDownList ID="ddl_ageU" runat="server"  SelectedValue='<%#Eval("j_of_age") %>'>
                        <asp:ListItem Value="y" Text="Yes" />
                        <asp:ListItem Value="n" Text="No" />
                    </asp:DropDownList>
                    <br />
                   
                    <asp:Label ID="lbl_convictU" runat="server" Text="Was Convicted: " />
                    <asp:DropDownList ID="ddl_convictU" runat="server" SelectedValue='<%#Eval("j_was_convicted") %>' >
                        <asp:ListItem Value="y" Text="Yes" />
                        <asp:ListItem Value="n" Text="No" />
                    </asp:DropDownList>
                    <br />

                    <asp:Label ID="lbl_jobIDU" runat="server" Text="Job ID: " />
                    <asp:TextBox ID="txt_jobIDU" runat="server" Text='<%#Bind("j_id") %>' />
                    <asp:RequiredFieldValidator ID="rfv_jobIDU" runat="server" ControlToValidate="txt_jobIDU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="lbl_resumeU" runat="server" Text="Resume File: " />
                    <asp:TextBox ID="txt_resumeU" runat="server" Text='<%#Bind("j_resume") %>' />
                    <asp:RequiredFieldValidator ID="rfv_resumeU" runat="server" ControlToValidate="txt_resumeU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="lbl_dateU" runat="server" Text="Date Applied: " />
                    <asp:TextBox ID="txt_dateU" runat="server" Text='<%#Bind("j_date_applied") %>' />
                    <asp:RequiredFieldValidator ID="rfv_dateU" runat="server" ControlToValidate="txt_dateU" ErrorMessage="*required" />
                    <br />

                    <asp:HiddenField ID="hdf_jappID" runat="server" Value='<%#Eval("j_application_id") %>' />
                    <asp:Button ID="btn_update" runat="server" CommandName="update" Text="Update" />
                    <asp:Button ID="btn_clear" runat="server" CommandName="cancel" Text="Cancel" CausesValidation="false" />
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
        <asp:Label ID="lbl_result" runat="server" />
</asp:Content>

