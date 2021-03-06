﻿<%@ Page Title="" Theme="Theme1" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="careers.aspx.cs" Inherits="careers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
    <%-- repeater to populate the job categories --%>
    <asp:Repeater ID="rpt_careers" runat="server">
        <HeaderTemplate>
            <h1>Job Categories</h1>
        </HeaderTemplate>
        <ItemTemplate>
            <%-- each category will be link that postback to the page with a category id for bookmarking --%>
            <asp:HyperLink ID="hl_cat" runat="server" NavigateUrl='<%#String.Format("~/navigation/careers.aspx?catID={0}",Eval("j_category_id")) %>' Text='<%#Eval("j_category_name") %>' />
            <br />
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">

    <asp:Panel ID="pnl_careers" runat="server">
        <h1><asp:Label runat="server" Text="Careers at NDMH" /></h1>
        <br />
        <p>
            <asp:Label runat="server"
                    Text="Come join our team!  Help us provide the best services to our beautiful community." /> 
        </p>
    </asp:Panel>

    <%-- panel that shows up upon selecting a category --%>
    <asp:Panel ID="pnl_jobs" runat="server">
        <h1><asp:Label ID="lbl_jCat" runat="server" /></h1>

        <%-- repeater that shows all job postings based on a category id --%>
        <asp:Repeater ID="rpt_joblist" runat="server">
            <HeaderTemplate>
               <table class="table-grid">
                    <tr>
                        <th>Job ID</th>
                        <th>Job Title</th>
                        <th>Post Date</th>
                        <th>Expiry Date</th>
                        <th></th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("j_id") %></td>
                    <td><%#Eval("j_title") %></td>
                    <td><%#Eval("j_posted_date", "{0:MM/dd/yyyy}") %></td>
                    <td><%#Eval("j_expires", "{0:MM/dd/yyyy}") %></td>
                    
                    <%-- view link will postback to show the information on the job clicked --%>
                    <td><asp:HyperLink ID="hl_post" runat="server" Text="View" NavigateUrl='<%#String.Format("~/navigation/careers.aspx?jobID={0}",Eval("j_id")) %>'  /></td>
                </tr>
            </ItemTemplate>
            
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

    <%-- panel to show information on a specific job when its 'view' link is clicked --%>
    <asp:Panel ID="pnl_viewpost" runat="server" Visible="false">
       <asp:Repeater runat="server" ID="rpt_post">
            <ItemTemplate>
                <p>Job ID: <%#Eval("j_id") %></p>
                <p>Job Title: <%#Eval("j_title") %></p>
                <p>Job Description: <%#Eval("j_description") %></p>
                <p>Job Requirements: <%#Eval("j_requirements") %></p>
                <p>Post Date: <%#Eval("j_posted_date", "{0:MM/dd/yyyy}")%></p>
                <p>Expiry Date: <%#Eval("j_expires", "{0:MM/dd/yyyy}")%></p>

                <%-- button that will direct the user to the form to apply for the job --%>
                <asp:Button ID="btn_app" runat="server" Text="Apply Now" OnClick="subApply" CommandArgument='<%#Eval("j_id") %>' />
            </ItemTemplate>
       </asp:Repeater>
    </asp:Panel>

    <%-- panel that the application form resides in --%>
    <asp:Panel ID="pnl_form" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_jlabel" runat="server" Text="Job ID: " />
                </td>
                <td>
                    <asp:Label ID="lbl_jID" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_fname" runat="server" Text="First Name:" />
                </td>
                <td>
                    <asp:TextBox ID="txt_fname" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_fname" runat="server" ControlToValidate="txt_fname" ErrorMessage="*required" />
                </td>
            <tr/>
            <tr>
                <td>
                    <asp:Label ID="lbl_lname" runat="server" Text="Last Name:" />
                </td>
                <td>    
                    <asp:TextBox ID="txt_lname" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_lname" runat="server" ControlToValidate="txt_lname" ErrorMessage="*required" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_address" runat="server" Text="Address:" />
                </td>
                <td>
                    <asp:TextBox ID="txt_address" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_address" runat="server" ControlToValidate="txt_address" ErrorMessage="*required" />
                </td>
            </tr>
        
            <tr>
                <td>
                    <asp:Label ID="lbl_city" runat="server" Text="City:" />
                </td>
                <td> 
                    <asp:TextBox ID="txt_city" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_city" runat="server" ControlToValidate="txt_city" ErrorMessage="*required" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_prov" runat="server" Text="Province:" />
                </td>
                <td>
                    <asp:DropDownList ID="ddl_prov" runat="server">
                        <asp:ListItem Value="none">-Select a Province-</asp:ListItem>
                        <asp:ListItem Value="on">Ontario</asp:ListItem>
                        <asp:ListItem Value="qc">Quebec</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_prov" runat="server" ControlToValidate="ddl_prov" InitialValue="none" ErrorMessage="*required" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_pcode" runat="server" Text="Postal Code:" />
                </td>
                <td>   
                    <asp:TextBox ID="txt_pcode" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_pcode" runat="server" ControlToValidate="txt_pcode" ErrorMessage="*required" />
                    <asp:RegularExpressionValidator ID="reg_prov" runat="server" ControlToValidate="txt_pcode" ErrorMessage="*valid postal code required eg m4m4m4" ValidationExpression="^[a-zA-Z][0-9][a-zA-Z](\s|-)?[0-9][a-zA-Z][0-9]$" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_phone" runat="server" Text="Home Phone:" />
                </td>
                <td>    
                    <asp:TextBox ID="txt_phone" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_phone" runat="server" ControlToValidate="txt_phone" ErrorMessage="*required" />
                    <asp:RegularExpressionValidator ID="reg_phone" runat="server" ControlToValidate="txt_phone" ErrorMessage="*valid phone number required eg 416-000-0000" ValidationExpression="^[2-9]\d{2}(\s|-)?\d{3}(\s|-)?\d{4}$" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_altphone" runat="server" Text="Alternate Phone:" />
                </td>
                <td>    
                    <asp:TextBox ID="txt_altphone" runat="server" />
                    <asp:CustomValidator ID="ctv_phone" runat="server" ErrorMessage="*valid phone number required eg 416-000-0000" OnServerValidate="subValidPhone"  />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_email" runat="server" Text="Email:" />
                </td>
                <td>    
                    <asp:TextBox ID="txt_email" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv_email" runat="server" ControlToValidate="txt_email" ErrorMessage="*required" />
                    <asp:RegularExpressionValidator ID="Reg_email" runat="server" ControlToValidate="txt_email" ErrorMessage="*valid email required eg abc@xyc.com" ValidationExpression="^[^@ ]+@[^@ ]+\.[^@ \.]+$" />
                </td>
            </tr>
        </table>
        <br /><br />
        <hr />
        <asp:Label ID="lbl_cur_emp" runat="server" Text="Are you a current or former NDMH employee?" />
        <asp:RadioButtonList ID="rbl_cur_emp" runat="server" RepeatDirection="Horizontal" CssClass="no-border">
            <asp:ListItem Value="y">Yes</asp:ListItem>
            <asp:ListItem Value="n">No</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="rfv_cur_emp" runat="server" ErrorMessage="*required" ControlToValidate="rbl_cur_emp" />
        <br />

        <asp:Label ID="lbl_elig" runat="server" Text="Are you legally able to work in Canada?" CssClass="no-border" />
        <asp:RadioButtonList ID="rbl_elig" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="y">Yes</asp:ListItem>
            <asp:ListItem Value="n">No</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="rfv_elig" runat="server" ErrorMessage="*required" ControlToValidate="rbl_elig" />
        <br />
       
       <asp:Label ID="lbl_convict" runat="server" Text="Have you ever been convicted of a federal criminal offence?" CssClass="no-border" />
        <asp:RadioButtonList ID="rbl_convict" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="y">Yes</asp:ListItem>
            <asp:ListItem Value="n">No</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="rfv_convict" runat="server" ErrorMessage="*required" ControlToValidate="rbl_convict" />
        <br />

        <asp:Label ID="lbl_legal" runat="server" Text="Are you over the age of 18?" />
        <asp:RadioButtonList ID="rbl_legal" runat="server" RepeatDirection="Horizontal" CssClass="no-border">
            <asp:ListItem Value="y">Yes</asp:ListItem>
            <asp:ListItem Value="n">No</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="rfv_legal" runat="server" ErrorMessage="*required" ControlToValidate="rbl_legal" />

        <br /><br />

        <%-- file upload using ajax --%>
        <asp:ScriptManager ID="scm_main" runat="server" EnablePartialRendering="true" />
        <asp:Label ID="lbl_file" runat="server" Text="Upload resume and cover letter (doc/docx/pdf):"  />
        <br />
        <asp:FileUpload ID="fu_main" runat="server"  />
        <asp:RequiredFieldValidator ID="rfv_resume" runat="server" ControlToValidate="fu_main" ErrorMessage="*required" />
       
        <asp:Label ID="lbl_status" runat="server" />
        
        
       <br /><br />
        <input type="reset" value="Clear" />
        <asp:Button ID="btn_submit" Text="Submit" runat="server" OnClick="subSubmit" />
    </asp:Panel>

    <%-- panel to hold thank you message upon submission of application --%>
    <asp:Panel ID="pnl_thankyou" runat="server" Visible="false">
        <asp:Label ID="lbl_thank" runat="server" Text="Thank you for applying for a position at NDMH." />
        <br /><br />
        <asp:HyperLink ID="hl_career" runat="server" NavigateUrl="~/navigation/careers.aspx" Text="Back to Careers page." />
    </asp:Panel>
    <br />
    <asp:Label ID="lbl_result" runat="server" />
</asp:Content>

