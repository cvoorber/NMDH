<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobappsedit.aspx.cs" Inherits="Admin_jobappsedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lbl_title" runat="server" Text="Careers" />
        <br /><br />
    

    <asp:Menu ID="mnu_career" runat="server" Orientation="Vertical">
        <Items>
            <asp:MenuItem Value="1" Text="Categories" />
            <asp:MenuItem Value="2" Text="Job Postings" />
            <asp:MenuItem Value="3" Text="Job Applications" />
        </Items>
    </asp:Menu>

    <%-- Insert form was consciously taken out. 
        Does not make sense to allow inserting of a job application 
    --%>
    
    <asp:Panel ID="pnl_apps" runat="server" Visible="false">
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
                        <td><asp:Button ID="btn_update" runat="server" Text="Edit" CommandName="Edit" /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="subDelete" /></td>
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
                    <asp:TextBox ID="txt_fnameU" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_fnameU" runat="server" ControlToValidate="txt_fnameU" ErrorMessage="*required" />
                    <br />
        
                    <asp:Label ID="lbl_lnameU" runat="server" Text="Last Name: " />
                    <asp:TextBox ID="TextBox2" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_lnameU" runat="server" ControlToValidate="txt_lnameU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="lbl_addressU" runat="server" Text="Address: " />
                    <asp:TextBox ID="txt_addressU" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_addressU" runat="server" ControlToValidate="txt_addressU" ErrorMessage="*required" />
                    <br />
            
                    <asp:Label ID="lbl_cityU" runat="server" Text="City: " />
                    <asp:TextBox ID="txt_cityU" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_cityU" runat="server" ControlToValidate="txt_cityU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="lbl_provinceU" runat="server" Text="Province: " />
                    <asp:TextBox ID="txt_provinceU" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_provinceU" runat="server" ControlToValidate="txt_provinceU" ErrorMessage="*required" />
                    <br />
                    
                    <asp:Label ID="lbl_postalU" runat="server" Text="Postal Code: " />
                    <asp:TextBox ID="txt_postalU" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_postalU" runat="server" ControlToValidate="txt_postalU" ErrorMessage="*required" />
                    <asp:RegularExpressionValidator ID="reg_postalU" runat="server" ControlToValidate="txt_postalU" ErrorMessage="*invalid postal code (e.g., m4m3b2,m4m-3b2,M4M 3B2)" ValidationExpression="^[a-ZA-Z]\d[a-zA-Z](\s|-)?[a-ZA-Z]\d[a-zA-Z]$" />
                    <br />

                    <asp:Label ID="lbl_phoneU" runat="server" Text="Phone Number: " />
                    <asp:TextBox ID="txt_phoneU" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_phoneU" runat="server" ControlToValidate="txt_phoneU" ErrorMessage="*required" />
                    <asp:RegularExpressionValidator ID="reg_phoneU" runat="server" ControlToValidate="txt_phoneU" ErrorMessage="*invalid phone number (e.g., 4166666666, 416-666-6666, 416 666 6666)" ValidationExpression="^[2-9]\d{3}(\s|-)?\d{3}(\s|-)?\d{4}$" />
                    <br />

                    <asp:Label ID="lbl_altphoneU" runat="server" Text="Alt. Phone: " />
                    <asp:TextBox ID="txt_altphoneU" runat="server" />
                    <asp:CustomValidator ID="ctv_altphoneU" runat="server" ControlToValidate="txt_altphoneU" ErrorMessage="*invalid phone number (e.g., 4166666666, 416-666-6666, 416 666 6666)" ClientValidationFunction="subValidatePhone" />
                    <br />

                    <asp:Label ID="Label6" runat="server" Text="Address: " />
                    <asp:TextBox ID="TextBox7" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_addressU" ErrorMessage="*required" />
                    <br />


                    <asp:Label ID="Label7" runat="server" Text="Address: " />
                    <asp:TextBox ID="TextBox8" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_addressU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="Label8" runat="server" Text="Address: " />
                    <asp:TextBox ID="TextBox9" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_addressU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="Label9" runat="server" Text="Address: " />
                    <asp:TextBox ID="TextBox10" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_addressU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="Label10" runat="server" Text="Address: " />
                    <asp:TextBox ID="TextBox11" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_addressU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="Label11" runat="server" Text="Address: " />
                    <asp:TextBox ID="TextBox12" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_addressU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="Label12" runat="server" Text="Address: " />
                    <asp:TextBox ID="TextBox13" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_addressU" ErrorMessage="*required" />
                    <br />

                    <asp:Label ID="Label13" runat="server" Text="Address: " />
                    <asp:TextBox ID="TextBox14" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txt_addressU" ErrorMessage="*required" />
                    <br />


                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
