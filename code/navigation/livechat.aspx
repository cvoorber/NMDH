<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster1.master" AutoEventWireup="true" CodeFile="livechat.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="l_sidebar" Runat="Server">
    <h1>Why Chat?</h1>
    <p>We know you have a lot of questions about your health, and we want to help! That's why we have nurses on duty 24/7 to answer your most pressing questions from the comfort of your own home!</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="r_content" Runat="Server">
    <asp:ScriptManager ID="scm_main" runat="server" />
    <style>
        #commonWindow 
        {
            width: 400px;
            height: 300px;
            border: 1px solid black;
            
        }
    </style>
    <asp:Timer ID="tmr_main" runat="server" OnTick="subTick" Interval="1500" />


    Username: <asp:TextBox ID="txt_uname" runat="server" />
    <div id="commonWindow">
       <asp:UpdatePanel ID="udp_main" runat="server">
            <ContentTemplate>
                <asp:BulletedList ID="bl_messages" runat="server" Width="400px"/>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="tmr_main" EventName="Tick" />
            </Triggers>
       </asp:UpdatePanel>
       
    </div>
    <br />
    <asp:UpdatePanel ID="udp_send" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:TextBox ID="txt_message" runat="server" Width="400px" Height="60px" TextMode="MultiLine" />
            <br />
            <asp:Button ID="btn_send" runat="server" OnClick="subSend"  Text="Send" Width="60px" Height="60px"/>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn_send" EventName="Click" />
        </Triggers>
     </asp:UpdatePanel>       
        
    <br />
</asp:Content>

