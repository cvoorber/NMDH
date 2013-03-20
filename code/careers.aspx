<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="careers.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
    
    <asp:DropDownList ID="ddl_jobs" runat="server" OnSelectedIndexChanged="subChangeDesc" AutoPostBack="true"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <asp:Panel ID="pnl_description" runat="server" Visible="true">
       <asp:Repeater runat="server" ID="rpt_jobs">
            <ItemTemplate>
                <p><%#Eval("j_title") %></p>
                <%#Eval("j_description") %>

                <br />
                <asp:Button ID="btn_apply" runat="server" OnClick="subShow" Text="Apply Now" />
            </ItemTemplate>
       </asp:Repeater>
    </asp:Panel>
    <asp:Panel ID="pnl_form" runat="server" Visible="false">
        <asp:Label ID="lbl_fname" runat="server" Text="First Name:" />
        <asp:TextBox ID="txt_fname" runat="server" />
        <br />
        <asp:Label ID="lbl_lname" runat="server" Text="Last Name:" />
        <asp:TextBox ID="txt_lname" runat="server" />
        <br />
        <asp:Label ID="lbl_address" runat="server" Text="Address:" />
        <asp:TextBox ID="txt_address" runat="server" />
        <br />
        <asp:Label ID="lbl_city" runat="server" Text="City:" />
        <asp:TextBox ID="txt_city" runat="server" />
        <br />
        <asp:Label ID="lbl_prov" runat="server" Text="Province:" />
        <asp:DropDownList ID="ddl_prov" runat="server">
            <asp:ListItem Value="">-Select a Province-</asp:ListItem>
            <asp:ListItem Value="on">Ontario</asp:ListItem>
            <asp:ListItem Value="qc">Quebec</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lbl_pcode" runat="server" Text="Postal Code:" />
        <asp:TextBox ID="txt_pcode" runat="server" />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Address:" />
        <asp:TextBox ID="TextBox4" runat="server" />
        <br />
        <asp:Label ID="lbl_phone" runat="server" Text="Home Phone:" />
        <asp:TextBox ID="txt_phone" runat="server" />
        <br />

        <asp:Label ID="lbl_altphone" runat="server" Text="Alternate Phone:" />
        <asp:TextBox ID="txt_altphone" runat="server" />
        <br />

        <asp:Label ID="lbl_email" runat="server" Text="Email:" />
        <asp:TextBox ID="txt_email" runat="server" />
        <br /><br />
        <hr />
        <asp:Label ID="lbl_cur_emp" runat="server" Text="Are you a current or former NDMH employee?" />
        <asp:RadioButtonList ID="rbl_cur_emp" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="yes">Yes</asp:ListItem>
            <asp:ListItem Value="no">No</asp:ListItem>
        </asp:RadioButtonList>
        <br />

        <asp:Label ID="lbl_elig" runat="server" Text="Are you legally able to work in Canada?" />
        <asp:RadioButtonList ID="rbl_elig" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="yes">Yes</asp:ListItem>
            <asp:ListItem Value="no">No</asp:ListItem>
        </asp:RadioButtonList>
       
       <asp:Label ID="lbl_convict" runat="server" Text="Have you ever been convicted of a federal criminal offence?" />
        <asp:RadioButtonList ID="rbl_convict" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="yes">Yes</asp:ListItem>
            <asp:ListItem Value="no">No</asp:ListItem>
        </asp:RadioButtonList>
        <br />

        <asp:Label ID="lbl_legal" runat="server" Text="Are you over the age of 18?" />
        <asp:RadioButtonList ID="rbl_legal" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="yes">Yes</asp:ListItem>
            <asp:ListItem Value="no">No</asp:ListItem>
        </asp:RadioButtonList>
        <br /><br />

        <asp:Label ID="lbl_file" runat="server" Text="Upload resume and cover letter:" />
        <asp:FileUpload ID="fu_main" runat="server" />
       
        <asp:Button ID="btn_clear" Text="Clear" runat="server" CausesValidation="false" 
                    UseSubmitBehavior="false" OnClientClick="document.forms[0].reset();" />
        <asp:Button ID="btn_submit" Text="Submit" runat="server" OnClick="subSubmit" />
    </asp:Panel>
</asp:Content>

