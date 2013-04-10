<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobpostsedit.aspx.cs" Inherits="Admin_jobpostsedit" MasterPageFile="~/Admin/subAdmin.master" %>

<asp:Content runat="server" ContentPlaceHolderID="r_content">
        <h1><asp:Label ID="lbl_title" runat="server" Text="Careers" /></h1>
        

        <%-- panel to insert new job post --%>
        <asp:Panel ID="pnl_insert" runat="server">
                    <asp:Label ID="lbl_jobtitleI" runat="server" Text="Job Title: " />
                    <asp:TextBox runat="server" ID="txt_titleI"/>
                    <asp:RequiredFieldValidator ID="rfv_titleI" runat="server" ControlToValidate="txt_titleI" ErrorMessage="*required" ValidationGroup="insertgroup" />
                    <br />

                    <asp:Label ID="lbl_descI" runat="server" Text="Description: " />
                    <asp:TextBox runat="server" ID="txt_descI" />
                    <asp:RequiredFieldValidator ID="rfv_descI" runat="server" ControlToValidate="txt_descI" ErrorMessage="*required" ValidationGroup="insertgroup" />
                    <br />

                    <asp:Label ID="lbl_reqI" runat="server" Text="Requirements: " />
                    <asp:TextBox runat="server" ID="txt_reqI"  />
                    <asp:RequiredFieldValidator ID="rfv_reqI" runat="server" ControlToValidate="txt_reqI" ErrorMessage="*required" ValidationGroup="insertgroup" />
                    <br />

                    <asp:Label ID="lbl_postI" runat="server" Text="Post Date: " />
                    <asp:TextBox runat="server" ID="txt_postI" />
                    <asp:RequiredFieldValidator ID="rfv_postI" runat="server" ControlToValidate="txt_postI" ErrorMessage="*required" ValidationGroup="insertgroup" />
                    <br />
                    
                    <asp:Label ID="lbl_expiresI" runat="server" Text="Expires on: " />
                    <asp:TextBox runat="server" ID="txt_expiresI" />
                    <asp:RequiredFieldValidator ID="rfv_expiresI" runat="server" ControlToValidate="txt_expiresI" ErrorMessage="*required" ValidationGroup="insertgroup" />
                    <br />
                    
                    <asp:Label ID="lbl_jcatI" runat="server" Text="Job Category ID: " />
                    <asp:TextBox runat="server" ID="txt_jcatI" />
                    <asp:RequiredFieldValidator ID="rfv_jcatI" runat="server" ControlToValidate="txt_jcatI" ErrorMessage="*required" ValidationGroup="insertgroup" />
                    <br />
                    
            <br />
            <asp:Button ID="btn_insert" runat="server" Text="Insert" OnClick="subInsert"  ValidationGroup="insertgroup" />
        </asp:Panel>
        
        <%-- panel that lists all job posts for editing --%>
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
        
        
        <%-- panel that is invoked when the Edit buttons are clicked --%>
        <asp:Panel ID="pnl_update" runat="server">
            <asp:DataList ID="dtl_update" runat="server" OnItemCommand="subUpdate">
                <ItemTemplate>
                    <asp:HiddenField ID="hdf_jid" runat="server" Value='<%#Eval("j_id") %>' />
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
                    <asp:Button ID="btn_update" runat="server" CommandName="update" Text="Update" />
                    <asp:Button ID="btn_cancel" runat="server" CommandName="cancel" Text="Cancel" />
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>   
        <asp:Label ID="lbl_result" runat="server" />
</asp:Content>
