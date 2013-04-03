﻿<%@ Page Title="" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="faq-search.aspx.cs" Inherits="_Default" %>

<asp:Content ID="cnt_faqhead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cnt_faqmain" ContentPlaceHolderID="content_area" Runat="Server">
    
    <%--Need this to run toolkit controls--%>
    <AJAX:ToolkitScriptManager ID="tsm_faqsearch" runat="server" />
    
    Enter search term here: 
    <asp:TextBox ID="txt_faqsearch" runat="server" Width="500px" />
    <asp:Button ID="btn_faqsearch" runat="server" Text="Search" OnClick="subSearchSubmit" />
    
    <%--This control gives the autocomplete functionality--%>
    <AJAX:AutoCompleteExtender ID="cae_faqsearch" runat="server" 
        TargetControlID="txt_faqsearch" ServiceMethod="GetCompletionList" 
        UseContextKey="True" CompletionSetCount="5" />
    <br />
    <asp:Label ID="lbl_test" runat="server" />
    <asp:Repeater ID="rpt_searchresults" runat="server">
    <ItemTemplate>
        <asp:Label ID="lbl_seresult" runat="server" Text='<%#Eval("ndmh_faq_title") %>' />
    </ItemTemplate>

    </asp:Repeater>



</asp:Content>
