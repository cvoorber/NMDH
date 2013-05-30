<%@ Page Title="FAQ-Search" Language="C#" MasterPageFile="~/maintemplate.master" AutoEventWireup="true" CodeFile="faq-search.aspx.cs" Inherits="_Default" %>

<asp:Content ID="cnt_faqhead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cnt_faqmain" ContentPlaceHolderID="content_area" Runat="Server">
    
    <div class="faq-main">
    <div class="faq-title">Frequently Asked Question Search</div>
    <br /><br />
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
    
    <asp:Repeater ID="rpt_searchresults" runat="server" >
    
    <ItemTemplate>
    <div class="faq-item">
        <asp:Label ID="lbl_seresult" runat="server" Text='<%#Eval("ndmh_faq_title") %>' Font-Bold="true" />
        <br /><br />
        <asp:Label ID="lbl_secontent" runat="server" Text='<%#Eval("ndmh_content") %>' />
        <br /><br />
        <asp:Button ID="btn_morefaq" runat="server" Text="Other Faqs" OnClick="subMoreFaqs" />
        </div>
    </ItemTemplate>
    

    </asp:Repeater>
    

    <asp:Repeater ID="rpt_morefaqs" runat="server">
    <HeaderTemplate>
    <asp:Label runat="server" ID="lbl_mrtitle" Font-Size="Large" Font-Bold="true" Text="More FAQs" /> <br /> <br />
    </HeaderTemplate>
    <ItemTemplate>
    <div class="faq-item">
        <asp:Label ID="lbl_morefaqtitle" runat="server" Text='<%#Eval("ndmh_faq_title") %>' Font-Bold="true" /><br /><br />
        <asp:Label ID="lbl_morefaqcontent" runat="server" Text='<%#Eval("ndmh_content") %>' />
        </div>


    </ItemTemplate>
    </asp:Repeater>
    </div>


</asp:Content>

