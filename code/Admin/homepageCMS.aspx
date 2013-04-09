<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/subAdmin.master" AutoEventWireup="true" CodeFile="homepageCMS.aspx.cs" Inherits="Admin_homepageCMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
<div id="editWait">
    <h1>Wait Time Estimation Update</h1>
    <p style="font-size:18px;">Update values based on real time information, and wait time will be calculated based on these numbers.</p>
    <%-- Displays a success/failure message --%>
    <asp:Label ID="lbl_message" runat="server" />
    <br />
    <%-- ListView to edit the wait time variables --%>
    <asp:ListView ID="lv_main" runat="server" OnItemCommand="subAdmin">
        <LayoutTemplate>
            <table cellpadding="3" cellspacing="5">
                <thead>
                    <tr>
                        <th style="font-weight:bold;font-size:16px;">Patients Waiting</th>
                        <th style="font-weight:bold;font-size:16px;">Doctors On Unit</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </tbody>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="txt_patientsE" runat="server" Text='<%#Bind("w_patients") %>' />
                </td>
                <td>
                    <asp:TextBox ID="txt_onstaffE" runat="server" Text='<%#Bind("w_onstaff") %>' />
                </td>
                <td>
                    <asp:LinkButton ID="lb_update" runat="server" Text="UPDATE" CommandName="subUpdate" BackColor="LightGray" Font-Size="10" Style="padding:5px;margin-left:10px;border-radius:3px;" BorderWidth="1" BorderColor="Black" />
                </td>
            <tr>
                <td>
                    <%-- Input required --%>
                    <asp:RequiredFieldValidator ID="rfv_patientsE" runat="server" Text="*Required" Display="Static" ControlToValidate="txt_patientsE" SkinID="RFvalidators" />
                </td>
                <td>
                    <%-- Input required --%>
                    <asp:RequiredFieldValidator ID="rfv_onstaffE" runat="server" Text="*Required" Display="Static" ControlToValidate="txt_onstaffE" SkinID="RFvalidators" />
                </td>
                <td>
                    <asp:HiddenField ID="hdf_idE" runat="server" Value='<%#Eval("w_id") %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <%-- Only numbers are allowed --%>
                    <asp:RegularExpressionValidator ID="rev_patientsE" runat="server" Text="*Must be a number" Display="Dynamic" ControlToValidate="txt_patientsE" ValidationExpression="^\d+$" SkinID="REvalidators" />
                </td>
                <td>
                    <%-- Only numbers are allowed --%>
                    <asp:RegularExpressionValidator ID="rev_onstaffE" runat="server" Text="*Must be a number" Display="Dynamic" ControlToValidate="txt_onstaffE" ValidationExpression="^\d+$" SkinID="REvalidators" />
                </td>
                <td>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</div>
</asp:Content>

