<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="CeProjectManager.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 ID="loginH2" runat="server">
       Login Page 
    </h2>
    
    <div class="form-group">
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" UserNameLabelText="Login:" UserNameRequiredErrorMessage="Login is required." DisplayRememberMe="False" TitleText="">
        </asp:Login>
    </div>
   
</asp:Content>
