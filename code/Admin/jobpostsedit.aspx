<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobpostsedit.aspx.cs" Inherits="Admin_jobpostsedit" MasterPageFile="~/Admin/subAdmin.master" %>

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
        
        <asp:Panel ID="pnl_jobs" runat="server">
            <asp:DataList ID="dtl_jobs" runat="server" GridLines="Both">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Job ID</th>
                            <th>Title</th>
                            <th>Description</th>
                            <th>Requirements</th>
                            <th>Post Date</th>
                            <th>Expiry Date</th>
                            <th>Category ID</th>
                            <th>Update</th>
                            <th>Delete</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("j_id") %></td>
                        <td><%#Eval("j_title") %></td>
                        <td><%#Eval("j_description") %></td>
                        <td><%#Eval("j_requirements") %></td>
                        <td><%#Eval("j_posted_date","{0:MM/dd/yyyy}") %></td>
                        <td><%#Eval("j_expires","{0:MM/dd/yyyy}") %></td>
                        <td><%#Eval("j_category_id") %></td>
                        <td><asp:Button ID="btn_edit" runat="server" Text="Edit" OnClick="subEdit" CommandArgument='<%#Eval("j_id") %>' /></td>
                        <td><asp:Button ID="btn_delete" runat="server" Text="Delete" OnClick="subDelete" OnClientClick="return confirm('Are you sure?');" CommandArgument='<%#Eval("j_id") %>' /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>
        </asp:Panel>    
        
        
        
        <asp:Panel ID="pnl_update" runat="server">
            <asp:DataList ID="dtl_update" runat="server">
                <ItemTemplate>
                    <asp:Label ID="lbl_jid" runat="server" Text='<%# String.Format("Job ID: {0}",Eval("j_id")) %>' />
                    <br />
                        
                    <asp:Label runat="server" Text="Job Title: " />
                    <asp:TextBox runat="server" ID="txt_titleU" Text='<%#Bind("j_title") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_titleU" ErrorMessage="*required" />
                    <br />

                    <asp:Label runat="server" Text="Description: " />
                    <asp:TextBox runat="server" ID="txt_descU" Text='<%#Bind("j_description") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_descU" ErrorMessage="*required" />
                    <br />

                    <asp:Label runat="server" Text="Requirements: " />
                    <asp:TextBox runat="server" ID="txt_reqU" Text='<%#Bind("j_requirements") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_reqU" ErrorMessage="*required" />
                    <br />

                    <asp:Label runat="server" Text="Post Date: " />
                    <asp:TextBox runat="server" ID="txt_postU" Text='<%#Bind("j_posted_date","{0:MM/dd/yyyy}") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_postU" ErrorMessage="*required" />
                    <br />
                    
                    <asp:Label runat="server" Text="Expires on: " />
                    <asp:TextBox runat="server" ID="txt_expiresU" Text ='<%#Bind("j_expires","{0:MM/dd/yyyy}") %>'/>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_expiresU" ErrorMessage="*required" />
                    <br />
                    
                    <asp:Label runat="server" Text="Job Category ID: " />
                    <asp:TextBox runat="server" ID="txt_jcatU" Text='<%#Bind("j_category_id") %>' />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_jcatU" ErrorMessage="*required" />
                    <br />
                    <asp:Button ID="btn_update" runat="server" OnClick="subUpdate" CommandArgument='<%#Eval("j_id") %>' Text="Update" />
                    <asp:Button ID="btn_cancel" runat="server" OnClick="subCancel" Text="Cancel" />
                    <br />
                    <asp:Label ID="lbl_result" runat="server" />
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>   
        <asp:Label ID="lbl_result" runat="server" />
    </div>
    </form>
</body>
</html>
