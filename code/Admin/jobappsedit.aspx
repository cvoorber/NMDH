<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobappsedit.aspx.cs" Inherits="Admin_jobappsedit" MasterPageFile="~/Admin/subAdmin.master" %>

<asp:Content runat="server" ContentPlaceHolderID="r_content">
    <asp:Label ID="lbl_title" runat="server" Text="Careers" />
        <br /><br />

    <asp:Menu ID="mnu_career" runat="server" Orientation="Vertical">
        <Items>
            <asp:MenuItem Value="1" Text="Categories" />
            <asp:MenuItem Value="2" Text="Job Postings" />
            <asp:MenuItem Value="3" Text="Job Applications" />
        </Items>
    </asp:Menu>

    <asp:Panel ID="pnl_insert" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Job Title: " />
                <asp:TextBox runat="server" ID="txt_titleU"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_titleU" ErrorMessage="*required" />
                <br />

                <asp:Label ID="Label2" runat="server" Text="Description: " />
                <asp:TextBox runat="server" ID="txt_descU" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_descU" ErrorMessage="*required" />
                <br />

                <asp:Label ID="Label3" runat="server" Text="Requirements: " />
                <asp:TextBox runat="server" ID="txt_reqU"  />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_reqU" ErrorMessage="*required" />
                <br />

                <asp:Label ID="Label4" runat="server" Text="Post Date: " />
                <asp:TextBox runat="server" ID="txt_postU" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_postU" ErrorMessage="*required" />
                <br />
                    
                <asp:Label ID="Label5" runat="server" Text="Expires on: " />
                <asp:TextBox runat="server" ID="txt_expiresU" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_expiresU" ErrorMessage="*required" />
                <br />
                    
                <asp:Label ID="Label6" runat="server" Text="Job Category ID: " />
                <asp:TextBox runat="server" ID="txt_jcatU" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_jcatU" ErrorMessage="*required" />
                <br />
                    
        <br />
        <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="subInsert" />
    </asp:Panel>
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
                        <td><asp:Button ID="btn_update" runat="server" Text="Edit" CommandName="Edit" /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="subDelete" /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </asp:Panel>
        <asp:Label ID="lbl_result" runat="server" />
</asp:Content>
